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
        tankView.ChangeColor(tankModel.color);
    }

    public void Move(float movement, float movementSpeed)
    {
        rb.velocity = tankView.transform.forward * movement * movementSpeed * Time.deltaTime;
    }

    public void Rotate(float rotate, float rotateSpeed)
    {
        Vector3 vector = new Vector3(0f, rotate * rotateSpeed, 0f);
        Quaternion deltaRotation = Quaternion.Euler(vector * Time.deltaTime);
        rb.MoveRotation(rb.rotation * deltaRotation);
    }

    public void Shoot()
    {
        GameObject spawnerObject = GameObject.Find("BulletSpawner");
        BulletSpawner bulletSpawner = spawnerObject.GetComponent<BulletSpawner>();

        Transform firePoint = tankView.transform.Find("FirePoint");
        bulletSpawner.FireBullet(BulletTypes.Normal, firePoint);
    }

    public TankModel GetTankModel()
    {
        return tankModel;
    }
}
