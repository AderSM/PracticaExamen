using System.Collections;
using UnityEngine;

public class Bomba : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        StartCoroutine(Explosion());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private IEnumerator Explosion()
    {
        yield return new WaitForSeconds(2f);

        Collider2D[] entidadAfectada = Physics2D.OverlapCircleAll(transform.position, 2f);
        foreach (Collider2D entidad in entidadAfectada)
        {
            //SistemaVidas sistemaVidasEntidad = entidad.gameObject.GetComponent<SistemaVidas>();
            /*if (sistemaVidasEntidad != null)
            {
                sistemaVidasEntidad.Recibirdanho(20f);
            }*/
            Destroy(entidad.gameObject);
        }
        Destroy(gameObject);
    }
}
