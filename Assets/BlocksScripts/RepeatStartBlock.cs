using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepeatStartBlock : Block
{
    [SerializeField]
    TMPro.TMP_InputField inputField;
    int repeatCount;
    bool start = false;
    bool repeat = false;
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
        if(!start)
        {
            if(inputField.text.Trim() != "")
            {
                repeatCount = int.Parse(inputField.text.Trim());
                start = true;
            }
        }
        if (--repeatCount > 0)
        {
            repeat = true;
        }
        else
        {
            repeat = false;
        }
    }

    public bool GetRepeat()
    {
        return repeat;
    }

    public void EndRepeat()
    {
        repeatCount = 0;
        start = false;
        repeat = false;
    }
}
