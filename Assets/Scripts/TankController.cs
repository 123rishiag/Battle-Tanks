using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static TankSpawner;

public abstract class TankController
{
    protected TankModel tankModel;
    protected TankView tankView;

    private Rigidbody rb;

    public TankController(TankModel _tankModel, TankView _tankView)
    {
        tankModel = _tankModel;
        tankView = GameObject.Instantiate<TankView>(_tankView);
        rb = tankView.GetRigidbody();
        tankModel.SetTankController(this);
        tankView.SetTankController(this);
        tankView.ChangeColor(tankModel.tankColor);
    }

    public abstract void Move();
    protected void MoveInDirection(Vector3 _direction)
    {
        // Normalize the direction to ensure consistent speed
        Vector3 normalizedDirection = _direction.normalized;

        // Move in the given direction
        rb.velocity = normalizedDirection * tankModel.movementSpeed * Time.deltaTime;
    }

    public abstract void Rotate();
    protected void RotateTowardsDirection(Vector3 _direction)
    {
        float rotationMultiplier = (tankView.movement < 0) ? -1 : 1;

        // Determine the target rotation based on the given direction
        Quaternion targetRotation = Quaternion.Euler(_direction * tankModel.rotationSpeed * rotationMultiplier * Time.deltaTime);

        // Smoothly rotate towards the target direction
        rb.MoveRotation(rb.rotation * targetRotation);
    }

    public abstract void Aim();
    protected virtual void AimTowardsTarget(Vector3 _targetPoint)
    {
        // Get the turret and fire point transforms
        Transform turretTransform = tankView.childs[3].transform;

        // Calculate the direction to the target point from the tank's aiming point
        Vector3 aimDirection = (_targetPoint - turretTransform.position).normalized;

        // Smoothly rotate the turret towards the target without changing the X-axis rotation
        Quaternion targetRotation = Quaternion.LookRotation(aimDirection);
        Vector3 targetEulerAngles = targetRotation.eulerAngles;

        // Preserve the current X-axis rotation of the turret
        targetEulerAngles.x = turretTransform.rotation.eulerAngles.x;

        // Apply the modified rotation
        turretTransform.rotation = Quaternion.Slerp(turretTransform.rotation, Quaternion.Euler(targetEulerAngles), Time.deltaTime * tankView.aimSpeed);
    }

    public abstract void Shoot();
    protected virtual void ShootTowardsTarget()
    {
        // Locate the BulletSpawner
        GameObject spawnerObject = GameObject.Find("BulletSpawner");
        BulletSpawner bulletSpawner = spawnerObject.GetComponent<BulletSpawner>();

        // Find the FirePoint on the tank
        Transform firePoint = tankView.childs[3].transform.Find("FirePoint");

        // Fire the bullet with specified bullet type and owner type
        bulletSpawner.FireBullet(tankModel.bulletType, tankModel.ownerType, firePoint);
    }

    public TankModel GetTankModel()
    {
        return tankModel;
    }

    public TankView GetTankView()
    {
        return tankView;
    }
}
