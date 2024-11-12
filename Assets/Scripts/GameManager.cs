using System.Collections;
using TMPro;
using UnityEditor.VersionControl;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private TankController playercontroller;
    private bool isGameOver = false;

    public WaveSpawner waveSpawner;

    public GameObject controlsMenu;
    public GameObject gameOverMenu;
    public GameObject gameHud;

    private GameHudController gameHudController;

    private TMP_Text gameOverText;

    private void Start()
    {
        if (gameOverMenu != null)
        {
            gameOverText = gameOverMenu.GetComponentInChildren<TMP_Text>();
            gameOverText.text = "abcd";
        }
        gameOverMenu.SetActive(false);
    }

    private void Update()
    {
        UpdateUI();
        GameWon();
        GameLost();
    }

    private void UpdateUI()
    {
        if (gameHudController != null)
        {
            gameHudController.SetTankHealthText(playercontroller.GetTankModel().currentTankHealth);
            gameHudController.SetWaveNumberText(waveSpawner.GetCurrentWave(), waveSpawner.GetTotalWave());
            gameHudController.SetEnemyLeftText(waveSpawner.GetEnemyLeft());
        }
    }

    public void SetTankController(TankController _tankController)
    {
        // Resuming the game
        Time.timeScale = 1f;

        playercontroller = _tankController;

        // Starting Game Hud Elements
        gameHudController = gameHud.GetComponent<GameHudController>();
        gameHud.SetActive(true);

        // Starting Wave Spawns
        waveSpawner.StartSpawningWaves();
    }

    private void GameWon()
    {
        if (waveSpawner.AreAllWavesFinished() && !isGameOver)
        {
            ShowGameOver("Game Won!");
        }
    }

    private void GameLost()
    {
        if (playercontroller != null && !playercontroller.IsAlive() && !isGameOver)
        {
            ShowGameOver("Game Lost!");
        }
    }

    private void ShowGameOver(string _message)
    {
        isGameOver = true;
        if (gameOverMenu != null && gameOverText != null)
        {
            gameOverMenu.SetActive(true);
            gameOverText.text = _message;

            SoundManager.Instance.PlayMusic(SoundType.GameOver, false);

            StartCoroutine(HideGameOverMenuAfterDelay(5f));
            DisablePlayer();
        }
    }

    private void DisablePlayer()
    {
        Camera mainCamera = Camera.main;
        mainCamera.transform.SetParent(null);
        playercontroller.GetTankView().gameObject.SetActive(false);
    }

    private IEnumerator HideGameOverMenuAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        if (gameOverMenu != null)
        {
            gameOverText.text = "";

            // Pausing the game
            Time.timeScale = 0f;
        }
    }

    public void MainMenu()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(0);
        SoundManager.Instance.PlayEffect(SoundType.ButtonClick);
        SoundManager.Instance.PlayMusic(SoundType.BackgroundMusic);
    }

    public void ControlsMenu()
    {
        SoundManager.Instance.PlayEffect(SoundType.ButtonClick);
        controlsMenu.SetActive(true);
    }

    public void PauseGame()
    {
        if (Time.timeScale == 1f)
        {
            SoundManager.Instance.PlayEffect(SoundType.GamePause);
            SoundManager.Instance.MuteGame(true);
            Time.timeScale = 0f;
        }
        else
        {
            Time.timeScale = 1f;
            SoundManager.Instance.MuteGame(false);
            SoundManager.Instance.PlayEffect(SoundType.GameStart);
        }
    }

    public void QuitGame()
    {
        SoundManager.Instance.PlayEffect(SoundType.ButtonQuit);
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
    Application.Quit();
#endif
    }
}
