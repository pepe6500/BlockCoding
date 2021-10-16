using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRotationBlock : Block
{
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
            player.transform.localRotation = Quaternion.Euler(player.transform.localRotation.eulerAngles.x, player.transform.localRotation.eulerAngles.y, player.transform.localRotation.eulerAngles.z - TextToNum.pos(inputField.text.Trim()));
    }
}
