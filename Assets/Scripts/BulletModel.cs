using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletModel
{
    private BulletController bulletController;

    public float fireSpeed;
    public float fireDamage;

    public BulletTypes bulletType;
    public Material bulletColor;

    public BulletModel(float _fireSpeed, float _fireDamage, BulletTypes _bulletType, Material _bulletColor)
    {
        fireSpeed = _fireSpeed;
        fireDamage = _fireDamage;
        bulletType = _bulletType;
        bulletColor = _bulletColor;
    }

    public void SetBulletController(BulletController _bulletController)
    {
        bulletController = _bulletController;
    }
}