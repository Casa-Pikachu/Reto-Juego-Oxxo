using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
using System.Collections;

public class FondoNivelUI : MonoBehaviour
{
    public Image fondoUI;
    private string apiNivel = "https://192.xxx:7149/Niveles/GetNivelimg/";

    void Start()
    {
        //porfa no le cambien nada a login porque esta ligado a eso 
        
        int experiencia = PlayerPrefs.GetInt("ExperienciaUsuario", 0);
        int nivel = (experiencia / 100) + 1;
        Debug.Log("Cargando nivel: " + nivel);
        StartCoroutine(CargarFondoNivel(nivel));
    }

    IEnumerator CargarFondoNivel(int nivel)
    {
        string url = apiNivel + nivel;
        UnityWebRequest request = UnityWebRequest.Get(url);
        request.certificateHandler = new ForceAcceptAll();
        yield return request.SendWebRequest();
        if (request.result != UnityWebRequest.Result.Success)
        {
            Debug.Log("Error");
            yield break;
        }

        string json = request.downloadHandler.text;
        NivelData data = JsonUtility.FromJson<NivelData>(json);

        if (!string.IsNullOrEmpty(data.liga_nivel))
        {
            StartCoroutine(DescargarImagen(data.liga_nivel));
        }
        else
        {
            Debug.Log("liga_nivel vacia");
        }
    }

    IEnumerator DescargarImagen(string url)
    {
        UnityWebRequest imgRequest = UnityWebRequestTexture.GetTexture(url);
        imgRequest.certificateHandler = new ForceAcceptAll();
        yield return imgRequest.SendWebRequest();
        if (imgRequest.result != UnityWebRequest.Result.Success)
        {
            Debug.LogError("Error al descargar imagen: " + imgRequest.error);
            yield break;
        }
        /*esta parte no la he podido configurar en unity porque lo quise 
        poner en el area de trabajo siendo canvas y lo asigne a la camara
        preguntar a claudia asap*/
        Texture2D tex = DownloadHandlerTexture.GetContent(imgRequest);
        Sprite sprite = Sprite.Create(tex, new Rect(0, 0, tex.width, tex.height), new Vector2(0.5f, 0.5f));

        fondoUI.sprite = sprite;
        Debug.Log("Fondo actualizado");
    }

    [System.Serializable]
    public class NivelData
    {
        public int nivel;
        public string liga_nivel;
    }
}
