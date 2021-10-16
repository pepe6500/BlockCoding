using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IntervalBlock : TopBlock
{
    [SerializeField] TMPro.TMP_InputField inputField;
    BlockCoding blockCoding;

    public override void Play()
    {
        StartCoroutine(loop());
    }

    public override Block GetNext()
    {
        return null;
    }

    public void End()
    {
        StopAllCoroutines();
    }

    public void SetBlockCoding(BlockCoding _temp)
    {
        blockCoding = _temp;
    }

    IEnumerator loop()
    {
        while (true)
        {
            if (inputField.text != "")
            {
                yield return new WaitForSeconds(float.Parse(inputField.text));
                if (GetNextBlock())
                    blockCoding.PlayBlocks(GetNextBlock());
            }
            else
            {
                break;
            }
        }
    }
}
