using System.Collections;
using UnityEngine;
using static UnityEngine.Rendering.DebugUI;

public class Enemy : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private Shell shellPrefab;
    [SerializeField] private Transform spawnPoint;
    [SerializeField] private int salud;
    private PlayerBase target;
    private bool shooting;

    private void Awake()
    {
        target = GameObject.FindAnyObjectByType<PlayerBase>();
    }

    private void Update()
    {
        if (Vector3.Distance(transform.position, target.transform.position) > 3.5f)
        {
            transform.position = Vector3.MoveTowards(transform.position, target.transform.position, speed * Time.deltaTime);
        }
        else
        {
            if (!shooting)
            {
                StartCoroutine(GenerateShots());
            }
        }
    }

    private IEnumerator GenerateShots()
    {
        shooting = true;
        while (true)
        {
            Shell shellCopy = Instantiate(shellPrefab, spawnPoint.position, transform.rotation);
            yield return new WaitForSeconds(2.5f);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision != null)
        {
            if (collision.gameObject.CompareTag("Shell"))
            {
                Destroy(collision.gameObject);
                salud -= 20;
                if (salud <= 0)
                {
                    Debug.Log("Mori");
                }
            }
        }
    }
}
