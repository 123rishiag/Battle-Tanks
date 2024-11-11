using System;
using UnityEditor.UIElements;
using UnityEngine;

public class BulletView : MonoBehaviour
{
    private BulletController bulletController;

    public Rigidbody rb;

    public MeshRenderer bulletRenderer;

    public float bulletLifetime = 10f;
    private bool hasExploded = false;
    private float countDown;

    private void Start()
    {
        countDown = bulletLifetime;
    }

    private void Update()
    {
        countDown -= Time.deltaTime;
        if(countDown <= 0f && !hasExploded)
        {
            Explode();
            hasExploded = true;
        }    
    }

    private void Explode()
    {
        Instantiate(bulletController.GetBulletModel().collisionEffect, transform.position, transform.rotation);
        Destroy(this.gameObject);
    }

    void OnCollisionEnter(Collision collision)
    {
        switch (collision.gameObject.tag)
        {
            case "Environment":
                Explode();
                break;
            case "Bullet":
                Explode();
                break;
            case "Tank":
                ProcessTankCollision(collision);
                break;
            default:
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
                tankView.GetTankController().TakeDamage(bulletController.GetBulletModel().fireDamage);
                Explode();
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
