using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepeatEndBlock : Block
{
    RepeatStartBlock startBlock;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetStart(RepeatStartBlock _repeatStart)
    {
        startBlock = _repeatStart;
    }

    public override Block GetNext()
    {
        if(startBlock.GetRepeat())
        {
            return startBlock;
        }
        else
        {
            startBlock.EndRepeat();
            return GetNextBlock();
        }
    }
}
