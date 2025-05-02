using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOver : MonoBehaviour
{
    public Text winLoseText;
    public Text PuntajeText;
    public Text ExpText;

    public void StartTo(){
        PlayerPrefs.DeleteAll();
        SceneManager.LoadScene("CasherScene"); 
    }

    public void StartToplay(){
        PlayerPrefs.DeleteAll();
        SceneManager.LoadScene("GameScene"); 
    }

    public void ExitGame(){
        SceneManager.LoadScene("MenuScene");
    }

    void Start(){
        if(PlayerPrefs.GetInt("winlose", 1) == 1){
            winLoseText.text = "¡Nivel Completado!";
            PuntajeText.text = "+ 1500";
            ExpText.text = "+ 100";
        }
        else{
            winLoseText.text = "Fin del juego";
            PuntajeText.text = "0";
            ExpText.text = "0";
        }
    }
}
