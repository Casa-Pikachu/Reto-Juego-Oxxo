using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOverV3 : MonoBehaviour
{
    public Text winLoseText;
    public Text puntajeText; 
    

    public Text starText;




    void Start()
    {

        int score = PlayerPrefs.GetInt("+", 0);
        puntajeText.text = score.ToString();

        int cantObj = PlayerPrefs.GetInt("o", 0);
        starText.text = cantObj.ToString();
       

        if (score >= 300)
        {
            winLoseText.text = "Ganaste";
        }
        else
        {
            winLoseText.text = "Sigue Practicando";

        }

       
    }

    public void StartToplay()
    {
        SceneManager.LoadScene("GameScene");
    }

    
}

