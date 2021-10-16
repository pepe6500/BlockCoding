using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EditVarBlock : Block
{
    [SerializeField] TMPro.TMP_InputField target;
    [SerializeField] TMPro.TMP_Dropdown compare;
    [SerializeField] TMPro.TMP_InputField value;
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
        if (compare.value == 0)
        {
            TextToNum.SetVar(target.text.Trim(),TextToNum.pos(value.text.Trim()));
        }
        else if (compare.value == 1)
        {
            TextToNum.AddVar(target.text.Trim(), TextToNum.pos(value.text.Trim()));
        }
        else
        {
            TextToNum.MinusVar(target.text.Trim(), TextToNum.pos(value.text.Trim()));
        }
    }
}
