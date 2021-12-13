using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Colour
{
    public string name;
    public Color value;
}

[CreateAssetMenu(fileName = "Colours", menuName = "ScriptableObjects/DataContainer", order = 1)]
public class ColourContainer : ScriptableObject
{
    public Colour[] colours;
}
