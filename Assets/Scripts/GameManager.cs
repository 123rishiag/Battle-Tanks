using System.Collections;
using TMPro;
using UnityEditor.VersionControl;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private TankController playercontroller;

    public WaveSpawner waveSpawner;

    public GameObject gameOverMenu;
    private TMP_Text gameOverText;

    private void Start()
    {
        if (gameOverMenu != null)
        {
            gameOverText = gameOverMenu.GetComponentInChildren<TMP_Text>();
        }
        gameOverMenu.SetActive(false);
    }

    private void Update()
    {
        GameWon();
        GameLost();
    }

    public void SetTankController(TankController _tankController)
    {
        playercontroller = _tankController;
        waveSpawner.StartSpawningWaves();
    }

    private void GameWon()
    {
        if (waveSpawner.AreAllWavesFinished())
        {
            ShowGameOver("Game Won!");
        }
    }

    private void GameLost()
    {
        if (playercontroller != null && !playercontroller.IsAlive())
        {
            ShowGameOver("Game Lost!");
        }
    }

    private void ShowGameOver(string message)
    {
        if (gameOverMenu != null && gameOverText != null)
        {
            gameOverMenu.SetActive(true);
            gameOverText.text = message;
            StartCoroutine(HideGameOverMenuAfterDelay(5f));
        }
    }

    private IEnumerator HideGameOverMenuAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        if (gameOverText != null)
        {
            gameOverText.text = "";
        }
    }
}
