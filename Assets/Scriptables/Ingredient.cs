using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="NewIngredient", menuName = "Ingredient")]
public class Ingredient : ScriptableObject
{
    public int Level = 1;
    public char graphicChar = 'A';
    public Color color;
    public Sprite Icon;
    public string Name;
    public int Qty = 1;

    private void OnEnable()
    {
        color = Random.ColorHSV();
    }
}
