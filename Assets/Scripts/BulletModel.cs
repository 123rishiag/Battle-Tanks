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

    public GameObject collisionEffect;
    public OwnerTypes ownerType;

    public BulletModel(float _fireSpeed, int _fireDamage, BulletTypes _bulletType, 
        Material _bulletColor, GameObject _collisionEffect, OwnerTypes _ownerType)
    {
        fireSpeed = _fireSpeed;
        fireDamage = _fireDamage;
        bulletType = _bulletType;
        bulletColor = _bulletColor;
        collisionEffect = _collisionEffect;
        ownerType = _ownerType;
    }

    public void SetBulletController(BulletController _bulletController)
    {
        bulletController = _bulletController;
    }
}