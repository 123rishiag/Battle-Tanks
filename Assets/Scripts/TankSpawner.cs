using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankSpawner : MonoBehaviour
{
    private int tankSpeedFactor = 100;
    private Transform playerTransform;

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

    public TankController CreateTank(TankTypes _tankType, OwnerTypes _ownerType)
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

        TankController tankController;
        switch(_ownerType)
        {
            case OwnerTypes.Player:
                tankController = CreatePlayerTank(tankModel, tankView);
                break;
            case OwnerTypes.Enemy:
                tankController = CreateEnemyTank(tankModel, tankView);
                break;
            default:
                tankController = CreatePlayerTank(tankModel, tankView);
                break;
        }

        return tankController;
    }

    private TankController CreatePlayerTank(TankModel _tankModel, TankView _tankView)
    {
        TankController tankController = new PlayerTankController(_tankModel, _tankView);
        playerTransform = tankController.GetTankView().gameObject.transform;
        return tankController;
    }

    private TankController CreateEnemyTank(TankModel _tankModel, TankView _tankView)
    {
        TankController tankController = new EnemyTankController(_tankModel, _tankView, playerTransform);
        return tankController;
    }
}
