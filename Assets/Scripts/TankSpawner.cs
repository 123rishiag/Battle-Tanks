﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankSpawner : MonoBehaviour
{
    private int tankSpeedFactor = 100;

    [System.Serializable]
    public class Tank
    {
        public int tankHealth;
        public float movementSpeed;
        public float rotationSpeed;

        public TankTypes tankType;
        public Material tankColor;

        public BulletTypes bulletType;
    }

    public List<Tank> tankList;

    public TankView tankView;

    public void CreateTank(TankTypes _tankType, OwnerTypes _ownerType)
    {
        Tank currentTank;

        switch (_tankType)
        {
            case TankTypes.GreenTank:
                currentTank = tankList[0];
                break;
            case TankTypes.BlueTank:
                currentTank = tankList[1];
                break;
            case TankTypes.RedTank:
                currentTank = tankList[2];
                break;
            case TankTypes.GreyTank:
                currentTank = tankList[3];
                break;
            default:
                currentTank = tankList[0];
                break;
        }

        TankModel tankModel = new TankModel(currentTank.tankHealth, currentTank.movementSpeed * tankSpeedFactor,
            currentTank.rotationSpeed * tankSpeedFactor, currentTank.tankType, currentTank.tankColor, 
            currentTank.bulletType, _ownerType);
        TankController tankController = new TankController(tankModel, tankView);
    }
}
