using System;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.InputSystem.iOS;

public class Player : MonoBehaviour
{
    [Header("Tank")]
    [SerializeField] private float speed;
    [SerializeField] private float rotationSpeed;
    [SerializeField] private int salud;

    [Header("Turret")]
    [SerializeField] private Transform turret;
    [SerializeField] private float turretRotationSpeed;
    private Rigidbody2D rb;
    private float h, v;

    [Header("Bullets")]
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private Transform bulletSpawnPoint;

    public int Salud { get => salud; set => salud = value; }

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        h = Input.GetAxisRaw("Horizontal");
        v = Input.GetAxisRaw("Vertical");
        rb.linearVelocity = transform.up * speed * v;
        RotateTank();
        RotateTurret();
        Shoot();
    }

    private void Shoot()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Instantiate(bulletPrefab, bulletSpawnPoint.position, bulletSpawnPoint.rotation);
        }
    }

    private void RotateTank()
    {
        transform.Rotate(-Vector3.forward * h * rotationSpeed * Time.deltaTime);
    }

    private void RotateTurret()
    {
        if (Input.GetKey(KeyCode.E))
        {
            turret.transform.Rotate(-Vector3.forward * turretRotationSpeed * Time.deltaTime);
        }
        else if (Input.GetKey(KeyCode.Q))
        {
            turret.transform.Rotate(Vector3.forward * turretRotationSpeed * Time.deltaTime);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision != null)
        {
            if (collision.gameObject.CompareTag("Shell"))
            {
                Destroy(collision.gameObject);
                salud -= 20;
                if (salud <= 0)
                {
                    Debug.Log("Mori");
                }
            }
        }
    }

    /*private void DeliminarMovimiento()
    {
        float xClamped = Mathf.Clamp(transform.position.x, -8.4f, 8.4f);
        float yClamped = Mathf.Clamp(transform.position.y, -4.5f, 4.5f);
        transform.position = new Vector3(xClamped, yClamped, 0);
    }

    private void MovimientoCinematico()
    {
        Vector2 movimiento = new Vector2(h, v).normalized;
        transform.Translate(movimiento * speed * Time.deltaTime);
    }*/

    //-------------------------------------------------------------------------------------------------------------

    /*private void MovimientoDinamico()
    {
        Vector2 movimiento = new Vector2(h, v).normalized;
        rb.linearVelocity = movimiento * speed;
    }*/
}
