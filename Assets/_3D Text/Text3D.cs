using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// Utility used for dynamic 3D text

[CreateAssetMenu(fileName = "Text3D", menuName = "ScriptableObjects/Text3D", order = 1)]
public class Text3D : ScriptableObject
{
    public Material mat;
    public List<Letter> Letters;

    public void DrawText(string input, HorizontalLayoutGroup parent)
    {
        foreach(RectTransform child in parent.GetComponentInChildren<RectTransform>())
        {
            Destroy(child.gameObject);
        }

        input = input.ToUpper();
        foreach(char in_letter in input)
        {
/*            if (in_letter.Equals(' '))
            {
                Instantiate(new GameObject(), parent.transform);
            }
            else
            {*/
                foreach (Letter out_letter in Letters)
                {
                    if (in_letter.Equals(out_letter.character))
                    {
                        Instantiate(out_letter.model, parent.transform);
                        break;
                    }
                }
            }
        }
    }
//}

[System.Serializable]
public struct Letter
{
    public char character;
    public GameObject model;
}
