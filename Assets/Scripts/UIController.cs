using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public abstract class UIController : MonoBehaviour
{
    public Transform buttonParent;
    public GameObject buttonPrefab;

    public void AddButton(Colour colour)
    {
        GameObject button = Instantiate(buttonPrefab, buttonParent);
        button.GetComponent<ColourOptionButton>().SetColour(colour);
    }

    public abstract void UpdateQuestion(Color value, string word);

    public abstract void ShowRoundResults(bool result);

    public abstract void HideRoundResults();

    public abstract void ShowGameResults(int score, int round_count, System.TimeSpan timeDelta, System.TimeSpan timeAverage);

}
