using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using System.Collections.Generic;

public class Client : MonoBehaviour
{
    [SerializeField] private List<GameObject> itemPrefabs; // Lista de prefabs
    [SerializeField] private Transform startField;
    public string clientID;
    public int generatedItemsCount = 0;
    public int numRecargas = 0;
    public int maxItems;
    public Text clientDialogue;
    public Text productoText;
    public Text precioText;

    private void Start()
    {
        startField = GameObject.Find("StartField").transform;
        clientDialogue = GameObject.Find("ClientDialogue").GetComponent<Text>();
        productoText = GameObject.Find("DisplayProducto").GetComponent<Text>();
        precioText = GameObject.Find("DisplayPrecio").GetComponent<Text>();
        PlayerPrefs.SetInt("CanSpawn", 1);
        PlayerPrefs.SetInt("OrderFinished", 0);
        maxItems = Random.Range(1, 5);
        PlayerPrefs.SetString("CurrentItem", "None");
    }

    private void Update()
    {
        if (PlayerPrefs.GetInt("CanSpawn") == 1 && generatedItemsCount < maxItems && PlayerPrefs.GetInt("OrderFinished") == 0)
        {
            generatedItemsCount++;
            PlayerPrefs.SetInt("CanSpawn", 0);
            SpawnRandomItem();
        }

        if (generatedItemsCount == maxItems && PlayerPrefs.GetInt("CanSpawn") == 1 && PlayerPrefs.GetInt("OrderFinished") == 0)
        {
            clientDialogue.text = "Sería todo";
            PlayerPrefs.SetInt("OrderFinished", 1);
        }
    }

    private void SpawnRandomItem()
    {
        if (itemPrefabs != null && itemPrefabs.Count > 0 && startField != null)
        {
            // Selecciona un prefab aleatorio de la lista

            if (numRecargas == 1)
            {
                itemPrefabs.RemoveAll(item => item.name == "Recarga");
            }

            int randomIndex = Random.Range(0, itemPrefabs.Count);
            GameObject selectedPrefab = itemPrefabs[randomIndex];

            if (selectedPrefab.name == "Recarga")
            {
                numRecargas++;
            }

            // Instancia el prefab seleccionado
            GameObject newItem = Instantiate(selectedPrefab, startField.position, Quaternion.identity);
            newItem.transform.SetParent(startField);

            PlayerPrefs.SetString("CurrentItem", newItem.GetComponent<DraggableItem>().itemName);
            Debug.Log($"Current item: {PlayerPrefs.GetString("CurrentItem")}");
        }
    }


}