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
    public Text posicion4;
    public Text posicion5;
    public Text posicion6;
    public Text posicion7;
    public Text posicion8;
    public Text posicion9;
    public Text posicion10;
    public Text posicionExtra;
    public Text posicionExtraNumero;

    List<Usuarios> usuariosList;

    void Start()
    {
    
        string mediaUrl = "https://10.22.168.234:7222/Usuarios/GetTopExperiencia";
        //string mediaUrl = "https://192.168.2.141:7222/Usuarios/GetTopExperiencia";
        //string mediaUrl = "https://192.168.68.110:7149/Usuarios/GetTopExperiencia";

        usuariosList = GetTopExp(mediaUrl);
        int userId = PlayerPrefs.GetInt("IdUsuario");

        if (usuariosList != null)
        {
            Text[] posiciones = { posicion1, posicion2, posicion3, posicion4, posicion5, posicion6, posicion7, posicion8, posicion9, posicion10 };

            for (int i = 0; i < Mathf.Min(10, usuariosList.Count); i++)
            {
                var usuario = usuariosList[i];
                posiciones[i].text = $"{usuario.nombre} - {usuario.experiencia} XP";
            }

            int userPosition = usuariosList.FindIndex(u => u.id_usuario == userId);
            Debug.Log($"User ID: {userId}");
            Debug.Log($"User Position in list: {userPosition}");
            Debug.Log($"Total usuarios: {usuariosList.Count}");

            if (userPosition >= 0 && userPosition < 10)
            {
                posiciones[userPosition].color = Color.grey;

                if (usuariosList.Count > 10)
                {
                    var siguiente = usuariosList[10];
                    posicionExtraNumero.text = "#11";
                    posicionExtra.text = $"{siguiente.nombre} - {siguiente.experiencia} XP";

                    if (siguiente.id_usuario == userId)
                        posicionExtra.color = Color.grey;
                    else
                        posicionExtra.color = Color.black;
                }
                else
                {
                    posicionExtraNumero.text = "";
                    posicionExtra.text = "";
                }
            }
            else if (userPosition >= 10)
            {
                var usuario = usuariosList[userPosition];
                posicionExtraNumero.text = $"#{userPosition + 1}";
                posicionExtra.text = $"{usuario.nombre} - {usuario.experiencia} XP";
                posicionExtra.color = Color.grey;
            }
            else
            {
                posicionExtraNumero.text = "";
                posicionExtra.text = "Usuario no encontrado en el ranking.";
            }
        }
        else
        {
            Text[] posiciones = { posicion1, posicion2, posicion3, posicion4, posicion5, posicion6, posicion7, posicion8, posicion9, posicion10 };
            foreach (Text pos in posiciones)
            {
                pos.text = "----";
            }
            posicionExtraNumero.text = "";
            posicionExtra.text = "----";
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
