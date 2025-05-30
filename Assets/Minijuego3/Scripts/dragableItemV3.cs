using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class dragableItemV3 : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler

//script hecho con tutorial 
{
    public Image image;
    [HideInInspector] public Transform parentAfterDrag; //guardar el padre oirginal 

    public void OnBeginDrag(PointerEventData eventData)
    {
        Debug.Log("Begin drag");
        parentAfterDrag = transform.parent;
        transform.SetParent(transform.root);
        transform.SetAsLastSibling(); //para que se vaya al frente
        image.raycastTarget = false; //no detecte que hya un objeto en el slot 
      

    }

    public void OnDrag(PointerEventData eventData)
    {
        Debug.Log("Dragging");
        transform.position = Input.mousePosition; //para que si lo arrastre el mouse 
    }

   


    public void OnEndDrag(PointerEventData eventData)
{
    Debug.Log("End drag");

    // Verifica si lo soltaste sobre un slot válido
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

    // Si no fue sobre un slot válido, vuelve al padre original
    transform.SetParent(parentAfterDrag);
    image.raycastTarget = true;
}

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
