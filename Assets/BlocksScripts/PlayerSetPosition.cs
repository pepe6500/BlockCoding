using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSetPosition : Block
{
    [SerializeField]
    TMPro.TMP_InputField inputField;
    [SerializeField]
    TMPro.TMP_InputField inputField2;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    

    public override void Play()
    {
        if (inputField.text.Trim() != "")
        {
            player.transform.localPosition = new Vector2(TextToNum.pos(inputField.text.Trim()), TextToNum.pos(inputField2.text.Trim()));
        }

    }
}
