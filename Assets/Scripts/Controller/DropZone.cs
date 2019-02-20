using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;

public class DropZone : MonoBehaviour, IDropHandler
{
    public void OnDrop(PointerEventData eventData) {
        Draggable d = eventData.pointerDrag.GetComponent<Draggable>();
        if(d != null) {
            Debug.Log(eventData.pointerDrag.name + " was dropped on " + gameObject.name);
        }
    }
}
