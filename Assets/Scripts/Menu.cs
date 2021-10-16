using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Menu : MonoBehaviour
{
    [SerializeField]
    GameObject[] pans;
    [SerializeField]
    UnityEngine.UI.Image[] images;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Select(int _num)
    {
        for(int i = 0; i < pans.Length; i++)
        {
            if(i == _num)
            {
                pans[i].SetActive(true);
                images[i].color = new Color(163f/255, 204f / 255, 162f / 255);
            }
            else
            {
                pans[i].SetActive(false);
                images[i].color = new Color(72f / 255, 118f / 255, 76f / 255);
            }
        }
    }
}
