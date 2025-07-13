using UnityEngine;

public class Bala : MonoBehaviour
{
    private Rigidbody2D rb;
    private PPlayer2 player;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        player = FindAnyObjectByType<PPlayer2>();
        rb.AddForce((player.transform.position - transform.position).normalized * 10f, ForceMode2D.Impulse);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
