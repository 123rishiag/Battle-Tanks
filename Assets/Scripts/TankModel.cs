using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankModel
{
    private TankController tankController;

    public float movementSpeed;
    public float rotationSpeed;

    public TankTypes tankType;
    public Material tankColor;

    public BulletTypes bulletType;

    public TankModel(float _movementSpeed, float _rotationSpeed, TankTypes _tankType, Material _tankColor, BulletTypes _bulletType)
    {
        movementSpeed = _movementSpeed;
        rotationSpeed = _rotationSpeed;
        tankType = _tankType;
        tankColor = _tankColor;
        bulletType = _bulletType;
}

    public void SetTankController(TankController _tankController)
    {
        tankController = _tankController;
    }
}
