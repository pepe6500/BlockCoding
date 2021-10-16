using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputButtonBlock : TopBlock
{
    string code = "";
    // Start is called before the first frame update
    void Start()
    {
        code = transform.GetChild(2).GetComponent<TMPro.TMP_InputField>().text;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetCode(TMPro.TMP_InputField _code)
    {
        code = _code.text;
    }

    public string GetCode()
    {
        return code;
    }
}
