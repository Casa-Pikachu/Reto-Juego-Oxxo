using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class DnD : MonoBehaviour, IBeginDragHandler, IEndDragHandler, IDragHandler
{
    public Image image;
    [HideInInspector] public Transform parentAfterDrag; //modificamos el padre del item para que cambie el grid

    public void OnBeginDrag(PointerEventData eventData)
    {
        //se llama cuando el mouse se presione
       
        //Debug.Log("Begin Drag");
        parentAfterDrag = transform.parent; //pedimos cambio de padre
        transform.SetParent(GameObject.Find("the Grid").transform); //se pone como hijo especificamente de the grid
        transform.SetAsLastSibling(); //ultimo objeto para que este en la capa de arriba
        image.raycastTarget = false; //
    }

    public void OnDrag(PointerEventData eventData)
    {
        //Debug.Log("Dragging");
        transform.position = Input.mousePosition;
    }

    public void OnEndDrag(PointerEventData eventData)
    { 
        //GameManager.Instance.SFXManager.tirar();

        //Debug.Log("OnEndDrag");
        transform.SetParent(parentAfterDrag);
        image.raycastTarget = true;
    }


    
}
