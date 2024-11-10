using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankModel
{
    private TankController tankController;

    public int tankHealth;
    public int currentTankHealth;
    public float movementSpeed;
    public float rotationSpeed;

    public TankTypes tankType;
    public Material tankColor;

    public BulletTypes bulletType;
    public OwnerTypes ownerType;

    public TankModel(int _tankHealth, float _movementSpeed, float _rotationSpeed, TankTypes _tankType, 
        Material _tankColor, BulletTypes _bulletType, OwnerTypes _ownerType)
    {
        tankHealth = _tankHealth;
        currentTankHealth = _tankHealth;
        movementSpeed = _movementSpeed;
        rotationSpeed = _rotationSpeed;
        tankType = _tankType;
        tankColor = _tankColor;
        bulletType = _bulletType;
        ownerType = _ownerType;
    }

    public void SetTankController(TankController _tankController)
    {
        tankController = _tankController;
    }
}
