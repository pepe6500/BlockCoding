using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityBlock : Block
{
    [SerializeField]
    UnityEngine.UI.Toggle toggle;
    [SerializeField]
    TMPro.TMP_Text text;
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
        if (toggle.isOn)
            player.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeRotation;
        else
            player.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeAll;
    }

    public void SetBool()
    {
        if(toggle.isOn)
        {
            text.text = "켜기";
        }
        else
        {
            text.text = "끄기";
        }
    }
}
