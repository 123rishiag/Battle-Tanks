using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankModel
{
    private TankController tankController;

    public float movementSpeed;
    public float rotationSpeed;

    public TankModel(float _movementSpeed, float _rotationSpeed)
    {
        movementSpeed = _movementSpeed;
        rotationSpeed = _rotationSpeed;
    }

    public void SetTankController(TankController _tankController)
    {
        tankController = _tankController;
    }
}
