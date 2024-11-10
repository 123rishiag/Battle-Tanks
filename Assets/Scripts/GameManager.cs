using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private TankController playercontroller;

    public WaveSpawner waveSpawner;

    private void Update()
    {
        IsPlayerAlive();
        if(waveSpawner.AreAllWavesFinished())
        {
            Debug.Log("Game Won!");
        }
    }

    public void SetTankController(TankController _tankController)
    {
        playercontroller = _tankController;
        waveSpawner.StartSpawningWaves();
    }

    private bool IsPlayerAlive()
    {
        if(playercontroller != null) 
        {
            if(playercontroller.IsAlive())
            {
                return true; 
            }
            else
            {
                Debug.Log("Game Lost!");
            }
        }
        return false;
    }
}
