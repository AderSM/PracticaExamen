using UnityEngine;

public class Shell : MonoBehaviour
{
    [SerializeField] private float shootForce;
    private void Awake()
    {
        GetComponent<Rigidbody2D>().AddForce(transform.up * shootForce, ForceMode2D.Impulse);
    }
}
