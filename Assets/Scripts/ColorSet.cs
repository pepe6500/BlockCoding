using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorSet : MonoBehaviour
{
    bool isPaint;
    [SerializeField] ColorPickerTriangle picker;
    [SerializeField] UnityEngine.UI.Image image;
    [SerializeField] UnityEngine.UI.Slider alpha;
    // Start is called before the first frame update
    void Start()
    {
        image = GetComponent<UnityEngine.UI.Image>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isPaint)
        {
            Color temp = picker.TheColor;
            temp.a = alpha.value;
            image.color = temp;
        }
    }

    void OnMouseDown()
    {
        if (isPaint)
        {
            StopPaint();
        }
        else
        {
            StartPaint();
        }
    }
    private void StartPaint()
    {
        picker.transform.parent.gameObject.SetActive(true);
        image.color = picker.TheColor;
        isPaint = true;
    }

    private void StopPaint()
    {
        picker.transform.parent.gameObject.SetActive(false);
        isPaint = false;
    }
}
