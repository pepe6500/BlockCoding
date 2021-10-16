using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FunctionCallBlock : Block
{
    [SerializeField]
    TMPro.TMP_InputField inputField;
    BlockCoding blockCoding;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void SetBlockCoding(BlockCoding _blockCoding)
    {
        blockCoding = _blockCoding;
    }

    public override void Play()
    {
        foreach(FunctionStartBlock function in blockCoding.GetFunctions())
        {
            if(inputField.text == function.GetCode())
            {
                blockCoding.PlayBlocks(function);
            }
        }
    }
}
