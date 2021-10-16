using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitManager : MonoBehaviour
{
    [SerializeField]
    bool drag = false;
    [SerializeField]
    Camera mainCam;

    [SerializeField]
    GameObject holdingUnit;

    [SerializeField]
    Vector3 oriMousePosition;
    [SerializeField]
    Vector3 oriUnitpos;
    [SerializeField]
    Transform oripr;
    [SerializeField]
    public GameObject nowUnit;

    [SerializeField]
    public GameObject blueUnit;
    [SerializeField]
    public GameObject redUnit;
    [SerializeField]
    public GameObject textUnit;
    [SerializeField]
    public GameObject blockCoding;
    [SerializeField]
    public GameObject blockCodingPre;
    [SerializeField]
    public BlockDragDrop dragDrop;
    [SerializeField]
    public Transform can;
    [SerializeField]
    public Transform unitlist;
    [SerializeField]
    List<BlockCoding> blockCodings = new List<BlockCoding>();
    [SerializeField]
    public GameObject bg;
    // Start is called before the first frame update
    void Start()
    {
        if(blockCodings.Count == 0)
        blockCodings.Add(blockCoding.GetComponent<BlockCoding>());
        foreach (BlockCoding temp in blockCodings)
        {
            Debug.Log(temp.player);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            RaycastHit2D raycastHit = Physics2D.Raycast(mainCam.ScreenToWorldPoint(Input.mousePosition), Vector3.forward);
            if (raycastHit)
            {
                Debug.Log(raycastHit.collider.gameObject.name);
                if (raycastHit.collider.CompareTag("UnitList"))
                {
                    holdingUnit = raycastHit.collider.gameObject;
                    oripr = holdingUnit.transform.parent;
                    oriMousePosition = mainCam.ScreenToWorldPoint(Input.mousePosition);
                    oriUnitpos = holdingUnit.transform.position;
                    holdingUnit.transform.parent = transform;
                    raycastHit.collider.enabled = false;
                }
                else if (raycastHit.collider.CompareTag("Unit"))
                {
                    SelectUnit(raycastHit.collider.gameObject);
                }
            }
        }
        if (Input.GetMouseButton(0))
        {
            if(holdingUnit)
            {
                holdingUnit.transform.position = mainCam.ScreenToWorldPoint(Input.mousePosition);
                holdingUnit.transform.localPosition = new Vector3(holdingUnit.transform.localPosition.x, holdingUnit.transform.localPosition.y, -1);
            }
        }
        if(Input.GetMouseButtonUp(0))
        {
            if (holdingUnit)
            {
                RaycastHit2D raycastHit = Physics2D.Raycast(mainCam.ScreenToWorldPoint(Input.mousePosition), Vector3.forward);
                if (raycastHit)
                {
                    Debug.Log(raycastHit.collider.gameObject.name);
                    if (raycastHit.collider.CompareTag("PlayPan"))
                    {
                        GameObject temp;
                        if (holdingUnit.name == "red")
                        {
                            temp = Instantiate(redUnit);
                        }
                        else if(holdingUnit.name == "blue")
                        {
                            temp = Instantiate(blueUnit);
                        }
                        else if(holdingUnit.name == "TextUnit")
                        {
                            temp = Instantiate(textUnit);
                        }
                        else
                        {
                            temp = Instantiate(redUnit);
                        }
                        Vector3 orisc = temp.transform.localScale;
                        temp.transform.parent = raycastHit.collider.transform;
                        temp.transform.localScale = orisc;
                        temp.transform.position = mainCam.ScreenToWorldPoint(Input.mousePosition);
                        temp.transform.localPosition = new Vector3(temp.transform.localPosition.x, temp.transform.localPosition.y, -1);
                        temp.GetComponent<Unit>().blockCoding = Instantiate(blockCodingPre, can).GetComponent<BlockCoding>();
                        temp.GetComponent<Unit>().blockCoding.transform.SetAsFirstSibling();
                        temp.GetComponent<Unit>().blockCoding.log = blockCoding.GetComponent<BlockCoding>().log;
                        bg.transform.SetAsFirstSibling();
                        temp.GetComponent<Unit>().blockCoding.player = temp;
                        temp.GetComponent<Unit>().blockCoding.mainCam = mainCam;
                        blockCodings.Add(temp.GetComponent<Unit>().blockCoding);
                        SelectUnit(temp);
                    }
                }
                holdingUnit.GetComponent<Collider2D>().enabled = true;
                holdingUnit.transform.position = oriUnitpos;
                holdingUnit.transform.parent = oripr;
                holdingUnit = null;
            }
        }
    }

    public void SelectUnit(GameObject temp)
    {
        if (temp.GetComponent<Unit>().blockCoding != nowUnit.GetComponent<Unit>().blockCoding)
        {
            nowUnit.GetComponent<Unit>().blockCoding.transform.position = new Vector3(nowUnit.GetComponent<Unit>().blockCoding.transform.position.x, 9999, nowUnit.GetComponent<Unit>().blockCoding.transform.position.z);
            nowUnit.GetComponent<Unit>().blockCoding.en = false;
            temp.GetComponent<Unit>().blockCoding.transform.position = new Vector3(temp.GetComponent<Unit>().blockCoding.transform.position.x, 0, temp.GetComponent<Unit>().blockCoding.transform.position.z);
            temp.GetComponent<Unit>().blockCoding.en = true;
            dragDrop.blockCoding = temp.GetComponent<Unit>().blockCoding;
            nowUnit = temp;
        }
    }

    public void Play()
    {
        foreach(BlockCoding temp in blockCodings)
        {
            Debug.Log("name : " + temp.player);
            temp.Play();
        }
    }

    public void Stop()
    {
        TextToNum.variables.Clear();
        foreach (BlockCoding temp in blockCodings)
        {
            temp.Stop();
        }
    }
}
