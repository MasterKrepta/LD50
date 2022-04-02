using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="NewIngredient", menuName = "Ingredient")]
public class Ingredient : ScriptableObject
{
    public Sprite Icon;
    public string Name;
    public int Qty = 1;
}
