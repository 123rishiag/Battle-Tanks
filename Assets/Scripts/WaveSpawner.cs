using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static TankSpawner;

public class WaveSpawner : MonoBehaviour
{
    private int currentWaveIndex = 0;
    public TankSpawner tankSpawner;

    [System.Serializable]
    public class Wave
    {
        public int tankCount;
    }

    public List<Wave> waveList;

    public void StartSpawningWaves()
    {
        StartCoroutine(SpawnWavesCoroutine());
    }

    private IEnumerator SpawnWavesCoroutine()
    {
        while (currentWaveIndex < waveList.Count)
        {
            CreateWave(currentWaveIndex);
            yield return new WaitUntil(() => IsWaveComplete());
            currentWaveIndex++;
        }
    }

    public void CreateWave(int _waveNumber)
    {
        if (_waveNumber < 0 || _waveNumber >= waveList.Count)
        {
            Debug.LogWarning("Wave number out of range");
            return;
        }

        Wave currentWave = waveList[_waveNumber];
        for (int i = 0; i < currentWave.tankCount; i++)
        {
            tankSpawner.CreateTank(TankTypes.GreyTank, OwnerTypes.Enemy);
        }
    }

    private bool IsWaveComplete()
    {
        // Implement your logic to determine if the wave is complete.
        // For example, check if all tanks are destroyed.
        // This is just a placeholder and should be replaced with your actual completion condition.
        return false;
    }
}
