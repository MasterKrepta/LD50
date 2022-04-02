using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewEffect",menuName = "Effects")]
public class Effect : ScriptableObject
{
    public List<Ingredient> ingredients;

    public Sprite Icon;
    public string Name;
    public float Power = 1;
}
