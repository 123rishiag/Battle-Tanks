using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankView : MonoBehaviour
{
    private TankController tankController;

    private float movement;
    private float rotation;
    private bool aim;
    private bool shoot;

    public float aimSpeed = 5f;
    public float aimYThreshold = 0.2f;

    public Rigidbody rb;

    public MeshRenderer[] childs;

    // Start is called before the first frame update
    void Start()
    {
        GameObject cam = GameObject.Find("Main Camera");
        cam.transform.SetParent(transform);
        cam.transform.position = new Vector3(0f, 3f, -4f);
    }

    // Update is called once per frame
    void Update()
    {
        HandleInput();

        if(movement != 0)
        {
            tankController.Move(movement, tankController.GetTankModel().movementSpeed);
        }

        if(rotation != 0)
        {
            tankController.Rotate(rotation, tankController.GetTankModel().rotationSpeed);
        }

        if (aim)
        {
            tankController.Aim();
        }

        if (shoot)
        {
            tankController.Shoot();
        }
    }

    private void HandleInput()
    {
        movement = Input.GetAxis("Vertical");
        rotation = Input.GetAxis("Horizontal");
        shoot = Input.GetMouseButtonDown(0);
        aim = Input.GetMouseButton(1);
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

}
