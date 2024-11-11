using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static TankSpawner;

public class EnemyTankController : TankController
{
    private Transform playerTransform;
    private float lastShootTime;

    public EnemyTankController(TankModel _tankModel, TankView _tankView, Transform _playerTransform) : base(_tankModel, _tankView)
    {
        playerTransform = _playerTransform;
    }

    public override void Move()
    {
        Vector3 moveDirection = playerTransform.position - tankView.transform.position;
        if (Vector3.Distance(playerTransform.position, tankView.transform.position) > tankView.enemyThresholdDistance)
        {
            MoveInDirection(moveDirection);
        }
    }

    public override void Rotate()
    {
        Vector3 rotateDirection = new Vector3(0f, (playerTransform.position - tankView.transform.position).y, 0f);
        RotateTowardsDirection(rotateDirection);
    }

    public override void Aim()
    {
        AimTowardsTarget(playerTransform.position);
    }

    public override void Shoot()
    {
        // Automatically shoot at intervals
        if (Time.time - lastShootTime >= tankView.enemyShootInterval)
        {
            ShootTowardsTarget();
            lastShootTime = Time.time;
        }
    }

    public override void Die()
    {
        tankView.Explode();
    }
}
