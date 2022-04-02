using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DropSlot : MonoBehaviour, IDropHandler
{
    RectTransform slotTransform;
    

    private void Awake()
    {
        slotTransform = GetComponent<RectTransform>();
    }
    public void OnDrop(PointerEventData eventData)
    {
        if (eventData.pointerDrag != null)
        {
            //eventData.pointerDrag.GetComponent<RectTransform>().anchoredPosition = slotTransform.anchoredPosition
            Destroy(eventData.pointerDrag);
            Helpers.Instance.DealNewCard();
            //TODO trigger Effect
        }
    }
}
