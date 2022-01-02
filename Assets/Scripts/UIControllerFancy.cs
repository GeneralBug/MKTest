using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIControllerFancy : UIController
{
    public Text3D text3D;
    public HorizontalLayoutGroup questionText;
    public HorizontalLayoutGroup roundResults;
    public Animator screenWipe;
    public override void HideRoundResults()
    {
        text3D.DrawText("", roundResults);
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
            text3D.DrawText("Correct!", roundResults);
        else
            text3D.DrawText("Incorrect!", roundResults);

    }

    public override void UpdateQuestion(Color value, string word)
    {
        text3D.DrawText(word, questionText);
        text3D.mat.color = value;
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
