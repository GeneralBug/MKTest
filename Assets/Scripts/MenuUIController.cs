using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuUIController : MonoBehaviour
{
    public SettingsContainer setCon;
    public ColourContainer colCon;
    public Text title;
    public Text roundLabel;
    public Text colourLabel;

    public void Start()
    {
        UpdateLabels();
        title.color = colCon.colours[Random.Range(0, colCon.colours.Length)].value;
    }

    public void UpdateLabels()
    {
        roundLabel.text = setCon.roundCount.ToString();
        colourLabel.text = setCon.colourCount.ToString();
    }
}
