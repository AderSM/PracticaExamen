using UnityEngine;

public class PlayerCinematico : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private GameObject bomba;
    private float horizontal, vertical;
    private Animator anim;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        DeliminarMovimiento();
        MovimientoCinematico();
        if (horizontal != 0f || vertical!= 0f)
        {
            anim.SetBool("Caminando", true);
            anim.SetFloat("Horizontal", horizontal);
            anim.SetFloat("Vertical", vertical);
        }
        else
        {
            anim.SetBool("Caminando", false);
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Instantiate(bomba, transform.position, Quaternion.identity);
        }
    }

    private void DeliminarMovimiento()
    {
        float xClamped = Mathf.Clamp(transform.position.x, -12f, 12f);
        float yClamped = Mathf.Clamp(transform.position.y, -6.3f, 6.3f);
        transform.position = new Vector3(xClamped, yClamped, 0);
    }

    private void MovimientoCinematico()
    {
        horizontal = Input.GetAxisRaw("Horizontal");
        vertical= Input.GetAxisRaw("Vertical");
        Vector2 movimiento = new Vector2(horizontal, vertical).normalized;
        transform.Translate(movimiento * speed * Time.deltaTime);
    }
}
