using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameHudController : MonoBehaviour
{
    public GameManager gameManager;

    public TMP_Text tankHealthText;
    public TMP_Text waveNumberText;
    public TMP_Text enemyLeftText;
    public Button pauseButton;

    private void Start()
    {
        // Adding listeners to the buttons
        pauseButton.onClick.AddListener(OnPauseButtonPressed);
    }

    public void SetTankHealthText(int _health)
    {
        tankHealthText.text = "Health: " + _health;
    }

    public void SetWaveNumberText(int _currentWaveNumber, int _totalWaveNumber)
    {
        waveNumberText.text = "Wave: " + _currentWaveNumber + "/" + _totalWaveNumber;
    }

    public void SetEnemyLeftText(int _enemyLeft)
    {
        enemyLeftText.text = "Enemy Left: " + _enemyLeft;
    }

    public void OnPauseButtonPressed()
    {
        gameManager.PauseGame();
    }
}
