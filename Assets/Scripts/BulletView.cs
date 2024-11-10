using UnityEditor.UIElements;
using UnityEngine;

public class BulletView : MonoBehaviour
{
    private BulletController bulletController;

    public Rigidbody rb;

    public MeshRenderer bulletRenderer;

    public float bulletLifetime = 10f;

    void OnCollisionEnter(Collision collision)
    {
        switch (collision.gameObject.tag)
        {
            case "Environment":
                Destroy(this.gameObject);
                break;
            case "Bullet":
                Destroy(this.gameObject);
                break;
            case "Tank":
                ProcessTankCollision(collision);
                break;
            default:
                Destroy(this.gameObject);
                break;
        }
    }

    private void ProcessTankCollision(Collision collision)
    {
        TankView tankView = collision.gameObject.GetComponent<TankView>();
        if (tankView != null)
        {
            if (bulletController.GetBulletModel().ownerType != tankView.GetTankController().GetTankModel().ownerType)
            {
                Destroy(this.gameObject);
                tankView.GetTankController().TakeDamage(bulletController.GetBulletModel().fireDamage);
            }
        }
    }

    public void ChangeColor(Material _color)
    {
        bulletRenderer.material = _color;
    }

    public void SetBulletController(BulletController _bulletController)
    {
        bulletController = _bulletController;
    }

    public Rigidbody GetRigidbody() { return rb; }
}
