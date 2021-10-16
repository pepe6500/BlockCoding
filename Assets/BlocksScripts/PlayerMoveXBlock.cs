using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoveXBlock : Block
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
            player.transform.localPosition += new Vector3(float.Parse(inputField.text.Trim()), 0);
    }
}
