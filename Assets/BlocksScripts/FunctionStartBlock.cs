﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FunctionStartBlock : TopBlock
{
    [SerializeField]
    TMPro.TMP_InputField inputField;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public string GetCode()
    {
        return inputField.text;
    }
}
