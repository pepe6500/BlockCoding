using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitSelecter : MonoBehaviour
{
    [SerializeField]
    Camera mainCam;
    [SerializeField]
    BlockDragDrop dragDrop;
    [SerializeField]
    GameObject selected;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit2D raycastHit = Physics2D.Raycast(mainCam.ScreenToWorldPoint(Input.mousePosition), Vector3.forward);
        if (raycastHit)
        {
            if (raycastHit.collider.CompareTag("Unit"))
            {
                selected.SetActive(false);
                raycastHit.collider.GetComponent<Unit>().blockCoding.gameObject.SetActive(true);
                dragDrop.blockCoding = raycastHit.collider.GetComponent<Unit>().blockCoding;
            }
        }
    }
}
