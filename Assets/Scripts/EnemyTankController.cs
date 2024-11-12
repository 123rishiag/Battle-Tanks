using UnityEngine;

public class EnemyTankController : TankController
{
    private float lastShootTime;

    public EnemyTankController(TankModel _tankModel, TankView _tankView, Transform _playerTransform)
        : base(_tankModel, _tankView, _playerTransform) { }

    public override bool CheckConditionsSatisfied(Vector3 _randomPosition, out RaycastHit _hit)
    {
        if (Vector3.Distance(_randomPosition, playerTransform.position) >= tankView.minSpawnRadius)
        {
            if (Physics.Raycast(_randomPosition + Vector3.up * 10f, Vector3.down, out _hit))
            {
                return true;
            }
        }
        _hit = default;
        return false;
    }

    public override void Move()
    {
        RaycastHit hit;
        Vector3 moveDirection = playerTransform.position - tankView.transform.position;
        Vector3 normalizedDirection = moveDirection.normalized;

        if (Physics.Raycast(tankView.transform.position, normalizedDirection, out hit, tankView.enemyThresholdDistance))
        {
            Vector3 obstacleAvoidanceDirection = Vector3.Cross(hit.normal, Vector3.up).normalized;
            MoveInDirection(obstacleAvoidanceDirection);
        }
        else
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

    public override void TakeDamage(int _damage)
    {
        tankModel.currentTankHealth -= _damage;
        if (tankModel.currentTankHealth <= 0)
        {
            tankView.Explode();
        }
    }
}
