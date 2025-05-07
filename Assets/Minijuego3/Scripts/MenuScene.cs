using UnityEngine;
using UnityEngine.SceneManagement;


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

    public void StartFinalScene()
    {
        SceneManager.LoadScene("FinalScene");
    }
    


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
