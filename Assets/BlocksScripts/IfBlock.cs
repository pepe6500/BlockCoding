using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IfBlock : Block
{
    [SerializeField] TMPro.TMP_Dropdown target;
    [SerializeField] TMPro.TMP_Dropdown compare;
    [SerializeField] TMPro.TMP_InputField inputField;
    Block endBlock;
    bool value;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public override Block GetNext()
    {
        value = false;
        if (inputField.text != "")
        {

            switch (target.value)
            {
                case 0:
                    switch (compare.value)
                    {
                        case 0:
                            if (player.transform.localPosition.x < float.Parse(inputField.text))
                            {
                                value = true;
                            }
                            break;
                        case 1:
                            if (player.transform.localPosition.x > float.Parse(inputField.text))
                            {
                                value = true;
                            }
                            break;
                        case 2:
                            if (player.transform.localPosition.x <= float.Parse(inputField.text))
                            {
                                value = true;
                            }
                            break;
                        case 3:
                            if (player.transform.localPosition.x >= float.Parse(inputField.text))
                            {
                                value = true;
                            }
                            break;
                        case 4:
                            if (player.transform.localPosition.x == float.Parse(inputField.text))
                            {
                                value = true;
                            }
                            break;
                    }
                    break;
                case 1:
                    switch (compare.value)
                    {
                        case 0:
                            if (player.transform.localPosition.y < float.Parse(inputField.text))
                            {
                                value = true;
                            }
                            break;
                        case 1:
                            if (player.transform.localPosition.y > float.Parse(inputField.text))
                            {
                                value = true;
                            }
                            break;
                        case 2:
                            if (player.transform.localPosition.y <= float.Parse(inputField.text))
                            {
                                value = true;
                            }
                            break;
                        case 3:
                            if (player.transform.localPosition.y >= float.Parse(inputField.text))
                            {
                                value = true;
                            }
                            break;
                        case 4:
                            if (player.transform.localPosition.y == float.Parse(inputField.text))
                            {
                                value = true;
                            }
                            break;
                    }
                    break;
            }
        }
        if(value)
        {
            Debug.Log("tr");
            return GetNextBlock();
        }
        else
        {
            Debug.Log("false");
            return endBlock;
        }
    }

    public void SetIf(GameObject _player, Block _endBlock)
    {
        player = _player;
        endBlock = _endBlock;
    }

    public bool GetValue()
    {
        return value;
    }
}
