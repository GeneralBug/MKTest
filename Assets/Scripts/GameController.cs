using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    /*ALGORITHM!
     * 01. select colours for this game
     * 02. start timer
     * 03. begin game loop
     * 04. decrement round count
     * 05. select colour and text for this round
     * 06. await button input
     * 07. log result, display to player
     * 08. check round count; if not zero, return to step 4
     * 09. stop timer
     * 10. display results screen, return to menu
     */

    public ColourContainer colCon;
    public SettingsContainer setCon;
    private UIController uiCon;
    private List<Colour> colours = new List<Colour>();
    private System.DateTime timeStart;
    private System.TimeSpan timeDelta;
    private Colour selection;
    private int score;

    void Start()
    {
        uiCon = FindObjectOfType<UIController>();
        BeginGame(setCon.roundCount, setCon.colourCount);
    }

    public void BeginGame(int round_count, int colour_count)
    {
        Debug.Log("Starting");
        //01. select colours for this game
        colours.Clear();
        List<int> indices = new List<int>();
        int temp = 0;

        for (int i = 0; i < colour_count; i++)
        {
            do 
            {
                temp = Random.Range(0, colCon.colours.Length);
                if (!indices.Contains(temp))
                {
                    break;
                }
                Debug.Log("dupe " + temp);
            } 
            while (true);

            indices.Add(temp);
            colours.Add(colCon.colours[temp]);
            uiCon.AddButton(colCon.colours[temp]);
            Debug.Log(colCon.colours[temp].GetName() + " added, index " + temp);
        }
        //02. start timer
        timeStart = System.DateTime.Now;
        score = 0;
        //03. begin game loop
        StartCoroutine("GameLoop", round_count);
    }

    IEnumerator GameLoop(int round_count)
    {
        int index_colour;
        int index_word;
        bool round_result;
        int total_round_count = round_count;
        int previous_colour = -1;
        do
        {
            Debug.Log("round " + round_count);
            //04. decrement round count
            round_count--;
            selection = new Colour("none");
            //05.select colour and text for this round
            do
            {
                index_colour = Random.Range(0, colours.Count);
                if (index_colour != previous_colour)
                    break;
            }
            while (true);
            previous_colour = index_colour;

            do
            {
                index_word = Random.Range(0, colours.Count);
                if (index_colour != index_word)
                {
                    break;
                }
            }
            while (true);
            uiCon.UpdateQuestion(colours[index_colour].GetValue(), colours[index_word].GetName());
            //06.await button input
            while (selection.GetName().Equals("none"))
            {
                yield return new WaitForFixedUpdate();
            }
            //07.log result, display to player

            if (selection.GetName().Equals(colours[index_colour].GetName()))
            {
                Debug.Log("correct");
                round_result = true;
                score++;
            }
            else
            {
                Debug.Log("wrong");
                round_result = false;
            }

            uiCon.ShowRoundResults(round_result);
            yield return new WaitForSeconds(2);
            uiCon.HideRoundResults();
            //08. check round count; if not zero, return to step 4
        }
        while (round_count > 0);

        //09.stop timer
        timeDelta = System.DateTime.Now.Subtract(timeStart);
        double timeAverageDouble = timeDelta.TotalMilliseconds / total_round_count;
        System.TimeSpan timeAverage = System.TimeSpan.FromMilliseconds(timeAverageDouble);
        //10.display results screen, return to menu
        uiCon.ShowGameResults(score, total_round_count, timeDelta, timeAverage);
        yield return 0;
    }
    



    public void ColourOptionSelected(Colour colour)
    {
        selection = colour;
    }
}
