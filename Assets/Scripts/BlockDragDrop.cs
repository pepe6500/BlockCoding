using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockDragDrop : MonoBehaviour
{
    [SerializeField]
    Camera mainCam;
    [SerializeField]
    public BlockCoding blockCoding;
    [SerializeField]
    GameObject dragObj;
    [SerializeField]
    bool drag = false;
    [SerializeField]
    Vector2 startPo;
    [SerializeField]
    Vector3 blockOriPo;

    [SerializeField]
    Transform content;

    [SerializeField]
    UnityEngine.UI.ScrollRect scrollRect;

    [SerializeField]
    bool ver;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            RaycastHit2D raycastHit = Physics2D.Raycast(mainCam.ScreenToWorldPoint(Input.mousePosition), Vector3.forward);
            if (raycastHit)
            {
                if (raycastHit.collider.CompareTag("BlockList"))
                {
                    dragObj = raycastHit.transform.gameObject;
                    startPo = mainCam.ScreenToWorldPoint(Input.mousePosition);
                }
            }
        }
        if(Input.GetMouseButton(0))
        {
            if (!ver)
            {
                if (!drag)
                {
                    if (dragObj)
                    {
                        if (mainCam.ScreenToWorldPoint(Input.mousePosition).x - startPo.y > 0.5 && mainCam.ScreenToWorldPoint(Input.mousePosition).x - startPo.y < -0.5f)
                        {
                            drag = false;
                            ver = true;
                        }
                        else if (mainCam.ScreenToWorldPoint(Input.mousePosition).x - startPo.x > 2)
                        {
                            drag = true;
                            blockOriPo = dragObj.transform.localPosition;
                            dragObj.transform.parent = transform;
                            scrollRect.vertical = false;
                            Debug.Log("drag");
                        }
                    }
                }
                else
                {
                    Vector3 temp = mainCam.ScreenToWorldPoint(Input.mousePosition);
                    temp.z = 90;
                    dragObj.transform.position = temp;
                }
            }
        }
        if(Input.GetMouseButtonUp(0))
        {
            Vector3 temp = mainCam.ScreenToWorldPoint(Input.mousePosition);
            temp.z = 90;
            if (drag)
            {
                switch (dragObj.gameObject.name)
                {
                    case "FunctionCallBlock":
                        blockCoding.CreateFunctionCallBlock(temp);
                        break;
                    case "FunctionStartBlock":
                        blockCoding.CreateFunctionStartBlock(temp);
                        break;
                    case "InputBlockBlock":
                        blockCoding.CreateInputButtonBlock(temp);
                        break;
                    case "PlayerMove":
                        blockCoding.CreatePlayerMoveBlock(temp);
                        break;
                    case "PlayerRotationBlock":
                        blockCoding.CreatePlayerRotateBlock(temp);
                        break;
                    case "RepeatStartBlock":
                        blockCoding.CreatRepeatBlock(temp);
                        break;
                    case "ShowLogBlock":
                        blockCoding.CreateLogShowBlock(temp);
                        break;
                    case "StartBlock":
                        blockCoding.CreateStartBlock(temp);
                        break;
                    case "PlayerMoveUp":
                        blockCoding.CreatePlayerMoveUp(temp);
                        break;
                    case "IfBlock":
                        blockCoding.CreateIfBlcok(temp);
                        break;
                    case "ElseBlock":
                        blockCoding.CreateElseBlcok(temp);
                        break;
                    case "ColorSetBlock":
                        blockCoding.CreateColorSetBlock(temp);
                        break;
                    case "UpdateBlock":
                        blockCoding.CreateUpdateBlock(temp);
                        break;
                    case "IntervalBlock":
                        blockCoding.CreateIntervalBlock(temp);
                        break;
                    case "DelayBlock":
                        blockCoding.CreateDelayBlock(temp);
                        break;
                    case "GravityOn":
                        blockCoding.CreateGravityBlock(temp);
                        break;
                    case "GravitySet":
                        blockCoding.CreateGravitySetBlock(temp);
                        break;
                    case "CollisionEnterBlock":
                        blockCoding.CreateCollisionEnterBlock(temp);
                        break;
                    case "SetTagBlock":
                        blockCoding.CreateSetTagBlock(temp);
                        break;
                    case "AddForce":
                        blockCoding.CreateAddForceBlock(temp);
                        break;
                    case "PlayerSetPosition":
                        blockCoding.CreatePlayerSetPosition(temp);
                        break;
                    case "EditVarBlock":
                        blockCoding.CreateEditValBlock(temp);
                        break;
                    case "RestartBlock":
                        blockCoding.CreateRestartBlock(temp);
                        break;
                }
                dragObj.transform.parent = content;
                dragObj.transform.localPosition = blockOriPo;
                scrollRect.vertical = true;

            }
            dragObj = null;
                drag = false;
                ver = false;
        }
    }
}
