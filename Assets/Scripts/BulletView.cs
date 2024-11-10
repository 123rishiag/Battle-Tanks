using UnityEditor.UIElements;
using UnityEngine;

public class BulletView : MonoBehaviour
{
    private BulletController bulletController;

    public Rigidbody rb;

    public MeshRenderer bulletRenderer;

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
                if(!IsSameTankCollision(collision))
                {
                    Destroy(this.gameObject);
                    //Destroy(collision.gameObject);
                }
                break;
            default:
                Destroy(this.gameObject);
                break;
        }
    }

    private bool IsSameTankCollision(Collision collision)
    {
        TankView tankView = collision.gameObject.GetComponent<TankView>();
        if (tankView != null)
        {
            if (bulletController.GetBulletModel().ownerType == tankView.GetTankController().GetTankModel().ownerType)
            {
                return true;
            }
        }
        return false;
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
