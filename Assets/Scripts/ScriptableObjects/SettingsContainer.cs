using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//used to carry game settings between the menu and game scenes

[CreateAssetMenu(fileName = "Settings", menuName = "ScriptableObjects/SettingsContainer", order = 1)]
public class SettingsContainer : ScriptableObject
{
    public const int RC_min = 5;
    public const int RC_max = 30;
    public const int CC_min = 3;
    public const int CC_max = 6;

    [Range(RC_min,RC_max)]
    public int roundCount;
    [Range(CC_min, CC_max)]
    public int colourCount;
}
