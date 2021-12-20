using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ColourOptionButton : MonoBehaviour
{
    private Colour colour;
    private GameController controller;

    public void SetColour(Colour colour)
    {
        this.colour = colour;
        try
        {
            Debug.Log("looking for textmesh");
            GetComponentInChildren<TMPro.TextMeshProUGUI>().text = colour.GetName();

        }
        catch (System.NullReferenceException)
        {
            Debug.Log("looking for text");
            GetComponentInChildren<Text>().text = colour.GetName();
        }

    }

    public void ButtonPressed()
    {
        FindObjectOfType<GameController>().ColourOptionSelected(colour);
    }
}
