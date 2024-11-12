using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
    private List<TankController> activeTanks = new List<TankController>();

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

        activeTanks.Clear(); // Clear previous tanks before spawning a new wave

        Wave currentWave = waveList[_waveNumber];
        for (int i = 0; i < currentWave.tankCount; i++)
        {
            TankController spawnedTank = tankSpawner.CreateTank(TankTypes.GreyTank, OwnerTypes.Enemy);
            if (spawnedTank != null)
            {
                activeTanks.Add(spawnedTank);
            }
        }
    }

    private bool IsWaveComplete()
    {
        // Filter out any tanks that have been destroyed
        activeTanks.RemoveAll(tankController => (tankController == null || (!tankController.IsAlive())));

        // Check if there are any active tanks left
        return activeTanks.Count == 0;
    }

    public bool AreAllWavesFinished()
    {
        return waveList.Count == currentWaveIndex;
    }

    public int GetCurrentWave()
    {
        return currentWaveIndex + 1;
    }

    public int GetTotalWave()
    {
        return waveList.Count;
    }

    public int GetEnemyLeft()
    {
        return activeTanks.Count;
    }
}
