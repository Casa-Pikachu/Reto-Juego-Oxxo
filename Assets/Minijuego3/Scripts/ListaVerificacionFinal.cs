using UnityEngine;
using System.Collections.Generic;

public class ListaVerificacionFinal : MonoBehaviour
{

    public Transform contenedorSlots;
    public List<string> productosColocados = new List<string>();
    public int puntaje;
    public int cantObjetos;
    
    public void Verificar()
    {
        productosColocados.Clear();

        foreach (Transform slot in contenedorSlots)
        {
            if (slot.childCount > 0)
            {
                GameObject producto = slot.GetChild(0).gameObject;
                string nombre = producto.name;

                productosColocados.Add(nombre);
                Debug.Log("Producto en slot: " + nombre);

            }
            else
            {
                Debug.Log("Slot vacio");
            }
        }

        foreach (string nombre in productosColocados)
        {
            if (ListaObjetos.productosObjetivo.Contains(nombre))
            {
                Debug.Log("Correcto: " + nombre);
                puntaje = puntaje + 50;
                cantObjetos = cantObjetos + 1;
            }
            else
            {
                Debug.Log("Incorrecto: " + nombre);
                puntaje = puntaje - 10;
            }
            Debug.Log("Puntaje: " + puntaje);
            PlayerPrefs.SetInt("+", puntaje);
            Debug.Log("cantObjetos: " + cantObjetos);
            PlayerPrefs.SetInt("o", cantObjetos);
        }

    }
    
}


