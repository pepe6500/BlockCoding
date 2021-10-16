using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShowLogBlock : Block
{
    public TMPro.TMP_InputField inputField;
    Text text;

    public override void Play()
    {
        text.text += "["+System.DateTime.Now.Hour+":"+System.DateTime.Now.Minute+":"+System.DateTime.Now.Second+"] " + inputField.text + "\n";
        //Debug.Log(inputField.text);
        return;
    }

    public void SetText(Text _text)
    {
        text = _text;
    }
}
