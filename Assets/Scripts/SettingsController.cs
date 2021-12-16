using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SettingsController : MonoBehaviour
{
    public int roundIncrement;
    public SettingsContainer setCon;

    public void IncrementRound()
    {
        setCon.roundCount = Clamp(setCon.roundCount + roundIncrement, SettingsContainer.RC_min, SettingsContainer.RC_max);
    }

    public void DecrementRound()
    {
        setCon.roundCount = Clamp(setCon.roundCount - roundIncrement, SettingsContainer.RC_min, SettingsContainer.RC_max);
    }

    public void IncrementColour()
    {
        setCon.colourCount = Clamp(setCon.colourCount + 1, SettingsContainer.CC_min, SettingsContainer.CC_max);
    }

    public void DecrementColour()
    {
        setCon.colourCount = Clamp(setCon.colourCount - 1, SettingsContainer.CC_min, SettingsContainer.CC_max);
    }

    private int Clamp(int value, int min, int max)
    {
        return (value < min) ? min : (value > max) ? max : value;
    }
}
