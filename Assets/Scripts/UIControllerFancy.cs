using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIControllerFancy : UIController
{
    public TextMeshPro questionText;
    public TextMeshPro roundResults;

    public override void HideRoundResults()
    {
        //TODO
        throw new NotImplementedException();
    }

    public override void ShowGameResults(int score, int round_count, TimeSpan timeDelta, TimeSpan timeAverage)
    {
        //TODO
        throw new NotImplementedException();
    }

    public override void ShowRoundResults(bool result)
    {
        //TODO
        throw new NotImplementedException();
    }

    public override void UpdateQuestion(Color value, string word)
    {
        //todo: particles
        questionText.text = word;
        questionText.color = value;
    }
}
