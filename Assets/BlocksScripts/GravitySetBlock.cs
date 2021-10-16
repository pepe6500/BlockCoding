using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravitySetBlock : Block
{
    GameObject player;
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

    public void SetPlayer(GameObject _player)
    {
        player = _player;
    }

    public override void Play()
    {
        if (inputField.text.Trim() != "")
        {
            player.GetComponent<Rigidbody2D>().gravityScale = TextToNum.pos(inputField.text.Trim());
        }
    }
}
