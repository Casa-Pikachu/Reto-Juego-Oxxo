using UnityEditor;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Newtonsoft.Json;
using UnityEngine.Networking;

public class EndField : MonoBehaviour, IDropHandler
{
    public Text productoText;
    public Text precioText;
    public Text clientDialogue;
    public Text puntos;
    public CashierSFX cashierSFX;

    private void Start()
    {
        productoText = GameObject.Find("DisplayProducto").GetComponent<Text>();
        precioText = GameObject.Find("DisplayPrecio").GetComponent<Text>();
        clientDialogue = GameObject.Find("ClientDialogue").GetComponent<Text>();
        puntos = GameObject.Find("Puntos").GetComponent<Text>();
        PlayerPrefs.SetInt("Puntos", 0);
        UpdatePuntos();
    }

    // Destruye el draggable item que se suelta en este campo
    public void OnDrop(PointerEventData eventData)
    {
        DraggableItem draggable = eventData.pointerDrag.GetComponent<DraggableItem>();


        if (draggable != null && draggable.itemName != "Recarga")
        {
            if (draggable.itemName.StartsWith("Promo"))
            {
                draggable.itemName = draggable.itemName[5..];
            }

            productoText.text += $"{draggable.itemName}\n";
            precioText.text += $"{draggable.itemPrice}\n";
            PlayerPrefs.SetInt("Puntos", PlayerPrefs.GetInt("Puntos") + draggable.itemPuntos);
            UpdatePuntos();

            cashierSFX.PlayScanner();
            Destroy(draggable.gameObject);
            clientDialogue.text = "";

            PlayerPrefs.SetInt("CanSpawn", 1);
            PlayerPrefs.SetString("EspecialApplied", "0");
        }

        else
        {
            cashierSFX.PlayError();
            clientDialogue.text = "¡No puedes escanear recargas!";
        }
    }

    public void ClearDisplay()
    {
        clientDialogue.text = "";
        productoText.text = "";
        precioText.text = "";
        PlayerPrefs.SetInt("CanSpawn", 1);
    }

    public void FinishOrder()
    {
        if (PlayerPrefs.GetInt("OrderFinished") == 1)
        {
            ClearDisplay();

            cashierSFX.PlayCompletarCompra();

            GameObject client = GameObject.FindGameObjectWithTag("Client");
            PlayerPrefs.SetString("LastClientPrefab", client.GetComponent<Client>().clientID);

            if (client != null)
            {
                Destroy(client);
            }
        }

        else
        {
            cashierSFX.PlayError();
            clientDialogue.text = "No has escaneado todos mis artículos";

            if (PlayerPrefs.GetInt("Puntos") > 0)
            {
                PlayerPrefs.SetInt("Puntos", PlayerPrefs.GetInt("Puntos") - 50);
                UpdatePuntos();
            }
        }
    }

    public void UpdatePuntos()
    {
        if (PlayerPrefs.GetInt("Puntos") < 0)
        {
            PlayerPrefs.SetInt("Puntos", 0);
        }

        puntos.text = PlayerPrefs.GetInt("Puntos").ToString();
    }


    public void BotonRecarga()
    {
        if (PlayerPrefs.GetString("CurrentItem") == "Recarga")
        {
            PlayerPrefs.SetInt("Puntos", PlayerPrefs.GetInt("Puntos") + 30);
            UpdatePuntos();
            clientDialogue.text = "¡Gracias por mi recarga!";
            cashierSFX.PlayCorrecto();

            productoText.text += "Recarga\n";
            precioText.text += "50\n";

            // Destruye el prefab de recarga
            GameObject recarga = GameObject.Find("Recarga(Clone)");
            if (recarga != null)
            {
                Destroy(recarga);
            }

            PlayerPrefs.SetInt("CanSpawn", 1);
        }

        else
        {
            clientDialogue.text = "¡No es lo que pedí!";
            cashierSFX.PlayError();

            if (PlayerPrefs.GetInt("Puntos") - 50 >= 0)
            {
                PlayerPrefs.SetInt("Puntos", PlayerPrefs.GetInt("Puntos") - 50);
                UpdatePuntos();
            }
        }
    }

    public void BotonAndatti()
    {
        if (PlayerPrefs.GetString("CurrentItem") == "Andatti" && PlayerPrefs.GetInt("EspecialApplied") == 0)
        {
            PlayerPrefs.SetInt("EspecialApplied", 1);
            PlayerPrefs.SetInt("Puntos", PlayerPrefs.GetInt("Puntos") + 30);
            UpdatePuntos();
            clientDialogue.text = "¡Gracias por mi Andatti!";
            cashierSFX.PlayCorrecto();
        }

        else if (PlayerPrefs.GetString("CurrentItem") == "Andatti" && PlayerPrefs.GetInt("EspecialApplied") == 1)
        {
            clientDialogue.text = "¡Ya has aplicado la promoción!";
            cashierSFX.PlayError();
        }

        else
        {
            clientDialogue.text = "¡No es lo que pedí!";
            cashierSFX.PlayError();

            if (PlayerPrefs.GetInt("Puntos") - 50 >= 0)
            {
                PlayerPrefs.SetInt("Puntos", PlayerPrefs.GetInt("Puntos") - 50);
                UpdatePuntos();
            }
        }
    }

    public void BotonPromo()
    {
        if (PlayerPrefs.GetString("CurrentItem").StartsWith("Promo") && PlayerPrefs.GetInt("EspecialApplied") == 0)
        {
            PlayerPrefs.SetInt("EspecialApplied", 1);
            PlayerPrefs.SetInt("Puntos", PlayerPrefs.GetInt("Puntos") + 30);
            UpdatePuntos();
            clientDialogue.text = "¡Gracias por aplicar la promoción!";
            cashierSFX.PlayCorrecto();
        }

        else if (PlayerPrefs.GetString("CurrentItem").StartsWith("Promo") && PlayerPrefs.GetInt("EspecialApplied") == 1)
        {
            clientDialogue.text = "¡Ya has aplicado la promoción!";
            cashierSFX.PlayError();
        }

        else
        {
            // clientDialogue.text = "¡No es lo que pedí!";
            cashierSFX.PlayError();

            if (PlayerPrefs.GetInt("Puntos") - 50 >= 0)
            {
                PlayerPrefs.SetInt("Puntos", PlayerPrefs.GetInt("Puntos") - 50);
                UpdatePuntos();
            }
        }
    }

    public void Update()
    {
        if (PlayerPrefs.GetInt("Time") <= 0)
        {
            string postURL = "https://10.22.179.245:7149/Ranking/PostRanking";
            string puntosURL = "https://10.22.179.245:7149/Usuarios/UpdatePuntos";
            string expURL = "https://10.22.179.245:7149/Usuarios/UpdateExperiencia";

            int newPuntaje = PlayerPrefs.GetInt("Puntos") + PlayerPrefs.GetInt("PuntosUsuario");
            int newEXP = PlayerPrefs.GetInt("ExperienciaUsuario") + (newPuntaje / 10);

            PlayerPrefs.SetInt("ExperienciaUsuario", newEXP);
            PlayerPrefs.SetInt("PuntosUsuario", newPuntaje);

            PostRankingMini1(postURL);
            UpdatePuntosDB(puntosURL);
            UpdateExperienciaDB(expURL);
            SceneManager.LoadScene("EndingScene");
        }
    }

    void PostRankingMini1(string mediaURL)
    {
        Ranking ranking = new Ranking
        {
            puntaje = PlayerPrefs.GetInt("Puntos"),
            fecha_puntaje = System.DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"),
            id_usuario = PlayerPrefs.GetInt("IdUsuario"),
            id_minijuego = 1
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

    void UpdatePuntosDB(string mediaURL)
    {
        int puntos = PlayerPrefs.GetInt("PuntosUsuario");
        int id = PlayerPrefs.GetInt("IdUsuario");

        string url = $"{mediaURL}/{id}/{puntos}";

        UnityWebRequest request = UnityWebRequest.Put(url, "");
        request.certificateHandler = new ForceAcceptAll();

        request.SendWebRequest();
    }

    void UpdateExperienciaDB(string mediaURL)
    {
        int experiencia = PlayerPrefs.GetInt("ExperienciaUsuario");
        int id = PlayerPrefs.GetInt("IdUsuario");

        string url = $"{mediaURL}/{id}/{experiencia}";

        UnityWebRequest request = UnityWebRequest.Put(url, "");
        request.certificateHandler = new ForceAcceptAll();

        request.SendWebRequest();
    }
}