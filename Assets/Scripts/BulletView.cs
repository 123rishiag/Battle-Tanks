using UnityEngine;

public class BulletView : MonoBehaviour
{
    private BulletController bulletController;

    public Rigidbody rb;

    public MeshRenderer bulletRenderer;

    public void SetBulletController(BulletController _bulletController)
    {
        bulletController = _bulletController;
    }

    public Rigidbody GetRigidbody() { return rb; }

    public void ChangeColor(Material _color)
    {
        bulletRenderer.material = _color;
    }
}
