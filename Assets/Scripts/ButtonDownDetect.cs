using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonDownDetect : Block
{
    KeyCode keyCode;
    [SerializeField] TMPro.TMP_Text text;

    // Start is called before the first frame update
    void Start()
    {
        text.text = "";
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetKeyCode(KeyCode _keyCode)
    {
        keyCode = _keyCode;
    }

    public KeyCode GetKeyCode()
    {
        return keyCode;
    }
}
