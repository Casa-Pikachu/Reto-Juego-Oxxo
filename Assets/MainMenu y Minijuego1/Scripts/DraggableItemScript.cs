using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using Newtonsoft.Json;
using UnityEngine.Networking;

public class DraggableItem : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    public Image itemImage;
    public string itemName;
    public int itemPrice;
    public int itemPuntos;
    [HideInInspector] public Transform parentAfterDrag;

    private void Start()
    {
        string mediaUrl = "https://192.168.1.102:7149/Precios/GetPrecio/";

        itemPrice = GetPrecio(mediaUrl, itemName).precio_articulo;
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        parentAfterDrag = transform.parent;
        transform.SetParent(transform.root);
        transform.SetAsLastSibling();
        itemImage.raycastTarget = false;
    }

    public void OnDrag(PointerEventData eventData)
    {
        transform.position = Input.mousePosition;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        transform.SetParent(parentAfterDrag);
        itemImage.raycastTarget = true;
    }

    public static Precios GetPrecio(string mediaUrl, string nombre_articulo)
    {
        UnityWebRequest request = UnityWebRequest.Get(mediaUrl + nombre_articulo);
        request.certificateHandler = new ForceAcceptAll();
        request.SendWebRequest();

        while (!request.isDone) { }

        if (request.result == UnityWebRequest.Result.ConnectionError || request.result == UnityWebRequest.Result.ProtocolError)
        {
            Debug.LogError("Error: " + request.error);
            return null;
        }

        string jsonResponse = request.downloadHandler.text;
        Precios precio = JsonConvert.DeserializeObject<Precios>(jsonResponse);
        return precio;
    }
}