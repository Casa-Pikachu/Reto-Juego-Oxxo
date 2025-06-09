using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Networking;
using System.Collections;

public class GameOverV3 : MonoBehaviour
{
    public Text winLoseText;
    public Text puntajeText;
    public Text xpText;
    public Text starText;

    void Start()
    {
        int puntosPartida = PlayerPrefs.GetInt("puntos_usuario", 0);
        int monedasPartida = PlayerPrefs.GetInt("monedas_usuario", 0);
        int experienciaPartida = PlayerPrefs.GetInt("experiencia_usuario", 0);

        // Mostrar en UI
        puntajeText.text = puntosPartida.ToString();
        starText.text = monedasPartida.ToString();
        xpText.text = experienciaPartida.ToString();

        // Mostrar mensaje
        winLoseText.text = (puntosPartida >= 300) ? "Ganaste" : "Sigue Practicando";

        // Actualizar base de datos sumando a los valores acumulados
        ActualizarDatosEnServidor(puntosPartida, experienciaPartida);
    }

    void ActualizarDatosEnServidor(int puntos, int experiencia)
    {

        /*team: comente monedas porque vi que no lo usaban pero si cambian de opinion solo 
        descomenten y congan int monedas, lit lo trae de lista verificadora 
        puse que te diera una moneda por cada objeto que tienes bien
        tambien puse en xxxx el ip porque no queria que saliera el ip de mi casa, sorry si no di 
        tantos commits */
        int idUsuario = PlayerPrefs.GetInt("IdUsuario");
        int puntosPrevios = PlayerPrefs.GetInt("PuntosUsuario", 0);
        //int monedasPrevias = PlayerPrefs.GetInt("MonedasUsuario", 0);
        int experienciaPrevia = PlayerPrefs.GetInt("ExperienciaUsuario", 0);
        int nuevosPuntos = puntosPrevios + puntos;
        // int nuevasMonedas = monedasPrevias + monedas;
        int nuevaExperiencia = experienciaPrevia + experiencia;

        
        PlayerPrefs.SetInt("PuntosUsuario", nuevosPuntos);
        //PlayerPrefs.SetInt("MonedasUsuario", nuevasMonedas);
        PlayerPrefs.SetInt("ExperienciaUsuario", nuevaExperiencia);

        

        StartCoroutine(EnviarPUT("https://192.xxx:7149/Usuarios/UpdatePuntos", $"{idUsuario}/{nuevosPuntos}"));
        // StartCoroutine(EnviarPUT("https://192.xxx:7149/Usuarios/UpdateMonedas", $"{idUsuario}/{nuevasMonedas}"));
        StartCoroutine(EnviarPUT("https://192.xxx:7149/Usuarios/UpdateExperiencia", $"{idUsuario}/{nuevaExperiencia}"));
        

    }

    IEnumerator EnviarPUT(string baseUrl, string parametros)
    {
        string url = $"{baseUrl}/{parametros}";
        UnityWebRequest request = UnityWebRequest.Put(url, "");
        request.certificateHandler = new ForceAcceptAll();
        yield return request.SendWebRequest();

        if (request.result != UnityWebRequest.Result.Success)
        {
            Debug.LogError($"Error actualizando en {url}: {request.error}");
        }
    }

    public void StartToplay()
    {
        SceneManager.LoadScene("GameScene");
    }
}



    

    


