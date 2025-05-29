using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
using Newtonsoft.Json;
using UnityEditor.Media;

public class GetHighScore : MonoBehaviour
{
    public Text highScoreText;
    void Start()
    {
        string mediaUrl = "https://10.22.238.41:7149/Ranking/GetFirst";
        Ranking ranking = GetRanking(mediaUrl);

        if (ranking != null)
        {
            highScoreText.text = ranking.puntaje.ToString();
        }

        else
        {
            highScoreText.text = "----";
        }
    }

    [System.Obsolete]
    void Update()
    {
        if (PlayerPrefs.GetInt("Time") <= 0)
        {
            string mediaURL = "https://10.22.238.41:7149/Ranking/PostRanking";
            PostRanking(mediaURL);
        }
    }

    Ranking GetRanking(string MediaUrl)
    {
        UnityWebRequest request = UnityWebRequest.Get(MediaUrl);
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

    [System.Obsolete]
    void PostRanking(string mediaURL)
    {

        Ranking ranking = new Ranking
        {
            puntaje = PlayerPrefs.GetInt("Puntos"),
            fecha_puntaje = System.DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"),
            id_usuario = 1, // PlayerPrefs.GetInt("IdUsuario")
            id_minijuego = 1
        };

        string jsonData = JsonConvert.SerializeObject(ranking);
        UnityWebRequest request = UnityWebRequest.Post(mediaURL, jsonData);
        request.certificateHandler = new ForceAcceptAll();
        byte[] bodyRaw = System.Text.Encoding.UTF8.GetBytes(jsonData);
        request.uploadHandler = new UploadHandlerRaw(bodyRaw);
        request.SetRequestHeader("Content-Type", "application/json");
        request.SendWebRequest();
    }
    
}
