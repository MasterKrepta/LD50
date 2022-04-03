using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Card : MonoBehaviour
{
    public Ingredient ingredient;
    [SerializeField] Image Icon;
    [SerializeField] TMP_Text Name;
    [SerializeField] TMP_Text Qty;


    private void Start()
    {
        ingredient = Helpers.Instance.GetRandIngrediant();
        
        InitCard();
    }

    private void InitCard()
    {
        //Icon.sprite = ingredient.Icon;
        Icon.color = ingredient.color;
        Name.text = ingredient.Name;
        Icon.GetComponentInChildren<TMP_Text>().text = ingredient.graphicChar.ToString();
        Qty.text = $"Qty: {ingredient.Qty.ToString()}";
    }
}
