using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
using Newtonsoft.Json;
using System.Collections.Generic;

public class GetPodio : MonoBehaviour
{
    public Text posicion1;
    public Text posicion2;
    public Text posicion3;
    List<Usuarios> usuariosList;

    void Start()
    {
        string mediaUrl = "https://192.xxx:7149/Usuarios/GetTopExperiencia";

        usuariosList = GetTopExp(mediaUrl);

        if (usuariosList != null)
        {
            if (usuariosList.Count >= 1)
                posicion1.text = $"{usuariosList[0].nombre} - {usuariosList[0].experiencia} XP";

            if (usuariosList.Count >= 2)
                posicion2.text = $"{usuariosList[1].nombre} - {usuariosList[1].experiencia} XP";

            if (usuariosList.Count >= 3)
                posicion3.text = $"{usuariosList[2].nombre} - {usuariosList[2].experiencia} XP";
        }


        else
        {
            posicion1.text = "----";
            posicion2.text = "----";
            posicion3.text = "----";
        }
    }

    List<Usuarios> GetTopExp(string mediaUrl)
    {
        UnityWebRequest request = UnityWebRequest.Get(mediaUrl);
        request.certificateHandler = new ForceAcceptAll();
        request.SendWebRequest();

        while (!request.isDone) { }

        if (request.result == UnityWebRequest.Result.ConnectionError || request.result == UnityWebRequest.Result.ProtocolError)
        {
            Debug.LogError("Error: " + request.error);
            return null;
        }

        string jsonResponse = request.downloadHandler.text;
        usuariosList = JsonConvert.DeserializeObject<List<Usuarios>>(jsonResponse);
        return usuariosList;
    }
}
