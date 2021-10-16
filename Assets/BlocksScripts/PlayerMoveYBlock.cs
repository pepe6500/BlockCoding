using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoveYBlock : Block
{
    [SerializeField]
    TMPro.TMP_InputField inputField;
    GameObject player;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void SetPlayer(GameObject _player)
    {
        player = _player;
    }

    public override void Play()
    {
        if (inputField.text.Trim() != "")
            player.transform.localPosition += new Vector3(0, float.Parse(inputField.text.Trim()));
    }
}
