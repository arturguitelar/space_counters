using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class GameController : MonoBehaviour
{
    public int enemyNumberPerWave;
    public float spawnWait, startWait, waveWait;
    public bool playerIsDead = false;

    public GameObject[] enemyNumbers;
    public Vector3 spawnValues;

    private int score, challengeScore, challengeScoreResult, 
        lives, chaNumber1, chaNumber2, difficultCounter;

    private InGameDisplayText displayText;
    private FindControllers findPlayerController;
    private PlayerController player;
    private PhaseController phase;
    private ChallengeController challenge;
    private ChallengeObj objChallenge;

    // references to inGame progress stats
    private SaveGameStatus gameStatus;
    private StartPhase startTheGame;
    private SpawnWaves spawnWaves;
    private Restart restart;

    // only to cheat phases to test
    private PhaseCheater cheat;

    void Start()
    {
        // default components
        gameStatus = new SaveGameStatus();
        displayText = GetComponent<InGameDisplayText>();
        findPlayerController = GetComponent<FindControllers>();
        phase = GetComponent<PhaseController>();
        player = findPlayerController.FindPlayerController();
        challenge = GetComponent<ChallengeController>();
        cheat = new PhaseCheater();

        // setting scores and others
        // gameStatus.SetGameDifficultToPlayerPrefs(3); - to tests
        gameStatus.GetGameDifficultToPlayerPrefs();
        phase.MultiplierNextPhase();
        GameOverFlag = false;
        RestartFlag = false;
        score = 0;
        difficultCounter = 0;

        // setting start texts
        VerifyIfFirstGame();
        SetDisplayTexts();

        player.PlayerWait();

        // start the phase
        spawnWaves = new SpawnWaves();
        spawnWaves.GetGameControllerReference(this);

        startTheGame = new StartPhase();
        startTheGame.GetDisplayTextFromGameController(displayText);
        startTheGame.GetThePhaseFromGameController(phase);
        startTheGame.GetThePlayerFromGameController(player);

        StartCoroutine(startTheGame.StartTheGame(this));

        ContinueSpawnWaves = true;
        CanSpawnWaves();

        restart = new Restart(this, challenge);
        restart.GetDisplayTextFromGameController(displayText);

    }

    void Update()
    {
        restart.RestartGame();

        VerifyIfPlayerIsDead();

        cheat.ChangeThePhase();
    }

    public bool GameOverFlag { get; set; }
    public bool RestartFlag { get; set; }
    public bool ContinueSpawnWaves { get; set; }

    public InGameDisplayText DisplayText { get; set; }

    private void VerifyIfFirstGame()
    {
        gameStatus = new SaveGameStatus();

        if (phase.currentPhase == 1)
        {
            lives = player.lives;
            gameStatus.SetPlayerLivesToPlayerPrefs(lives);
            gameStatus.SetPlayerScoreToPlayerPrefs(score);            
        }
        else
        {
            player.lives = gameStatus.GetPlayerLivesFromPlayerPrefs();
            lives = player.lives;
            score = gameStatus.GetPlayerScoreFromPlayerPrefs();
        }
    }

    private void SetDisplayTexts()
    {
        displayText.SetLiveText(InGameConstantStrings.LIVES + lives);
        displayText.SetScoreText(InGameConstantStrings.SCORE + score);
        displayText.SetChallengeText("");
        displayText.SetNextPhaseText(InGameConstantStrings.NEXTPHASE + phase.toNextPhase);
    }

    public void CanSpawnWaves()
    {
        if (ContinueSpawnWaves == true)
        {
            StartCoroutine(spawnWaves.SpawningWaves());
        }

        if (ContinueSpawnWaves == false)
        {
            StopCoroutine(spawnWaves.SpawningWaves());
        }
    }

    // fluxo dos scores
    public void AddValue(int value)
    {
        challengeScore += value;
        displayText.SetChallengeAlertText(challengeScore.ToString());

        VerifyChallenge(challengeScore, challengeScoreResult);
        
    }

    private void VerifyChallenge(int scoreA, int scoreB)
    {

        if (scoreA > scoreB)
        {
            player.PlayerWait();

            DisplayError();

            DecreaseLivesPlayer();

            StartCoroutine(PlayerLoosingLive());
            StartCoroutine(TimeToNextChallenge());

        }

        if (scoreA == scoreB)
        {
            player.PlayerWait();

            displayText.SetChallengeText(InGameConstantStrings.ADDING_TO_SCORE);
            DisplayOK();

            ToNextPhaseCount();

            score += challengeScoreResult;

            UpdateScore();

            if (phase.toNextPhase <= 0)
            {
                StartCoroutine(ToNextPhase());
                return;
            }

            StartCoroutine(TimeToNextChallenge());

        }

    }

    private void DisplayError()
    {
        displayText.SetChallengeAlertTextColor(1f, 0f, 0f, 1f);

        displayText.SetChallengeAlertText(InGameConstantStrings.ERROR);
    }

    private void DisplayOK()
    {
        displayText.SetChallengeAlertTextColor(0f, 1f, 0f, 1f);

        displayText.SetChallengeAlertText(InGameConstantStrings.OK);
    }

    private void UpdateScore()
    {
        displayText.SetScoreText(InGameConstantStrings.SCORE + score);
    }

    public void UpdateChallenge()
    {
        challenge.SetChallengeType(phase.currentPhase);
        objChallenge = challenge.GetChallenge(challenge.GetChallengeType());

        challengeScore = 0;
        challengeScoreResult = objChallenge.Result;

        displayText.SetChallengeText(UpdateChallengeText());

        displayText.SetChallengeAlertTextColor(0.7f, 0.7f, 0.7f, 1f); // gray text

        displayText.SetChallengeAlertText("");

        difficultCounter++;

        CheckIfNeedIncreaseDifficult();
    }

    private void CheckIfNeedIncreaseDifficult()
    {
        if(difficultCounter > phase.numberChallengesToIncreaseDifficult)
        {
            challenge.IncreaseDifficult();
            difficultCounter = 0;
        }
    }

    IEnumerator TimeToNextChallenge()
    {
        if (player.lives > 0)
        {
            yield return new WaitForSeconds(2f);

            displayText.SetChallengeText(InGameConstantStrings.AWAITING_NEW_CHALLENGE);

            yield return new WaitForSeconds(2f);
            displayText.SetChallengeAlertTextColor(0f, 1f, 0f, 1f);
            displayText.SetChallengeAlertText(InGameConstantStrings.READY);

            yield return new WaitForSeconds(1f);
            displayText.SetChallengeAlertText(InGameConstantStrings.GO);

            yield return new WaitForSeconds(1f);
            UpdateChallenge();
            player.PlayerAwake();
        }

    }

    // next phase
    private void ToNextPhaseCount()
    {
        phase.toNextPhase--;
        displayText.SetNextPhaseText(InGameConstantStrings.NEXTPHASE + phase.toNextPhase);
    }

    IEnumerator ToNextPhase()
    {
        player.PlayerWait();
        displayText.SetGameOverText(InGameConstantStrings.END_OF_PHASE);
        yield return new WaitForSeconds(4f);

        gameStatus.SetPlayerLivesToPlayerPrefs(lives);
        gameStatus.SetPlayerScoreToPlayerPrefs(score);

        SceneController scene = new SceneController();
        scene.SetCurrentScene(phase.currentPhase);
        scene.GoToNextPhase();
    }

    private string UpdateChallengeText()
    {
        return objChallenge.NumberA + " " + objChallenge.Signal + " " + objChallenge.NumberB;
    }

    // player
    public void HitPlayer()
    {
        DecreaseLivesPlayer();
    }

    public void VerifyIfPlayerIsDead()
    {
        if (player.CheckIfPlayerDie() && playerIsDead == false)
        {
            playerIsDead = true;

            if (playerIsDead == true)
            {
                player.Die();
                new GameOver(displayText, this);
            }
        }
    }

    private void DecreaseLivesPlayer()
    {
        player.DecreaseLives();

        lives = player.lives;
        displayText.SetLiveText(InGameConstantStrings.LIVES + lives);

        StartCoroutine(PlayerLoosingLive());
    }

    IEnumerator PlayerLoosingLive()
    {
        displayText.SetGameOverText(InGameConstantStrings.LOOSING_LIFE);
        yield return new WaitForSeconds(2.0f);
        displayText.SetGameOverText("");
    }
}
