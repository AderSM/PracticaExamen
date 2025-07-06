using UnityEngine;

public class PlayerPlataforma : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float fuerzaSalto;
    [SerializeField] private LayerMask queEsSaltable;
    [SerializeField] private Transform pies;
    private float horizontal;
    private Rigidbody2D rb;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        MovimientoDinamico();
        if (Input.GetKeyDown(KeyCode.Space) && EstoyEnSuelo())
        {
            rb.AddForce(Vector2.up * fuerzaSalto, ForceMode2D.Impulse);
        }
    }


    private void MovimientoDinamico()
    {
        horizontal = Input.GetAxisRaw("Horizontal");
        rb.linearVelocity = new Vector2(horizontal * speed, rb.linearVelocityY);
    }

    private bool EstoyEnSuelo()
    {
        return Physics2D.Raycast(pies.transform.position, Vector2.down, 0.15f, queEsSaltable);
    }
}
