using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Recipie : MonoBehaviour
{
    public Image icon;

    public TMP_Text item1, item2, effectResult, powerLevel;
    public Color randColor;

    private void OnEnable()
    {
        //log = GetComponentInChildren<TMP_Text>();
        randColor = Random.ColorHSV();
        
    }
    public void InitRecipie(string Ingrediant1, string Ingrediant2, string result, bool item1Match, bool item2Match) //GOOD lord this is sloppy
    {
        item1.text = Ingrediant1;
        item2.text = Ingrediant2;
        effectResult.text = result;
        powerLevel.text = "";

        if (item1Match)
        {
            item1.color = Color.green;
        }
        if (item2Match)
        {
            item2.color = Color.green;
        }
    }
    public void InitRecipie(Effect effect) 
    {
      
       // print("Effect Valid");
        item1.text = effect.ingredients[0].name;
        item2.text = effect.ingredients[1].name;
        effectResult.text = effect.name;
        icon.color = randColor;
        powerLevel.text = effect.Power.ToString();
        powerLevel.color = Color.red;

        item1.color = Color.green;
        item2.color = Color.green;
        effectResult.color = Color.blue;
    }
    
}
