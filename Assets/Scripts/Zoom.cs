using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zoom : MonoBehaviour
{
    new public Animation animation;
    public GameObject inButton;
    public GameObject outButton;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ZoomIn()
    {
        animation.Play("ZoomIn");
        inButton.SetActive(false);
        outButton.SetActive(true);
    }

    public void ZoomOut()
    {
        animation.Play("ZoomOut");
        inButton.SetActive(true);
        outButton.SetActive(false);
    }
}
