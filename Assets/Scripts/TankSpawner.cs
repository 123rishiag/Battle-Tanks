using System.Collections;
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
        Tank playerTank;
        Tank enemyTank;

        switch (_tankType)
        {
            case TankTypes.GreenTank:
                playerTank = tankList[0];
                enemyTank = tankList[3];
                break;
            case TankTypes.BlueTank:
                playerTank = tankList[1];
                enemyTank = tankList[3];
                break;
            case TankTypes.RedTank:
                playerTank = tankList[2];
                enemyTank = tankList[3];
                break;
            default:
                playerTank = tankList[0];
                enemyTank = tankList[3];
                break;
        }

        TankModel playerTankModel = new TankModel(playerTank.tankHealth, playerTank.movementSpeed * tankSpeedFactor,
            playerTank.rotationSpeed * tankSpeedFactor, playerTank.tankType, playerTank.tankColor, 
            playerTank.bulletType, _ownerType);
        TankController playerTankController = new PlayerTankController(playerTankModel, tankView);

        TankModel enemyTankModel = new TankModel(enemyTank.tankHealth, enemyTank.movementSpeed * tankSpeedFactor,
            enemyTank.rotationSpeed * tankSpeedFactor, enemyTank.tankType, enemyTank.tankColor,
            enemyTank.bulletType, OwnerTypes.Enemy);
        TankController enemyTankController = new EnemyTankController(enemyTankModel, tankView,
            playerTankController.GetTankView().gameObject.transform);
    }
}
