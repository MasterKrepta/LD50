using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CookBook : MonoBehaviour
{
    public int LogSize = 7;
    //Stack<Recipie> Recipies = new Stack<Recipie>();
    public Recipie recepiePrefab;
    DropSlot dropSlot;
    bool item1Match = false, item2Match = false, recipieComplete = false;
    Effect activeEffect;
    Ingredient remainingIngrediant;


    private void Awake()
    {
        dropSlot = FindObjectOfType<DropSlot>();
    }
    private void OnEnable()
    {
        dropSlot.OnNewRecpie += LogRecipie;
    }

    private void OnDisable()
    {
        dropSlot.OnNewRecpie -= LogRecipie;
    }


    public void LogRecipie(Ingredient firstIngredient, Ingredient secondIngredient)
    {
        ResetData();

        //todo Debug this
        foreach (Effect effect in Helpers.Instance.PossibleEffects)
        {
            remainingIngrediant = MatchItem1(firstIngredient);

            if (remainingIngrediant == null)
            {
                remainingIngrediant = MatchItem2(secondIngredient);
            }
            else
            {
                recipieComplete = MatchRemainingIngredient(secondIngredient);

            }


            #region
            ////DO we have ANY MATCHES
            //foreach (Ingredient ingredient in effect.ingredients)
            //{
            //    if (firstIngredient == ingredient)
            //    {
            //        remainingIngrediant = effect.ingredients[0];
            //        item1Match = true;

            //        break;
            //    }
            //}

            ////if we DO NOT have any matches
            //if (remainingIngrediant = null)
            //{
            //    //See if SECOND INGREDIENT matches ANY
            //    foreach (Ingredient ingredient in effect.ingredients)
            //    {
            //        if (secondIngredient == ingredient)
            //        {
            //            remainingIngrediant = effect.ingredients[0];
            //            item1Match = true;

            //            break;
            //        }
            //    }
            //}
            //else
            //{
            //    //we HAVE A SINGLE MATCH
            //    foreach (Ingredient ingredient in effect.ingredients)
            //    {
            //        if (remainingIngrediant == ingredient)
            //        {
            //            item1Match = true;

            //            break;
            //        }
            //    }
            //}




            //if (remainingIngrediant = null)
            //{
            //    if (effect.ingredients.Contains(remainingIngrediant) || effect.ingredients.Contains(remainingIngrediant))
            //    {
            //        //second Ingrediiant found, color ui
            //        item2Match = true;

            //    }
            //}
            //else
            //{
            //    foreach (Ingredient ingredient in effect.ingredients)
            //    {
            //        if (remainingIngrediant == ingredient)
            //        {
            //            item2Match = true;

            //            break;
            //        }
            //    }
            //}

            //if (effect.ingredients.Contains(firstIngredient) && effect.ingredients.Contains(secondIngredient))
            //if (item1Match && item2Match)
            #endregion



            if (recipieComplete)
            {
                Helpers.Instance.ApplyEffect(activeEffect);
                //Generate Result
                print("Effect works");
                
                Helpers.Instance.IncreaseLevel();

                //Create Recepie
                Recipie newRecipe = Instantiate(recepiePrefab, transform.parent.position, Quaternion.identity);
                newRecipe.transform.SetParent(this.transform);
                newRecipe.InitRecipie(activeEffect);

                if (activeEffect.Discovered == false)
                {
                    activeEffect.Discovered = true;
                    ////Save Referance Recepie
                    Recipie refRecipie = Instantiate(recepiePrefab, transform.parent.position, Quaternion.identity);
                    refRecipie.transform.SetParent(Helpers.Instance.ReferanceLibrary.transform);
                    
                    refRecipie.InitRecipie(activeEffect);
                }
                



                break;

            }
            else
            {
                Helpers.Instance.ApplyDamage();
                Recipie newRecipe = Instantiate(recepiePrefab, transform.parent.position, Quaternion.identity);
                newRecipe.transform.SetParent(this.transform);
                newRecipe.InitRecipie(firstIngredient.name, secondIngredient.name, "None", item1Match, item2Match);
                break;
            }
        }

    }

    private void ResetData()
    {
        CleanUpLog();
        recipieComplete = false;
        remainingIngrediant = null;
        item1Match = false;
        item2Match = false;
        activeEffect = null;
    }

    private Ingredient MatchItem1(Ingredient firstIngredient)
    {
        foreach (Effect effect in Helpers.Instance.PossibleEffects)
        {
            for (int i = 0; i < effect.ingredients.Count; i++)
            {
                if (effect.ingredients.Contains(firstIngredient))
                {
                    item1Match = true;
                    activeEffect = effect;
                    return effect.ingredients[i];
                }
            }
        }
        return null;
    }

    private Ingredient MatchItem2(Ingredient secondIngredient)
    {
        foreach (Effect effect in Helpers.Instance.PossibleEffects)
        {
            for (int i = 0; i < effect.ingredients.Count; i++)
            {
                if (effect.ingredients.Contains(secondIngredient))
                {
                    item2Match = true;
                    return effect.ingredients[i];
                }
            }
        }
        return null;
    }

    private bool MatchRemainingIngredient(Ingredient secondIngredient)
    {
        if (activeEffect.ingredients.Contains(secondIngredient))
        {
            item2Match = true;
            return true;
        }
         
        return false;
    }

    private void CleanUpLog()
    {
        if (transform.childCount > LogSize)
        {
            Recipie[] children = GetComponentsInChildren<Recipie>();

            foreach (Recipie child in children)
            {
                Destroy(child.gameObject);
            }
        }
    }
}
