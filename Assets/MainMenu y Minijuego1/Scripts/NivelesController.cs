using UnityEngine;
using UnityEngine.SceneManagement;



public class NivelesController : MonoBehaviour
{
    //referencias, para hacer algo asi
    // https://www.youtube.com/watch?v=hj9ikydHttk 
    // https://www.youtube.com/watch?v=RgQGHmdY3mE

    //sprites para el progreso de la tienda 
    //Nivel0_0
    //Nivel1_0
    //Nivel2_0
    //Nivel3_0
    //Nivel4_0
    //Nivel5_0

    public GameObject[] objectosNivel;



    void Start()

    {
        
        int nivel = SceneManager.GetActiveScene().buildIndex;
        for (int i = 0; i < objectosNivel.Length; i++)
        {
            string escenaNivel = "Nivel" + i + "_0";
            GameObject obj = GameObject.Find(escenaNivel);

            if (obj != null)
            {
                obj.SetActive(i == nivel);
            }

        }
    }



    void Update()
    {


    }
}
