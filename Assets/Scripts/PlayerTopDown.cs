using System.Collections;
using UnityEngine;

public class PlayerTopDown : MonoBehaviour
{
    private float inputH;
    private float inputV;
    private bool moviendo;
    private Vector3 puntoDestino;
    private Vector3 ultimoInput;
    private Vector3 puntoInteraccion;
    private Collider2D colliderDelante;
    [SerializeField] private float velocidadMovimiento; //5
    [SerializeField] private float radioInteraccion; //0.3
    [SerializeField] private LayerMask queEsColisionable;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        if (inputV == 0)
        {
            inputH = Input.GetAxisRaw("Horizontal");
        }
        if (inputH == 0)
        {
            inputV = Input.GetAxisRaw("Vertical");
        }
        if (!moviendo && (inputH != 0 || inputV != 0))
        {
            ultimoInput = new Vector3(inputH, inputV, 0);
            puntoDestino = transform.position + ultimoInput;
            puntoInteraccion = puntoDestino;

            colliderDelante = LanzarCheck();
            if (!colliderDelante)
            {
                StartCoroutine(Mover());
            }
        }
    }

    private IEnumerator Mover()
    {
        moviendo = true;
        while (transform.position != puntoDestino)
        {
            transform.position = Vector3.MoveTowards(transform.position, puntoDestino, velocidadMovimiento * Time.deltaTime);
            yield return null;
        }
        puntoInteraccion = transform.position + ultimoInput;
        moviendo = false;
    }

    private Collider2D LanzarCheck()
    {
        return Physics2D.OverlapCircle(puntoInteraccion, radioInteraccion, queEsColisionable);
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawSphere(puntoInteraccion, radioInteraccion);
    }
}
