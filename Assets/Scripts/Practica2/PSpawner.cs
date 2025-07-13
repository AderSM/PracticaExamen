using System.Collections;
using UnityEngine;

namespace Assets.Scripts.Practica2
{
    public class PSpawner : MonoBehaviour
    {
        [SerializeField] private PEnemigo1 enemigo;
        [SerializeField] private Transform[] points;
        private float cuentaInicial = 5f;
        private float cuentaActual;
        // Start is called once before the first execution of Update after the MonoBehaviour is created
        void Start()
        {
            cuentaActual = cuentaInicial;
            StartCoroutine(Spawner());
        }

        // Update is called once per frame
        void Update()
        {
            cuentaActual -= 0.05f * Time.deltaTime;
            if (cuentaActual <= 1f)
            {
                cuentaActual = 1f;
            }
        }

        private IEnumerator Spawner()
        {
            while (true)
            {
                Instantiate(enemigo, points[Random.Range(0, points.Length)].position, Quaternion.identity);
                yield return new WaitForSeconds(cuentaActual);
            }
        }
    }
}