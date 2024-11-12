using UnityEngine;

public class PlayerTankController : TankController
{
    public PlayerTankController(TankModel _tankModel, TankView _tankView, Transform _playerTransform)
        : base(_tankModel, _tankView, _playerTransform) { }

    public override bool CheckConditionsSatisfied(Vector3 _randomPosition, out RaycastHit _hit)
    {
        if (Physics.Raycast(_randomPosition, Vector3.down, out _hit))
        {
            return true;
        }
        _hit = default;
        return false;
    }

    public override void Move()
    {
        if (tankView.movement != 0)
        {
            SoundManager.Instance.PlayMusic(SoundType.EngineDrive);
        }
        else
        {
            SoundManager.Instance.PlayMusic(SoundType.EngineIdle);
        }
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

    public override void TakeDamage(int _damage)
    {
        tankModel.currentTankHealth -= _damage;
        tankView.RunShakeScreenCoroutine();
        if (tankModel.currentTankHealth <= 0)
        {
            tankModel.currentTankHealth = 0;
            SoundManager.Instance.PlayEffect(SoundType.TankExplosion);
        }
    }
}
