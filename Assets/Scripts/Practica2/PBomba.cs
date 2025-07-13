using System.Collections;
using UnityEngine;

public class PBomba : MonoBehaviour
{
    private Animator anim;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Awake()
    {
        anim = GetComponent<Animator>();
    }
    void Start()
    {
        StartCoroutine(Explotar());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private IEnumerator Explotar()
    {
        yield return new WaitForSeconds(2f);
        Collider2D[] collider = Physics2D.OverlapCircleAll(transform.position, 3f);
        foreach (Collider2D item in collider)
        {
            Destroy(item.gameObject);
        }
        if (anim)
        {
            anim.SetTrigger("explotar");
        }
    }

    private void Destruir()
    {
        Destroy(this.gameObject);
    }
}
