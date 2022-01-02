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
        GetComponentInChildren<Text>().text = colour.GetName();

    }

    public void ButtonPressed()
    {
        FindObjectOfType<GameController>().ColourOptionSelected(colour);
    }
}
