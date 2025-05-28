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
}
