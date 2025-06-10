using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections.Generic;

public class MenuScene : MonoBehaviour
{

    public void StartListaScene()
    {
        SceneManager.LoadScene("ListaScene");
    }

    public void StartMinigameScene()
    {
        SceneManager.LoadScene("MinigameScene");
    }


    public Timer timer;
    public ListaVerificacionFinal puntaje;



    void Update()
    {
        if (timer != null)
        {


            if (timer.remainingDuration <= 0)
            {
                Debug.Log("Se acabo el tiempo");


                ListaVerificacionFinal verificador = FindFirstObjectByType<ListaVerificacionFinal>();
                if (verificador != null)
                {
                    verificador.Verificar();
                    PlayerPrefs.Save();
                }
                else
                {
                    Debug.Log("No hay lista");
                }
                int siguiente = SceneManager.GetActiveScene().buildIndex + 1;
                SceneManager.LoadScene(siguiente);
            }
        }
         

    }



    public void StartFinalScene()
    {
        SceneManager.LoadScene("FinalScene");
    }

    public void StartMinigame2Scene()
    {
        SceneManager.LoadScene("GameScene");
    }
    


    
}

