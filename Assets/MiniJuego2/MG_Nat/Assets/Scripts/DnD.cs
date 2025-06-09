using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class DnD : MonoBehaviour, IBeginDragHandler, IEndDragHandler, IDragHandler
{
    public Image image;
    public SFXEstantes SFX;
    [HideInInspector] public Transform parentAfterDrag; //modificamos el padre del item para que cambie el grid

    public void OnBeginDrag(PointerEventData eventData)
    {
        GameManager.Instance.SFX.tirar(); 

        parentAfterDrag = transform.parent; //pedimos cambio de padre
        transform.SetParent(GameObject.Find("the Grid").transform); //se pone como hijo especificamente de the grid
        transform.SetAsLastSibling(); //ultimo objeto para que este en la capa de arriba
        image.raycastTarget = false; //
    }

    public void OnDrag(PointerEventData eventData)
    {
        transform.position = Input.mousePosition;
    }

    public void OnEndDrag(PointerEventData eventData)
    { 
       GameManager.Instance.SFX.tirar();

        transform.SetParent(parentAfterDrag);
        image.raycastTarget = true;
    }


    
}
