using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewEffect",menuName = "Effects")]
public class Effect : ScriptableObject
{
    public List<Ingredient> ingredients;

    public char graphicChar = 'A';
    public Color color;
    public Sprite Icon;
    public string Name;
    public bool Discovered = false;
    public float Power = 1;

    private void OnEnable()
    {
        color = Random.ColorHSV();
    }
}
