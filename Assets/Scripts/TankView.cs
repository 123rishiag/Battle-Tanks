﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Analytics;

public class TankView : MonoBehaviour
{
    private TankController tankController;

    public float movement;
    public float rotation;
    public bool aim;
    public bool shoot;

    public float aimSpeed = 5f;
    public float aimYThreshold = 0.2f;

    public Rigidbody rb;

    public MeshRenderer[] childs;

    // Start is called before the first frame update
    void Start()
    {
        if (tankController.GetTankModel().ownerType == OwnerTypes.Player)
        {
            GameObject cam = GameObject.Find("Main Camera");
            cam.transform.SetParent(transform);
            cam.transform.position = new Vector3(0f, 3f, -4f);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (tankController.GetTankModel().ownerType == OwnerTypes.Player)
        {
            HandleInput();
        }
        PerformAction();
    }

    private void HandleInput()
    {
        movement = Input.GetAxis("Vertical");
        rotation = Input.GetAxis("Horizontal");
        aim = Input.GetMouseButton(1);
        shoot = Input.GetMouseButtonDown(0);
    }

    private void PerformAction()
    {
        tankController.Move();
        tankController.Rotate();
        tankController.Aim();
        tankController.Shoot();
    }

    public void SetTankController(TankController _tankController)
    {
        tankController = _tankController;
    }

    public Rigidbody GetRigidbody() { return rb; }

    public bool Shoot()
    {
        return shoot;
    }

    public void ChangeColor(Material _color)
    {
        for(int i = 0; i < childs.Length; i++)
        {
            childs[i].material = _color;
        }
    }

    public TankController GetTankController()
    {
        return tankController;
    }
}
