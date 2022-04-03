using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Helpers : MonoBehaviour
{
    public  List<Ingredient> PossibleIngredients = new List<Ingredient>();
    public List<Effect> PossibleEffects = new List<Effect>();
    public GameObject cardParent;
    public Card cardPrefab;
    public int CardLevel = 1;
    public GameObject ReferanceLibrary;

    public Slider HealthUI;
    Animator sliderAnim;
    public Animator playerAnim;

    [Space(20)]
    [Header("GamePlay Rules")]
    private float _currentHealth;

    public float CurrentHealth
    {
        get { return _currentHealth; }
        set { 
            _currentHealth = value;
            HealthUI.value = CurrentHealth / MaxHealth;
        }
    }

    public int MaxHealth = 50;

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

        CurrentHealth = MaxHealth;
        sliderAnim = HealthUI.GetComponent<Animator>();
        

    }

    private void InitEffects()
    {
        Effect[] effects = Resources.FindObjectsOfTypeAll<Effect>();

        PossibleEffects.Clear(); // Sanity check

        foreach (Effect e in effects)
        {
            PossibleEffects.Add(e);
        }
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
            if (item.Level == 1)
            {
                PossibleIngredients.Add(item);
            }
            
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

    //GAMEPLAY 
    public void IncreaseLevel()
    {

        //TODO generate Visual Effect
        CardLevel++;

        Ingredient[] items = Resources.FindObjectsOfTypeAll<Ingredient>();


        foreach (Ingredient item in items)
        {
            if (item.Level == CardLevel)
            {
                PossibleIngredients.Add(item);
            }

        }
    }

    public void ApplyEffect(Effect effect)
    {
        sliderAnim.Play("healthBarHeal");
        playerAnim.SetTrigger("HealDamage");
        CurrentHealth += effect.Power;
    }

    public void ApplyDamage()
    {
        sliderAnim.Play("healthBarDamage");
        playerAnim.SetTrigger("TakeDamage");
        CurrentHealth--;
    }
}
