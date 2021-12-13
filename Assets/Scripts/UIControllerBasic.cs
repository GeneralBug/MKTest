using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIControllerBasic : MonoBehaviour
{
    //TODO: plan to replace with fancier one after basic implementation is complete

    public GameObject gameParent;
    public GameObject resultsParent;
    public Text[] resultFields; //not very nice

    public Transform buttonParent;
    public GameObject buttonPrefab;
    public Text questionText;
    public Text roundResults;
    public void AddButton(Colour colour)
    {
        GameObject button = Instantiate(buttonPrefab, buttonParent);
        button.GetComponent<ColourOptionButton>().SetColour(colour);
    }

    public void UpdateQuestion(Color value, string word)
    {
        questionText.color = value;
        questionText.text = word;
    }

    public void ShowRoundResults(bool result)
    {
        foreach(Button button in buttonParent.GetComponentsInChildren<Button>())
        {
            button.interactable = false;
        }
        if (result)
            roundResults.text = "Correct!";
        else
            roundResults.text = "Incorrect!";

    }

    public void HideRoundResults()
    {
        roundResults.text = "";
        foreach (Button button in buttonParent.GetComponentsInChildren<Button>())
        {
            button.interactable = true;
        }
    }

    public void ShowGameResults(int score, int round_count, System.TimeSpan timeDelta)
    {
        //TODO: figure out average time
        //System.TimeSpan timeAverage = (int)timeDelta/round_count;
        gameParent.SetActive(false);
        resultFields[0].text = score + " / " + round_count;
        resultFields[1].text = timeDelta.Minutes + ":" + timeDelta.Seconds;
        //resultFields[2].text = timeAverage
        resultsParent.SetActive(true);

    }
}
