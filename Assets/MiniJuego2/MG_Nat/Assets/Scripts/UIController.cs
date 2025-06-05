using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    public Text PuntosText;

    int puntajeActual;

    void Start()
    { 
        PuntosText.text = "Puntaje: " + puntajeActual;
        PlayerPrefs.SetInt("puntos", 0);
        PlayerPrefs.SetInt("Tiempo", 1);
    }

    public void AddPoints(int _points)
    {
        puntajeActual += _points;
        PlayerPrefs.SetInt("puntos", puntajeActual);
        Imprimir();
    }

    public void SubPoints(int _points)
    {
        if (puntajeActual > 5)
        {
            puntajeActual -= _points;
            PlayerPrefs.SetInt("puntos", puntajeActual);
            Imprimir();
        }
    }

    public void Imprimir()
    {
        PuntosText.text = "Puntaje: " + puntajeActual;
    }

}
