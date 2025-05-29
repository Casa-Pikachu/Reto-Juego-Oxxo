using System.Collections.Generic;
using Mono.Cecil;
using UnityEngine;
using UnityEngine.UI;

public class ListRand : MonoBehaviour
{
    public List<GameObject> listObj;
    public Transform randParent;
    public CheckEquall CheckEqual;


    void Start()
    {
        GameObject[] objs = new GameObject[3];

        for (int i = 0; i < 3; i++)
        {
            int randomIndex = Random.Range(0, listObj.Count);
            objs[i] = Instantiate(listObj[randomIndex], transform.position, Quaternion.identity, randParent);

            //Deshabilitamos interacción
            Image img = objs[i].GetComponent<Image>();
            img.raycastTarget = false;
        }
        //DontDestroyOnLoad(gameObject);

        //Se asignan a las variables de check equal
        CheckEqual.obj1 = objs[0];
        CheckEqual.obj2 = objs[1];
        CheckEqual.obj3 = objs[2];
        


    }
}
