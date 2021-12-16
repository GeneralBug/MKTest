using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//used to store possible colour selections and modify them in the editor

[System.Serializable]
public class Colour
{
    public string name;
    public Color value;
}

[CreateAssetMenu(fileName = "Colours", menuName = "ScriptableObjects/ColourContainer", order = 1)]
public class ColourContainer : ScriptableObject
{
    public Colour[] colours;
}
