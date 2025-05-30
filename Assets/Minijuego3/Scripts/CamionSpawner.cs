using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CamionSpawner : MonoBehaviour
{
    [System.Serializable] 
    public class Producto
    {
         public string nombre;
        public GameObject prefab;
    }
    public List<Producto> productosDisponibles;
    public int cantidadDeProductos = 6;
    public Transform contenedorCanvas;
    public float delayEntreProductos = 0.6f;

    void Start()
    {
        
        StartCoroutine(SpawnProductos());
    }

    IEnumerator SpawnProductos()
    {
        List<string> nombresAMostrar = new List<string>(ListaObjetos.productosObjetivo);
        while (nombresAMostrar.Count < cantidadDeProductos)
        {
            int ind = Random.Range(0, productosDisponibles.Count);
            string extra = productosDisponibles[ind].nombre;
            if (!nombresAMostrar.Contains(extra)) nombresAMostrar.Add(extra);
        }
     
        for (int i = 0; i < nombresAMostrar.Count; i++)
        {
            
            Producto p = productosDisponibles.Find(prod => prod.nombre == nombresAMostrar[i]);
            if (p == null) continue;

            
            GameObject nuevo = Instantiate(p.prefab, contenedorCanvas);
            nuevo.name = p.nombre;

            yield return new WaitForSeconds(delayEntreProductos);
        }
    }
    
    
}
