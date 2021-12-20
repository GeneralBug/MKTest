using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//used to store possible colour selections and modify them in the editor

[System.Serializable]
public class Colour
{
    [SerializeField]
    private string name;
    [SerializeField]
    private Color value;

    public Colour(string name)
    {
        this.name = name;
        value = Color.clear;
    }

    public string GetName() { return name; }
    public Color GetValue() { return value; }
}

[CreateAssetMenu(fileName = "Colours", menuName = "ScriptableObjects/ColourContainer", order = 1)]
public class ColourContainer : ScriptableObject
{
    public Colour[] colours;
}
