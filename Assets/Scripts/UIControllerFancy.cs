using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIControllerFancy : UIController
{
    public TextMeshPro questionText;
    public TextMeshPro roundResults;
    public Animator screenWipe;
    public override void HideRoundResults()
    {
        roundResults.text = "";
        foreach (Button button in buttonParent.GetComponentsInChildren<Button>())
        {
            button.interactable = true;
        }
    }

    public override void ShowGameResults(int score, int round_count, TimeSpan timeDelta, TimeSpan timeAverage)
    {
        StartCoroutine(ShowGameResultsRoutine(score, round_count, timeDelta, timeAverage));
    }

    public override void ShowRoundResults(bool result)
    {
        //todo: particles
        foreach (Button button in buttonParent.GetComponentsInChildren<Button>())
        {
            button.interactable = false;
        }
        if (result)
            roundResults.text = "Correct!";
        else
            roundResults.text = "Incorrect!";

    }

    public override void UpdateQuestion(Color value, string word)
    {
        //todo: particles
        questionText.text = word;
        questionText.color = value;
    }

    IEnumerator ShowGameResultsRoutine(int score, int round_count, TimeSpan timeDelta, TimeSpan timeAverage)
    {
        screenWipe.SetTrigger("Conceal");
        yield return new WaitForSeconds(1);

        gameParent.SetActive(false);
        resultFields[0].text = score + " / " + round_count;
        resultFields[1].text = timeDelta.ToString("mm':'ss");
        resultFields[2].text = timeAverage.ToString("mm':'ss");
        resultsParent.SetActive(true);

        yield return new WaitForSeconds(0.1f);
        screenWipe.SetTrigger("Reveal");
    }
}
