using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RestartBlock : Block
{
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
        GameObject.Find("Canvas").GetComponent<UnitManager>().Stop();
        GameObject.Find("Canvas").GetComponent<UnitManager>().Play();
    }
}
