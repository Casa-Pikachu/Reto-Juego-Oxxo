using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class dragableItemV3 : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler

//script hecho con tutorial 
{
    public Image image;
    [HideInInspector] public Transform parentAfterDrag; 

    public void OnBeginDrag(PointerEventData eventData)
    {
        Debug.Log("Begin drag");
        parentAfterDrag = transform.parent;
        transform.SetParent(transform.root);
        transform.SetAsLastSibling(); 
        image.raycastTarget = false; 
      

    }

    public void OnDrag(PointerEventData eventData)
    {
        Debug.Log("Dragging");
        transform.position = Input.mousePosition; 
    }

   


    public void OnEndDrag(PointerEventData eventData)
{
    Debug.Log("End drag");

    if (eventData.pointerEnter != null)
    {
        InventorySlotV3 slot = eventData.pointerEnter.GetComponent<InventorySlotV3>();
        if (slot != null)
        {
            transform.SetParent(slot.transform);
            image.raycastTarget = true;
            return;
        }
    }

   
    transform.SetParent(parentAfterDrag);
    image.raycastTarget = true;
}

    
    void Start()
    {
        
    }


    void Update()
    {
        
    }
}
