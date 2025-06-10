using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
public class ListaGenerador : MonoBehaviour
{
    [System.Serializable] //para que se pueda usar la clase interna 
    public class Producto
    {
        public string nombre;
        public Sprite imagen;
    }

    public List<Producto> productosTotal;
    public int cantAMemorizar = 6;
    public Transform contenedorVisual; //para ui
    public GameObject prefabVisual;

    void Start()
    {

        ListaObjetos.productosObjetivo.Clear();
        List<Producto> seleccionados = new List<Producto>();
        while (seleccionados.Count < cantAMemorizar)
        {
            Producto p = productosTotal[Random.Range(0, productosTotal.Count)];
            
                if (!ListaObjetos.productosObjetivo.Contains(p.nombre))
                {
                    ListaObjetos.productosObjetivo.Add(p.nombre);
                    seleccionados.Add(p);
                    GameObject visual = Instantiate(prefabVisual, contenedorVisual);
                    visual.name = "Producto_" + p.nombre;

                    visual.GetComponentInChildren<Text>().text = p.nombre;
                    visual.GetComponentInChildren<Image>().sprite = p.imagen;
                }

        }
        Debug.Log("Total creados: " + ListaObjetos.productosObjetivo.Count);
        Debug.Log("Productos: " + string.Join(", ", ListaObjetos.productosObjetivo));
    }
    

    
}

