using System.Diagnostics.Tracing;
using System.Collections; 
using System.Collections.Generic; 
using UnityEngine;
using UnityEngine.EventSystems;

public class InventoryS : MonoBehaviour, IDropHandler //se llama cuando esta onDrop
{
    [SerializeField] float numObj;
    public void OnDrop(PointerEventData eventData)
    {
        if (transform.childCount < numObj)
        {
            GameObject dropped = eventData.pointerDrag;
            DnD dragItem = dropped.GetComponent<DnD>();
            dragItem.parentAfterDrag = transform;
         }
    } 
}
