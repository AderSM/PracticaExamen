using UnityEngine;

public class PPlayer2 : MonoBehaviour
{
    [SerializeField] float velocidadMovimiento;
    [SerializeField] LayerMask suelo;
    [SerializeField] Transform pies;
    [SerializeField] float fuerzaSalto;
    private float horitzontal;
    private Rigidbody2D rb;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Movimiento();
        if (Input.GetKeyDown(KeyCode.Space) && TocandoSuelo())
        {
            rb.AddForce(Vector3.up * fuerzaSalto, ForceMode2D.Impulse);
            Debug.Log("Saltando");
        }
    }

    private void Movimiento()
    {
        horitzontal = Input.GetAxisRaw("Horizontal");
        rb.linearVelocity = new Vector2(horitzontal * velocidadMovimiento, rb.linearVelocity.y);
    }

    private bool TocandoSuelo()
    {
        return Physics2D.Raycast(pies.position, Vector2.down, 0.5f, suelo);
    }
}
