using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;



//hecho con tutorial 
public class InventorySlotV3 : MonoBehaviour, IDropHandler
{

    public void OnDrop(PointerEventData eventData)
    {
        if (transform.childCount == 0)
        {
            GameObject dropped = eventData.pointerDrag;
            dragableItemV3 draggableItem = dropped.GetComponent<dragableItemV3>();
            draggableItem.parentAfterDrag = transform;

            SFXManager sound = FindAnyObjectByType<SFXManager>();
            if (sound != null) sound.GetCoin();

        }

    }
}

