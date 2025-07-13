using System.Collections;
using System.Linq.Expressions;
using UnityEngine;

public class PEnemigo1 : MonoBehaviour
{
    [SerializeField] private float velocidadEnemigo;
    private PPlayer player;
    private bool pegando;
    private Animator anim;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        player = FindAnyObjectByType<PPlayer>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 direccionN = (player.transform.position - transform.position).normalized;
        anim.SetFloat("horizontal", direccionN.x);
        anim.SetFloat("vertical", direccionN.y);
        if (Vector2.Distance(transform.position, player.transform.position) > 1.5f)
        {
            transform.position = Vector3.MoveTowards(transform.position, player.transform.position, velocidadEnemigo * Time.deltaTime);
        }
        else
        {
            if (!pegando)
            {
                StartCoroutine(Pegando());
            }
        }
    }

    private IEnumerator Pegando()
    {
        pegando = true;
        Debug.Log("Te pego");
        yield return new WaitForSeconds(2f);
        pegando = false;
        StopAllCoroutines();
    }
}
