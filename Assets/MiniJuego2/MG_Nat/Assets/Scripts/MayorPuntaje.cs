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
        string linkGet = "https://192.168.2.141:7222/Ranking/GetFirst";
        RankingMini2 newRank = GetPrimero(linkGet);

        puntajeText.text = newRank.puntaje.ToString();
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

    
}
