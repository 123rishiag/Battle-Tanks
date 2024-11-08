﻿using UnityEditor.UIElements;
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
            default:
                break;
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
