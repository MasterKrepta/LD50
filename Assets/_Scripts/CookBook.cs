using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CookBook : MonoBehaviour
{
    public int LogSize = 7;
    //Stack<Recipie> Recipies = new Stack<Recipie>();
    public Recipie recepiePrefab;
    DropSlot dropSlot;

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
        print($"{firstIngredient.name} + {secondIngredient.name}");
        if (transform.childCount > LogSize)
        {
            Recipie[] children = GetComponentsInChildren<Recipie>();

            foreach (Recipie child in children)
            {
                Destroy(child.gameObject);
            }


        }

        bool item1Match = false, item2Match = false;
        
        foreach (Effect effect in Helpers.Instance.PossibleEffects)
        {
            if (effect.ingredients.Contains(firstIngredient) || effect.ingredients.Contains(secondIngredient))
            {
                //First Ingrediiant found, color ui
                print("First");
                item1Match = true;
            }
            if (effect.ingredients.Contains(secondIngredient) ||effect.ingredients.Contains(firstIngredient))
            {
                //second Ingrediiant found, color ui
                print("Second");
                item2Match = true;

            }

            //if (effect.ingredients.Contains(firstIngredient) && effect.ingredients.Contains(secondIngredient))
            if (item1Match && item2Match)
            {
                //Generate Result
                print("Effect works");

                Recipie newRecipe = Instantiate(recepiePrefab, transform.parent.position, Quaternion.identity);
                newRecipe.transform.SetParent(this.transform);
                newRecipe.InitRecipie(effect);
                
                break;

            }
            else
            {
                Recipie newRecipe = Instantiate(recepiePrefab, transform.parent.position, Quaternion.identity);
                newRecipe.transform.SetParent(this.transform);
                newRecipe.InitRecipie(firstIngredient.name, secondIngredient.name, "None", item1Match, item2Match);
                
                break;
            }
        }


 
    
    }
}
