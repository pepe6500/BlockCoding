using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SetTagBlock : Block
{
    public BlockCoding blockCoding;
    [SerializeField]
    TMPro.TMP_InputField inputField;

    public override void Play()
    {
        blockCoding.tag = inputField.text;
        return;
    }
}
