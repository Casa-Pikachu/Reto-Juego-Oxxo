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
        string linkGet = "https://192.168.68.110:7149/Ranking/Primero";
        RankingMini2 newRank = GetPrimero(linkGet);

        puntajeText.text = newRank.puntaje.ToString();
    }


    public void Update()
    {
        if (PlayerPrefs.GetInt("Tiempo") == 0 || PlayerPrefs.GetInt("cantidad") == 6)
        {
            string linkPost = "https://192.168.68.110:7149/Ranking/PostRanking";
            PostPrimero(linkPost);
        }
    }


    RankingMini2 GetPrimero(string puntaje)
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
        RankingMini2 ranking = JsonConvert.DeserializeObject<RankingMini2>(jsonResponse);
        return ranking;
    }

    void PostPrimero(string mediaURL)
    {
        RankingMini2 ranking = new RankingMini2
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
