using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static TankSpawner;

public class TankController
{
    private TankModel tankModel;
    private TankView tankView;

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

    public void Move(float _movement, float _movementSpeed)
    {
        rb.velocity = tankView.transform.forward * _movement * _movementSpeed * Time.deltaTime;
    }

    public void Rotate(float _movement, float _rotate, float _rotateSpeed)
    {
        // Reverse rotation direction if moving backwards
        float rotationMultiplier = (_movement < 0) ? -1 : 1;

        Vector3 vector = new Vector3(0f, _rotate * _rotateSpeed * rotationMultiplier, 0f);
        Quaternion deltaRotation = Quaternion.Euler(vector * Time.deltaTime);
        rb.MoveRotation(rb.rotation * deltaRotation);
    }

    public void Shoot()
    {
        GameObject spawnerObject = GameObject.Find("BulletSpawner");
        BulletSpawner bulletSpawner = spawnerObject.GetComponent<BulletSpawner>();

        Transform firePoint = tankView.childs[3].transform.Find("FirePoint");
        bulletSpawner.FireBullet(tankModel.bulletType, firePoint);
    }

    public void Aim()
    {
        // Get the mouse position in screen space
        Vector3 mousePosition = Input.mousePosition;

        // Convert mouse position to a world ray from the camera
        Ray ray = Camera.main.ScreenPointToRay(mousePosition);

        // Use a raycast to detect objects or determine a point in 3D space to aim at
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit))
        {
            // Get the point where the ray intersects with a collider in the scene
            Vector3 targetPoint = hit.point;

            // Get the Turret and FirePoint Transforms
            Transform turretTransform = tankView.childs[3].transform;

            // Calculate the direction to the target point from the tank's aiming point
            Vector3 aimDirection = (targetPoint - turretTransform.position);

            // Y-Axis Threshold (e.g., do not rotate beyond a certain Y direction value)
            if (aimDirection.y > tankView.aimYThreshold)
            {
                aimDirection.y = tankView.aimYThreshold; // Clamp the Y value to the threshold
            }
            else if (aimDirection.y < -tankView.aimYThreshold)
            {
                aimDirection.y = -tankView.aimYThreshold; // Clamp the Y value for downward aiming
            }

            // Re-normalize the aim direction after clamping
            aimDirection.Normalize();

            // Optionally rotate the child's transform to face the target
            Quaternion targetRotation = Quaternion.LookRotation(aimDirection);

            tankView.childs[3].transform.rotation = Quaternion.Slerp(turretTransform.rotation, 
                targetRotation, Time.deltaTime * tankView.aimSpeed);
        }
    }

    public TankModel GetTankModel()
    {
        return tankModel;
    }
}
