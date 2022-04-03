using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Helpers : MonoBehaviour
{
    public  List<Ingredient> PossibleIngredients = new List<Ingredient>();
    public List<Effect> PossibleEffects = new List<Effect>();
    public GameObject cardParent;
    public Card cardPrefab;

    public GameObject ReferanceLibrary;

    public static Helpers Instance;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(this);
        }

        InitIngrediants();
        InitEffects();

    }

    private void InitEffects()
    {
        Effect[] effects = Resources.FindObjectsOfTypeAll<Effect>();

        PossibleEffects.Clear(); // Sanity check

        foreach (Effect e in effects)
        {
            PossibleEffects.Add(e);
        }
        print("Effect init");
    }

    private void InitCards()
    {
        DealNewCard();
        DealNewCard();
        DealNewCard();
        DealNewCard();
        DealNewCard();
        DealNewCard();
    }

    private void InitIngrediants()
    {
        Ingredient[] items = Resources.FindObjectsOfTypeAll<Ingredient>();

        PossibleIngredients.Clear(); // Sanity check

        foreach (Ingredient item in items)
        {
            PossibleIngredients.Add(item);
        }
    }

    public Ingredient GetRandIngrediant()
    {
        return PossibleIngredients[Random.Range(0, PossibleIngredients.Count)];
    }

    public void RedealCards()
    {
        Card[] cards = FindObjectsOfType<Card>();
        foreach (Card card in cards)
        {
            Destroy(card.gameObject); 
        }
        
        InitCards();
    
    }

    public void DealNewCard()
    {
        if (cardParent.transform.childCount == 6 )
        {
            return;
        }
        var card = Instantiate(cardPrefab, cardParent.transform.position, Quaternion.identity);
        card.transform.SetParent(cardParent.transform);
    }
}
