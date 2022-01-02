using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(HorizontalLayoutGroup))]
public class TextInstance : MonoBehaviour
{
    public string text;
    public Text3D text3D;
    // Start is called before the first frame update
    void Start()
    {
        text3D.DrawText(text, GetComponent<HorizontalLayoutGroup>());
    }
}
