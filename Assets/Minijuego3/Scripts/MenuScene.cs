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
   // private bool escenaCargada = false;

    void Update()
    {
       /* if (!escenaCargada && timer != null && timer.HaTerminado)
        {
            escenaCargada = true;
            //Debug.Log("Se acabo el tiempo");
            int siguiente = SceneManager.GetActiveScene().buildIndex + 1;
            SceneManager.LoadScene(siguiente);
        }*/

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

