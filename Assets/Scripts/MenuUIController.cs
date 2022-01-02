using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuUIController : MonoBehaviour
{
    public SettingsContainer setCon;
    public ColourContainer colCon;
    public Text3D text3D;
    public GameObject title;
    public Text roundLabel;
    public Text colourLabel;

    public void Start()
    {
        UpdateLabels();
        text3D.DrawText("Stroop Test Game", title.GetComponent<HorizontalLayoutGroup>());
        text3D.mat.color = colCon.colours[Random.Range(0, colCon.colours.Length)].GetValue();
    }

    public void UpdateLabels()
    {
        roundLabel.text = setCon.roundCount.ToString();
        colourLabel.text = setCon.colourCount.ToString();
    }
}
