using UnityEngine;
using UnityEngine.UI;

public class SetUI : MonoBehaviour
{
    public Text experienciaText;
    public Text nivelText;
    // public Text puntosText;

    void Start()
    {
        experienciaText.text = PlayerPrefs.GetInt("ExperienciaUsuario").ToString();
        nivelText.text = (PlayerPrefs.GetInt("ExperienciaUsuario") / 1000 + 1).ToString();
        // puntosText.text = PlayerPrefs.GetInt("PuntosUsuario").ToString();
    }
}
