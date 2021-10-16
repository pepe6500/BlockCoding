using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextUnit : Unit
{
    public TMPro.TMP_InputField inputField;
    public TMPro.TMP_Text text;
    // Start is called before the first frame update
    void Start()
    {

    }

    public override void PlayStart()
    {
        base.PlayStart();
        if (inputField.text != "")
            if (inputField.text[0] == '\\')
            {
                text.text = TextToNum.pos(inputField.text.Trim()).ToString();
                text.gameObject.SetActive(true);
                inputField.gameObject.SetActive(false);
                return;
            }
        text.text = inputField.text;
        text.gameObject.SetActive(true);
        inputField.gameObject.SetActive(false);
    }

    public override void Stop()
    {
        base.Stop();
        text.gameObject.SetActive(false);
        inputField.gameObject.SetActive(true);
    }
    // Update is called once per frame
    void Update()
    {
        if (text.gameObject.activeInHierarchy == true)
        {
            if (inputField.text != "")
                if (inputField.text[0] == '\\')
                {
                    text.text = TextToNum.pos(inputField.text.Trim()).ToString();
                    return;
                }
            text.text = inputField.text;
        }
    }
}
