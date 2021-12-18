using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public abstract class UIController : MonoBehaviour
{
    public abstract void AddButton(Colour colour);

    public abstract void UpdateQuestion(Color value, string word);

    public abstract void ShowRoundResults(bool result);

    public abstract void HideRoundResults();

    public abstract void ShowGameResults(int score, int round_count, System.TimeSpan timeDelta, System.TimeSpan timeAverage);

}
