using System.Collections;
using UnityEngine;

public class EnemyPlataforma : MonoBehaviour
{
    [SerializeField] private Transform[] waypoints;
    [SerializeField] private float velocidadPatrulla;
    private Vector3 destinoActual;
    private int indiceActual = 0;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        destinoActual = waypoints[indiceActual].position;
        StartCoroutine(Patrulla());
    }

    // Update is called once per frame
    void Update()
    {

    }

    private IEnumerator Patrulla()
    {
        while (true)
        {
            while (transform.position != destinoActual)
            {
                transform.position = Vector3.MoveTowards(transform.position, destinoActual, velocidadPatrulla * Time.deltaTime);
                yield return null;
            }
            DefinirNuevoDestino();
        }
    }

    private void DefinirNuevoDestino()
    {
        indiceActual++;
        if (indiceActual >= waypoints.Length)
        {
            indiceActual = 0;
        }
        destinoActual = waypoints[indiceActual].position;
    }
}
