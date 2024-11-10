using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTankController : TankController
{
    public PlayerTankController(TankModel _tankModel, TankView _tankView) : base(_tankModel, _tankView)
    {

    }

    public override void Move()
    {
        Vector3 moveDirection = tankView.transform.forward * tankView.movement;
        MoveInDirection(moveDirection);
    }

    public override void Rotate()
    {
        Vector3 rotateDirection = new Vector3(0f, tankView.rotation, 0f);
        RotateTowardsDirection(rotateDirection);
    }

    public override void Aim()
    {
        if (tankView.aim)
        {
            // Get the mouse position in screen space
            Vector3 mousePosition = Input.mousePosition;

            // Convert mouse position to a world ray from the camera
            Ray ray = Camera.main.ScreenPointToRay(mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                // Aim at the point where the ray intersects with a collider in the scene
                AimTowardsTarget(hit.point);
            }
        }
    }

    public override void Shoot()
    {
        if (tankView.shoot)
        {
            ShootTowardsTarget();
        }
    }

    public override void Die()
    {
        tankModel.currentTankHealth = 0;
    }
}
