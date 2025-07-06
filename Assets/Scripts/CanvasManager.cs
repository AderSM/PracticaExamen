using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CanvasManager : MonoBehaviour
{
    [SerializeField] private GameObject canvas1;
    [SerializeField] private TextMeshProUGUI text1;
    [SerializeField] private TextMeshProUGUI text2;
    [SerializeField] private TextMeshProUGUI text3;
    [SerializeField] private TextMeshProUGUI text4;
    private PlayerBase playerBase;
    private Player player;
    private int tiempo = 0;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        playerBase = FindAnyObjectByType<PlayerBase>();
        player = FindAnyObjectByType<Player>();
        StartCoroutine(ContadorAsc());
    }

    // Update is called once per frame
    void Update()
    {
        if (playerBase != null)
        {
            if (playerBase.Salud <= 0)
            {
                canvas1.SetActive(true);
                StopAllCoroutines();
                text4.text = "Has aguantado: " + tiempo + "s";
            }
        }
        text1.text = "Player: " + player.Salud;
        text2.text = "Base: " + playerBase.Salud;
        text3.text = "Tiempo: " + tiempo;
    }

    public void ReiniciarNivel()
    {
        SceneManager.LoadScene(0);
    }

    private IEnumerator ContadorAsc()
    {
        while (true)
        {
            tiempo++;
            yield return new WaitForSeconds(1f);
        }
    }
}
