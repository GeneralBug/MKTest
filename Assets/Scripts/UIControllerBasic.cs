using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIControllerBasic : UIController
{
    public Text questionText;
    public Text roundResults;

    public override void UpdateQuestion(Color value, string word)
    {
        questionText.color = value;
        questionText.text = word;
    }

    public override void ShowRoundResults(bool result)
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

    public override void HideRoundResults()
    {
        roundResults.text = "";
        foreach (Button button in buttonParent.GetComponentsInChildren<Button>())
        {
            button.interactable = true;
        }
    }

    public override void ShowGameResults(int score, int round_count, System.TimeSpan timeDelta, System.TimeSpan timeAverage)
    {
        gameParent.SetActive(false);
        resultFields[0].text = score + " / " + round_count;
        resultFields[1].text = timeDelta.ToString("mm':'ss");
        resultFields[2].text = timeAverage.ToString("mm':'ss");
        resultsParent.SetActive(true);

    }
}
