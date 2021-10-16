using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorSetBlock : Block
{
    GameObject player;
    [SerializeField]
    UnityEngine.UI.Image color;
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
        player.GetComponent<UnityEngine.UI.Image>().color = color.color;
    }
}
