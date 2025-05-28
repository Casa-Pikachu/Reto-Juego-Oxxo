using UnityEditor;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

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

            Debug.Log("Order finished, destroying client prefab: " + PlayerPrefs.GetString("LastClientPrefab"));

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
            PlayerPrefs.SetInt("Puntos", PlayerPrefs.GetInt("Puntos") + 50);
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
        if (PlayerPrefs.GetString("CurrentItem") == "Café" && PlayerPrefs.GetInt("EspecialApplied") == 0)
        {
            PlayerPrefs.SetInt("EspecialApplied", 1);
            PlayerPrefs.SetInt("Puntos", PlayerPrefs.GetInt("Puntos") + 100);
            UpdatePuntos();
            clientDialogue.text = "¡Gracias por mi Andatti!";
            cashierSFX.PlayCorrecto();
        }

        else if (PlayerPrefs.GetString("CurrentItem") == "Café" && PlayerPrefs.GetInt("EspecialApplied") == 1)
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
            PlayerPrefs.SetInt("Puntos", PlayerPrefs.GetInt("Puntos") + 150);
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
}