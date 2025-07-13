using System;
using System.Collections;
using UnityEngine;

public class PEnemigo2 : MonoBehaviour
{
    [SerializeField] private Transform[] points;
    [SerializeField] private float velocidadMovimiento;
    private Vector3 targetActual;
    private int indiceActual = 0;
    private Animator anim;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        anim = GetComponent<Animator>();
        targetActual = points[indiceActual].position;
        StartCoroutine(Patrulla());
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 direccionN = (targetActual - transform.position).normalized;
        anim.SetFloat("horizontal", direccionN.x);
        anim.SetFloat("vertical", direccionN.y);
    }

    private IEnumerator Patrulla()
    {
        while (true)
        {
            while (transform.position != targetActual)
            {
                transform.position = Vector3.MoveTowards(transform.position, targetActual, velocidadMovimiento * Time.deltaTime);
                yield return null;
            }
            DefinirNuevoPunto();
        }
    }

    private void DefinirNuevoPunto()
    {
        indiceActual++;
        if (indiceActual >= points.Length)
        {
            indiceActual = 0;
        }
        targetActual = points[indiceActual].position;
    }
}
