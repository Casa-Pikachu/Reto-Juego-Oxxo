using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using System.Collections.Generic;


public class ClientSpawner : MonoBehaviour
{
    [SerializeField] private List<GameObject> clientPrefabs;
    [SerializeField] private Transform clientField;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        PlayerPrefs.SetInt("CanSpawn", 1);
        PlayerPrefs.SetInt("OrderFinished", 0);
        clientField = GameObject.Find("ClientField").transform;
        SpanwRandomClient();
    }

    // Update is called once per frame
    void Update()
    {
        // Si orderfinished y no hay clientes en escena
        if (PlayerPrefs.GetInt("OrderFinished") == 1 && GameObject.FindGameObjectsWithTag("Client").Length == 0)
        {
            PlayerPrefs.SetInt("OrderFinished", 0);
            SpanwRandomClient();
        }

    }

    private void SpanwRandomClient()
    {
        if (clientPrefabs != null && clientPrefabs.Count > 0)
        {
            // Selecciona un prefab aleatorio de la lista
            int randomIndex = Random.Range(0, clientPrefabs.Count);
            GameObject selectedPrefab = clientPrefabs[randomIndex];

            if(PlayerPrefs.GetString("LastClientPrefab") == selectedPrefab.GetComponent<Client>().clientID)
            {
                SpanwRandomClient();
                return;
            }

            // Instancia el prefab seleccionado
            GameObject newItem = Instantiate(selectedPrefab, clientField.position, Quaternion.identity);
            newItem.transform.SetParent(clientField);
        }
    }
    
    
}
