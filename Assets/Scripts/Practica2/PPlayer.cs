using System;
using System.Collections;
using UnityEngine;

public class PPlayer : MonoBehaviour
{
    [SerializeField] private float velocidadMovimiento;
    [SerializeField] private PBomba bomba;
    private bool cooldown;
    private float horizontal, vertical;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Movimiento();
        DelimitarMovimiento();
        InstanciarBomba();
    }

    private void InstanciarBomba()
    {
        if (Input.GetKeyDown(KeyCode.Space) && !cooldown)
        {
            Instantiate(bomba, transform.position, Quaternion.identity);
            cooldown = true;
            StartCoroutine(Cooldown());
        }
            
    }

    private void Movimiento()
    {
        horizontal = Input.GetAxisRaw("Horizontal");
        vertical = Input.GetAxisRaw("Vertical");
        Vector2 movimiento = new Vector2(horizontal, vertical).normalized;
        transform.Translate(movimiento * velocidadMovimiento * Time.deltaTime);
    }

    private void DelimitarMovimiento()
    {
        float xClamp = Mathf.Clamp(transform.position.x, -11.5f, 11.5f);
        float yClamp = Mathf.Clamp(transform.position.y, -6.5f, 6.5f);
        transform.position = new Vector2(xClamp, yClamp);
    }

    private IEnumerator Cooldown()
    {
        yield return new WaitForSeconds(3f);
        cooldown = false;
        StopAllCoroutines();
    }
}
