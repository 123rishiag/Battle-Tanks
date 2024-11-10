using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletModel
{
    private BulletController bulletController;

    public float fireSpeed;
    public int fireDamage;

    public BulletTypes bulletType;
    public Material bulletColor;

    public OwnerTypes ownerType;

    public BulletModel(float _fireSpeed, int _fireDamage, BulletTypes _bulletType, Material _bulletColor, OwnerTypes _ownerType)
    {
        fireSpeed = _fireSpeed;
        fireDamage = _fireDamage;
        bulletType = _bulletType;
        bulletColor = _bulletColor;
        ownerType = _ownerType;
    }

    public void SetBulletController(BulletController _bulletController)
    {
        bulletController = _bulletController;
    }
}