using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DelayBlock : Block
{
    BlockCoding blockCoding;
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

    public override void Play()
    {
        if (inputField.text.Trim() != "")
        {
            blockCoding.delay = float.Parse(inputField.text.Trim());
        }
    }

    public void SetBlockCoding(BlockCoding _temp)
    {
        blockCoding = _temp;
    }
}
