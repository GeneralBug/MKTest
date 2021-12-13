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
        this.GetComponentInChildren<Text>().text = colour.name;
    }

    public void ButtonPressed()
    {
        FindObjectOfType<GameController>().ColourOptionSelected(colour);
    }
}
