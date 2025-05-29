using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
using Newtonsoft.Json;
using System.Collections.Generic;
public class MayorPuntaje : MonoBehaviour
{
    public string puntaje;

    Ranking GetPrimero(string puntaje)
    {
        Ranking newRank = new Ranking();
        string JSONurl = "https://10.22.222.92:7149/Ranking/Primero";
        UnityWebRequest web = UnityWebRequest.Get(JSONurl);
        web.certificateHandler = new ForceAcceptAll();

        if (web.result != UnityWebRequest.Result.Success)
        {
            UnityEngine.Debug.Log("Error API" + web.error);
        }
        else
        {
            string primero = web.downloadHandler.text;
            newRank = JsonConvert.DeserializeObject<Ranking>(primero);
        }

        return newRank;
    }
        
    void PostPrimero(string mediaURL)
    {
        Ranking ranking = new Ranking
        {
            puntaje = PlayerPrefs.GetInt("Puntos"),
            fecha_puntaje = System.DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"),
            id_usuario = 1,
            id_minijuego = 2
        };

    }
}
