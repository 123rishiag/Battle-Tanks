using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankSpawner : MonoBehaviour
{
    private int increaseFactor = 10;

    [System.Serializable]
    public class Tank
    {
        public float movementSpeed;
        public float rotationSpeed;

        public TankTypes tankType;
        public Material color;
    }

    public List<Tank> tankList;

    public TankView tankView;

    public void CreateTank(TankTypes _tankType)
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
            default:
                currentTank = tankList[0];
                break;
        }

        TankModel tankModel = new TankModel(currentTank.movementSpeed * increaseFactor,
            currentTank.rotationSpeed * increaseFactor, currentTank.tankType, currentTank.color);
        TankController tankController = new TankController(tankModel, tankView);
    }
}
