using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankModel
{
    private TankController tankController;

    public float movementSpeed;
    public float rotationSpeed;

    public TankTypes tankType;
    public Material color;

    public TankModel(float _movementSpeed, float _rotationSpeed, TankTypes _tankType, Material _color)
    {
        movementSpeed = _movementSpeed;
        rotationSpeed = _rotationSpeed;
        tankType = _tankType;
        color = _color;
    }

    public void SetTankController(TankController _tankController)
    {
        tankController = _tankController;
    }
}
