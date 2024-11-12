using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameHudController : MonoBehaviour
{
    public TMP_Text tankHealthText;
    public TMP_Text waveNumberText;
    public TMP_Text enemyLeftText;

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

    public void PauseGame()
    {
        if (Time.timeScale == 1f)
        {
            SoundManager.Instance.PlayEffect(SoundType.GamePause);
            Time.timeScale = 0f;
        }
        else
        {
            Time.timeScale = 1f;
            SoundManager.Instance.PlayEffect(SoundType.GameStart);
        }
    }
}
