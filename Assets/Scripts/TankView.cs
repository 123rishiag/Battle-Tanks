using System.Collections;
using UnityEngine;

public class TankView : MonoBehaviour
{
    private TankController tankController;
    private Camera mainCamera;
    private Vector3 cameraPosition = new Vector3(0f, 5f, -8f);

    [HideInInspector]
    public float movement;
    [HideInInspector]
    public float rotation;
    [HideInInspector]
    public bool aim;
    [HideInInspector]
    public bool shoot;

    public float minSpawnRadius = 20f;
    public float maxSpawnRadius = 30f;
    public float enemyThresholdDistance = 15.0f;
    public float enemyShootInterval = 2.0f;
    public float aimSpeed = 5f;

    public GameObject tankExplosionEffect;

    public Rigidbody rb;
    public MeshRenderer[] childs;

    // Start is called before the first frame update
    void Start()
    {
        mainCamera = Camera.main;
        if (tankController.GetTankModel().ownerType == OwnerTypes.Player)
        {
            mainCamera.transform.SetParent(transform);
            mainCamera.transform.localPosition = cameraPosition;
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

    public void Explode()
    {
        Instantiate(tankExplosionEffect, transform.position, transform.rotation);
        SoundManager.Instance.PlayEffect(SoundType.TankExplosion);
        Destroy(this.gameObject);
    }

    private IEnumerator ShakeScreen(float _duration, float _magnitude)
    {
        Vector3 originalPosition = mainCamera.transform.localPosition;
        float elapsed = 0.0f;

        // Variables for controlling shake behavior
        float noiseFrequency = 10.0f;  // Controls the speed of Perlin noise oscillation

        while (elapsed < _duration)
        {
            // Calculate decay factor to reduce magnitude over time
            float decayFactor = Mathf.Lerp(_magnitude, 0, elapsed / _duration);

            // Generate Perlin noise-based offsets
            float x = (Mathf.PerlinNoise(Time.time * noiseFrequency, 0) * 2 - 1) * decayFactor;
            float y = (Mathf.PerlinNoise(0, Time.time * noiseFrequency) * 2 - 1) * decayFactor;

            // Apply offset to original position
            mainCamera.transform.localPosition = new Vector3(originalPosition.x + x, originalPosition.y + y, originalPosition.z);

            elapsed += Time.deltaTime;
            yield return null;
        }

        mainCamera.transform.localPosition = originalPosition;
        SoundManager.Instance.PlayEffect(SoundType.TankExplosion);
    }

    public void RunShakeScreenCoroutine()
    {
        StartCoroutine(ShakeScreen(1f, 1f));
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
        for (int i = 0; i < childs.Length; i++)
        {
            childs[i].material = _color;
        }
    }

    public TankController GetTankController()
    {
        return tankController;
    }
}
