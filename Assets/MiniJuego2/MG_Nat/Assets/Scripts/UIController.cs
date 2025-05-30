using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    public Text PuntosText;

    int puntajeActual;


    void Start()
    {
        //Inicializamos variables

        PuntosText.text = "Puntaje: " + puntajeActual;
        PlayerPrefs.SetInt("puntos", 0);
        PlayerPrefs.SetInt("Tiempo", 1);
    }


    public void AddPoints(int _points)
    {
        //Añade los puntos y los actualiza
        puntajeActual += _points;
        PlayerPrefs.SetInt("puntos", puntajeActual);
        Imprimir();
    }

        public void SubPoints(int _points)
    {
        //Añade los puntos y los actualiza
        puntajeActual -= _points; 
        PlayerPrefs.SetInt("puntos", puntajeActual);
        Imprimir(); 
    }
    
        public void Imprimir()
    {
        //El texto en el videojuego hace update
        PuntosText.text = "Puntaje: " + puntajeActual;
    }

}
