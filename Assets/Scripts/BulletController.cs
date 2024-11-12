using UnityEngine;

public class BulletController
{
    private BulletModel bulletModel;
    private BulletView bulletView;

    private Rigidbody rb;

    public BulletController(BulletModel _bulletModel, BulletView _bulletView, Transform _firePoint)
    {
        bulletModel = _bulletModel;
        bulletView = GameObject.Instantiate<BulletView>(_bulletView, _firePoint.position, _firePoint.rotation);
        rb = bulletView.GetRigidbody();
        bulletModel.SetBulletController(this);
        bulletView.SetBulletController(this);
        bulletView.ChangeColor(bulletModel.bulletColor);

        Fire(bulletModel.fireSpeed, _firePoint);
    }

    public void Fire(float _fireSpeed, Transform _firePoint)
    {
        rb.velocity = _firePoint.forward * _fireSpeed * Time.deltaTime;
        SoundManager.Instance.PlayEffect(SoundType.BulletShoot);
    }

    public BulletModel GetBulletModel()
    {
        return bulletModel;
    }
}
