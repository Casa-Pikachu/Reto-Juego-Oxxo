using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOverV3 : MonoBehaviour
{
    public Text winLoseText;
    public Text puntajeText; 
 
    public SFXManager sound;

    void Start()
    {

       
    }

    public void StartToplay()
    {
        SceneManager.LoadScene("GameScene");
    }

    
}

