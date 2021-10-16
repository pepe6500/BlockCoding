using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElseBlock : Block
{
    Block elseEndBlock;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetElseEndBlock(Block _endElseBlock)
    {
        elseEndBlock = _endElseBlock;
    }

    public Block GetElseEndBlock()
    {
        return elseEndBlock;
    }
}
