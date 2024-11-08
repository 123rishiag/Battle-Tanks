﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletSpawner : MonoBehaviour
{
    [System.Serializable]
    public class Bullet
    {
        public float bulletSpeed;
        public float bulletDamage;

        public BulletTypes bulletType;
        public Material color;
    }

    public List<Bullet> bulletList;

    public BulletView bulletView;

    public void FireBullet(BulletTypes _bulletType, Transform _firePoint)
    {
        Bullet currentBullet;

        switch (_bulletType)
        {
            case BulletTypes.Normal:
                currentBullet = bulletList[0];
                break;
            case BulletTypes.Explosion:
                currentBullet = bulletList[1];
                break;
            case BulletTypes.Piercing:
                currentBullet = bulletList[2];
                break;
            default:
                currentBullet = bulletList[0];
                break;
        }

        BulletModel bulletModel = new BulletModel(currentBullet.bulletSpeed,
            currentBullet.bulletDamage, currentBullet.bulletType, currentBullet.color);
        BulletController bulletController = new BulletController(bulletModel, bulletView, _firePoint);
    }
}