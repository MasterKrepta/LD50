using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DropSlot : MonoBehaviour, IDropHandler
{
    RectTransform slotTransform;
    public Action<Ingredient, Ingredient> OnNewRecpie = delegate { };
    public List<Ingredient> activeIngredients = new List<Ingredient>();

    private void Awake()
    {
        slotTransform = GetComponent<RectTransform>();
    }
    public void OnDrop(PointerEventData eventData)
    {
        if (eventData.pointerDrag != null)
        {
            //TOdo Make dropped card not selectable

            eventData.pointerDrag.transform.SetParent(slotTransform);
            eventData.pointerDrag.GetComponent<RectTransform>().anchoredPosition = slotTransform.anchoredPosition;
            //Destroy(eventData.pointerDrag);
            Helpers.Instance.DealNewCard();

            //TODO trigger Effect
            activeIngredients.Add(eventData.pointerDrag.gameObject.GetComponent<Card>().ingredient);

            if (activeIngredients.Count >= 2)
            {
                OnNewRecpie(activeIngredients[0], activeIngredients[1]);
                activeIngredients.Clear();
                Card[] activeCards = GetComponentsInChildren<Card>();
                foreach (Card card in activeCards)
                {
                    Destroy(card.gameObject);
                }
            }
            

        }
    }
}
