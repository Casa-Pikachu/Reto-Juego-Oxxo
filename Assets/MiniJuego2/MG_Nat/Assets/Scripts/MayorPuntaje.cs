using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
using Newtonsoft.Json;
using System.Collections.Generic;
public class MayorPuntaje : MonoBehaviour
{

    public Text puntajeText;

    public void Start()
    {
        string linkGet = "https://192.168.1.102:7149/Ranking/Primero";
        Ranking newRank = GetPrimero(linkGet);

        puntajeText.text = newRank.puntaje.ToString();
    }

    public void Update()
    {
        if (PlayerPrefs.GetInt("Tiempo") == 0)
        {
            string linkPost = "https://192.168.1.102:7149/Ranking/PostRanking";
            PostPrimero(linkPost);
            PlayerPrefs.SetInt("Tiempo", 1); 
        }
    }


    Ranking GetPrimero(string puntaje)
    {
        UnityWebRequest request = UnityWebRequest.Get(puntaje);
        request.certificateHandler = new ForceAcceptAll();
        request.SendWebRequest();

        while (!request.isDone) { }

        if (request.result == UnityWebRequest.Result.ConnectionError || request.result == UnityWebRequest.Result.ProtocolError)
        {
            Debug.LogError("Error: " + request.error);
            return null;
        }

        string jsonResponse = request.downloadHandler.text;
        Ranking ranking = JsonConvert.DeserializeObject<Ranking>(jsonResponse);
        return ranking;
    }

    void PostPrimero(string mediaURL)
    {
        Ranking ranking = new Ranking
        {
            puntaje = PlayerPrefs.GetInt("puntos"),
            fecha_puntaje = System.DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"),
            id_usuario = 1,
            //id_usuario = PlayerPrefs.GetInt("IdUsuario"),
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
}
