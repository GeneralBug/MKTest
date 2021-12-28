using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuUIController : MonoBehaviour
{
    public SettingsContainer setCon;
    public ColourContainer colCon;
    public GameObject title;
    public Text roundLabel;
    public Text colourLabel;

    public void Start()
    {
        UpdateLabels();
        try
        {
            Debug.Log("looking for textmesh");
            title.GetComponent<TMPro.TextMeshPro>().color = colCon.colours[Random.Range(0, colCon.colours.Length)].GetValue();

        }
        catch (System.NullReferenceException)
        {
            Debug.Log("looking for text");
            title.GetComponent<Text>().color = colCon.colours[Random.Range(0, colCon.colours.Length)].GetValue();
        }
    }

    public void UpdateLabels()
    {
        roundLabel.text = setCon.roundCount.ToString();
        colourLabel.text = setCon.colourCount.ToString();
    }
}
