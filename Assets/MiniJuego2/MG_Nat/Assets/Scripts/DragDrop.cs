using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DragDrop : MonoBehaviour, IPointerDownHandler, IBeginDragHandler, IEndDragHandler, IDragHandler
{
    [SerializeField] private Canvas canvas;
    private RectTransform rectTransform;
    public bool isLocked; 
    
    private void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        Debug.Log("OnBeginDrag");
    }

    public void OnDrag(PointerEventData eventData)
    {
        if (!isLocked)
        {
            rectTransform.anchoredPosition += eventData.delta / canvas.scaleFactor;
            Debug.Log("OnDrag");
        }
    }

    public void OnPointerDown(PointerEventData eventData){
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        isLocked = true; 
    }
}
