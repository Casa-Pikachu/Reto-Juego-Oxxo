using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;
using UnityEngine.UI;


public class ItemSpawn : MonoBehaviour
{
    public GameObject Spawner;
    public Transform spawnerParent;
    void Update()
    {

        if (spawnerParent.childCount == 0)
        {
            GameObject newitem = Instantiate(Spawner, spawnerParent.position, Quaternion.identity);
            newitem.transform.SetParent(spawnerParent);
            Image img = newitem.GetComponent<Image>();
            img.raycastTarget = true;
        }
    }

}
