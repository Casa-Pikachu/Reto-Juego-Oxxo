using UnityEngine;
using UnityEngine.UI;

public class UIEndController : MonoBehaviour
{
    public Text points;
    public Text endGame;
    public Text highscore; 

    void Start()
    {
        if (PlayerPrefs.GetInt("cantidad") == 6)
        {
            endGame.text = "¡Ganaste!";
        }
        else
        {
            endGame.text = "Intenta de Nuevo";
        }

        points.text = PlayerPrefs.GetInt("puntos").ToString();
    }





}
