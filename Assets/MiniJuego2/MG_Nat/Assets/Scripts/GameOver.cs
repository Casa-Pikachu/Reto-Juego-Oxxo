using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOver : MonoBehaviour
{
    // public Text winLoseText;

    public void StartTo()
    {
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

}
