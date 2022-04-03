using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class SaveSlot : MonoBehaviour, IDropHandler
{
    RectTransform slotTransform;

    private void Awake()
    {
        slotTransform = GetComponent<RectTransform>();
    }

    public void OnDrop(PointerEventData eventData)
    {
        if (gameObject.transform.childCount > 0)
        {
            eventData.pointerDrag.GetComponent<DragDrop>().Reset();
            return;
        }
        

        if (eventData.pointerDrag != null)
        {

            eventData.pointerDrag.transform.SetParent(slotTransform);
            eventData.pointerDrag.GetComponent<RectTransform>().anchoredPosition = slotTransform.anchoredPosition;
            //Destroy(eventData.pointerDrag);
            Helpers.Instance.DealNewCard();
        }
    }

 
}
