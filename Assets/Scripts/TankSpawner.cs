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

    // Start is called before the first frame update
    void Start()
    {
    }

    public void CreateTank(TankTypes _tankType)
    {
        Tank currentTank;

        if (_tankType == TankTypes.GreenTank)
        {
            currentTank = tankList[0];
        }
        else if (_tankType == TankTypes.BlueTank)
        {
            currentTank = tankList[1];
        }
        else if (_tankType == TankTypes.RedTank)
        {
            currentTank = tankList[2];
        }
        else
        {
            currentTank = tankList[0];
        }

        TankModel tankModel = new TankModel(currentTank.movementSpeed * increaseFactor,
            currentTank.rotationSpeed * increaseFactor, currentTank.tankType, currentTank.color);
        TankController tankController = new TankController(tankModel, tankView);
    }
}
