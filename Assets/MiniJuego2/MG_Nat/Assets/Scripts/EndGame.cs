using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
using Newtonsoft.Json;
using System.Collections.Generic;
public class EndGame : MonoBehaviour
{
    [SerializeField] float remainingTime;

    public GameManager Manager;

    void Start()
    {
        Time.timeScale = 1;
        Debug.Log("Starts");
    }

    void Update()
    {

        if (remainingTime > 0)
        {
            remainingTime -= Time.deltaTime;
        }

        else if (PlayerPrefs.GetInt("cantidad") < 6 || remainingTime <= 0)
        {
            string linkPost = "https://192.168.2.141:7222/Ranking/PostRanking";
            string linkPuntos = "https://192.168.2.141:7222/Usuarios/UpdatePuntos";
            string linkURL = "https://192.168.2.141:7222/Usuarios/UpdateExperiencia";

            int newPuntaje = PlayerPrefs.GetInt("Puntos") + PlayerPrefs.GetInt("PuntosUsuario");
            int newEXP = PlayerPrefs.GetInt("ExperienciaUsuario") + (newPuntaje / 10);

            PlayerPrefs.SetInt("ExperienciaUsuario", newEXP);
            PlayerPrefs.SetInt("PuntosUsuario", newPuntaje);

            PostPrimero(linkPost);
            UpdatePuntos(linkPuntos);
            UpdateExperiencia(linkURL);
            

            remainingTime = 0;
            Manager.endScene();
        }
    }


    void PostPrimero(string mediaURL)
    {
        RankingMini2 ranking = new RankingMini2
        {
            puntaje = PlayerPrefs.GetInt("Puntos"),
            fecha_puntaje = System.DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"),
            id_usuario = PlayerPrefs.GetInt("IdUsuario"),
            id_minijuego = 2
        };

        string jsonData = JsonConvert.SerializeObject(ranking);
        UnityWebRequest request = new UnityWebRequest(mediaURL, "POST");
        request.certificateHandler = new ForceAcceptAll();

        byte[] bodyRaw = System.Text.Encoding.UTF8.GetBytes(jsonData);
        request.uploadHandler = new UploadHandlerRaw(bodyRaw);
        request.downloadHandler = new DownloadHandlerBuffer();
        request.SetRequestHeader("Content-Type", "application/json");
        request.SendWebRequest();
    }
    
    void UpdatePuntos(string mediaURL)
    {
        int puntos = PlayerPrefs.GetInt("puntos");
        int id = PlayerPrefs.GetInt("IdUsuario");

        string url = $"{mediaURL}/{id}/{puntos}";

        UnityWebRequest request = UnityWebRequest.Put(url, "");
        request.certificateHandler = new ForceAcceptAll();

        request.SendWebRequest();
    }

    void UpdateExperiencia(string mediaURL)
    {
        int experiencia = PlayerPrefs.GetInt("ExperienciaUsuario");
        int id = PlayerPrefs.GetInt("IdUsuario");
        string url = $"{mediaURL}/{id}/{experiencia}";

        UnityWebRequest request = UnityWebRequest.Put(url, "");
        request.certificateHandler = new ForceAcceptAll();

        request.SendWebRequest();
    }
}
