using UnityEngine;

public class PlayerBase : MonoBehaviour
{
    [SerializeField] private int salud;

    public int Salud { get => salud; set => salud = value; }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision != null)
        {
            if (collision.gameObject.CompareTag("Shell"))
            {
                Destroy(collision.gameObject);
                salud-=20;
            }
        }
    }
}
