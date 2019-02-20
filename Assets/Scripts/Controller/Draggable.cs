using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Draggable : MonoBehaviour, IPointerDownHandler, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    private Vector2 offset;
    public Transform parentToReturnTo = null;
    GameObject placeholder = null;
    GameObject command = null;
    
    // interface function must be public
    public void OnPointerDown(PointerEventData eventData)
    {
        offset = this.transform.position;
        offset -= eventData.position;
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        placeholder = new GameObject();
        placeholder.transform.SetParent(this.transform.parent);
        RectTransform rt = placeholder.AddComponent<RectTransform>();        
        LayoutElement le = placeholder.AddComponent<LayoutElement>();
        rt.sizeDelta = new Vector2(50, 50);
        le.preferredWidth = this.GetComponent<LayoutElement>().preferredWidth;
        le.preferredHeight = this.GetComponent<LayoutElement>().preferredHeight;
        //need this or else is always 100 100
        rt.sizeDelta = new Vector2(le.preferredWidth, le.preferredHeight);
        le.flexibleWidth = 0;
        le.flexibleHeight = 0;

        placeholder.transform.SetSiblingIndex(this.transform.GetSiblingIndex());

        parentToReturnTo = this.transform.parent;
        this.transform.SetParent(this.transform.parent.parent);

        GetComponent<CanvasGroup>().blocksRaycasts = false;
    }

    public void OnDrag(PointerEventData eventData)
    {
        this.transform.position = (eventData.position + offset);
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        this.transform.SetParent(parentToReturnTo);
        this.transform.SetSiblingIndex(placeholder.transform.GetSiblingIndex()); 
        GetComponent<CanvasGroup>().blocksRaycasts = true;
        Destroy(placeholder);
    }
}
