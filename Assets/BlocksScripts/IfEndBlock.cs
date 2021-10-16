using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IfEndBlock : Block
{
    IfBlock ifBlock;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetStart(IfBlock _ifBlock)
    {
        ifBlock = _ifBlock;
    }

    public bool GetStart()
    {
        return ifBlock;
    }

    public override Block GetNext()
    {
        if(GetNextBlock())
        if(GetNextBlock().GetComponent<ElseBlock>())
        {
            if(ifBlock.GetValue())
            {
                return GetNextBlock().GetComponent<ElseBlock>().GetElseEndBlock();
            }
        }
        return GetNextBlock();
    }
}
