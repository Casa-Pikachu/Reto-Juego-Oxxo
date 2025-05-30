using UnityEngine;
using UnityEngine.UI;

public class EndGameCashier : MonoBehaviour
{
    public Text puntaje;
    public Text monedas;
    void Start()
    {
        puntaje.text = PlayerPrefs.GetInt("Puntos").ToString();
        monedas.text = "100";
    }
}
