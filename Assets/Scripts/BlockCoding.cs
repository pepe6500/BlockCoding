using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BlockCoding : MonoBehaviour
{
    [SerializeField]
    public Camera mainCam;
    [SerializeField]
    Block holdingBlock;
    [SerializeField]
    Vector2 oriMousePosition;
    [SerializeField]
    Vector2 oriBlockPosition;
    [SerializeField]
    bool holding;
    [SerializeField]
    Transform canvas;

    [SerializeField]
    List<Block> blocks = new List<Block>();

    [SerializeField]
    GameObject logShowBlock;
    [SerializeField]
    GameObject startBlock;
    [SerializeField]
    GameObject playerMoveBlock;
    [SerializeField]
    GameObject repeatStartBlock;
    [SerializeField]
    GameObject repeatEndBlock;
    [SerializeField]
    GameObject playerRotateBlock;
    [SerializeField]
    GameObject functionStartBlock;
    [SerializeField]
    GameObject functionCallBlock;
    [SerializeField]
    GameObject inputButtonBlock;
    [SerializeField]
    GameObject playerMoveUp;
    [SerializeField]
    GameObject ifBlock;
    [SerializeField]
    GameObject ifEndBlock;
    [SerializeField]
    GameObject elseBlock;
    [SerializeField]
    GameObject elseEndBlock;
    [SerializeField]
    GameObject colorSetBlock;
    [SerializeField]
    GameObject updateBlock;
    [SerializeField]
    GameObject intervalBlock;
    [SerializeField]
    GameObject delayBlock;
    [SerializeField]
    GameObject GravityBlock;
    [SerializeField]
    GameObject GravitySetBlock;
    [SerializeField]
    GameObject CollisionEnterBlock;
    [SerializeField]
    GameObject SetTagBlock;
    [SerializeField]
    GameObject AddForceBlock;
    [SerializeField]
    GameObject playerSetPosition;
    [SerializeField]
    GameObject EditValBlock;
    [SerializeField]
    GameObject RestartBlock;

    [SerializeField]
    Block attachBlock;

    [SerializeField]
    GameObject preViewLine;

    [SerializeField]
    List<Block> startBlocks = new List<Block>();
    [SerializeField]
    List<Block> updateBlocks = new List<Block>();
    [SerializeField]
    List<FunctionStartBlock> functionStartBlocks = new List<FunctionStartBlock>();
    [SerializeField]
    List<InputButtonBlock> inputButtonBlocks = new List<InputButtonBlock>();
    [SerializeField]
    List<CollisionEnterBlock> collisionEnterBlocks = new List<CollisionEnterBlock>();

    [SerializeField]
    public GameObject player;

    [SerializeField]
    public UnityEngine.UI.Text log;

    [SerializeField]
    Vector3 moveOri;
    [SerializeField]
    bool trashOn;
    [SerializeField]
    GameObject trashcan;

    [SerializeField]
    bool play;

    [SerializeField]
    public float delay;
    [SerializeField]
    new public string tag;
    [SerializeField]
    public bool en;
    // Start is called before the first frame update
    private void Awake()
    {
        Screen.SetResolution(1920, 1080, true);
        canvas = transform.parent;
    }

    void Start()
    {
        //CreateStartBlock(new Vector3(-500, 300));
        //CreateLogShowBlock(new Vector3(-500, 0));
        //CreateLogShowBlock(new Vector3(500, 0));
        //CreateLogShowBlock(new Vector3(0, 0));
        //CreatePlayerMoveXBlock(new Vector3(0, 300));
        //CreatePlayerMoveYBlock(new Vector3(0, -300));
        //CreatRepeatBlock(new Vector3(0, -450));
        //CreatePlayerRotateBlock(new Vector3(0, -450));
        //CreateFunctionStartBlock(new Vector3(-700, 100));
        //CreateFunctionStartBlock(new Vector3(-700, 300));
        //CreateFunctionCallBlock(new Vector3(-700, -100));
        //CreateFunctionCallBlock(new Vector3(-700, -300));
        //CreateInputButtonBlock(new Vector3(-900, -0));
    }

    // Update is called once per frame
    void Update()
    {
        if (en)
        {
            //블럭 드래그 및 배치, 연결
            if (Input.GetMouseButtonDown(0))
            {
                RaycastHit2D raycastHit = Physics2D.Raycast(mainCam.ScreenToWorldPoint(Input.mousePosition), Vector3.forward);
                if (raycastHit)
                {
                    if (raycastHit.collider.CompareTag("Block"))
                    {
                        raycastHit.collider.enabled = false;
                        holdingBlock = raycastHit.collider.GetComponent<Block>();
                        oriMousePosition = mainCam.ScreenToWorldPoint(Input.mousePosition);
                        //holdingBlock.GetLast().Play();
                    }
                }
            }
            if (Input.GetMouseButton(0))
            {
                if (holdingBlock)
                {
                    RaycastHit2D raycastHit = Physics2D.Raycast(mainCam.ScreenToWorldPoint(Input.mousePosition), Vector3.forward);
                    if (raycastHit)
                    {
                        if (raycastHit.collider.name == "Trash Can")
                        {
                            if (!trashOn)
                            {
                                if (!trashcan)
                                    trashcan = raycastHit.collider.gameObject;
                                trashOn = true;
                                raycastHit.collider.GetComponent<Animation>().Play("TrashOpen");
                            }
                        }
                        else
                        {
                            if (trashOn)
                            {
                                trashOn = false;
                                trashcan.GetComponent<Animation>().Play("TrashExit");
                            }
                        }
                    }
                    else
                    {
                        if (trashOn)
                        {
                            trashOn = false;
                            trashcan.GetComponent<Animation>().Play("TrashExit");
                        }
                    }
                    if (Vector2.Distance(oriMousePosition, (Input.mousePosition)) > 10 && !holding)
                    {
                        holding = true;
                        holdingBlock.Detach(transform);
                        oriBlockPosition = holdingBlock.transform.position;
                        holdingBlock.transform.SetAsLastSibling();
                        preViewLine.transform.SetAsLastSibling();
                    }
                    if (holding)
                    {
                        attachBlock = null;
                        holdingBlock.transform.localScale = Vector3.one;
                        preViewLine.SetActive(false);
                        for (int i = 0; i < blocks.Count; i++)
                        {
                            blocks[i].transform.localScale = Vector3.one;
                            if (blocks[i] != holdingBlock && blocks[i] != holdingBlock.GetNextBlock())
                            {
                                if (Vector2.Distance(holdingBlock.transform.position, blocks[i].transform.position) < 150 * transform.lossyScale.x)
                                {
                                    attachBlock = blocks[i];
                                    if (holdingBlock.transform.position.y - blocks[i].transform.position.y > 0)
                                    {
                                        preViewLine.SetActive(true);
                                        preViewLine.transform.position = attachBlock.transform.position + Vector3.up * (blocks[i].GetComponent<RectTransform>().rect.height / 2 * transform.lossyScale.y);
                                    }
                                    else
                                    {
                                        preViewLine.SetActive(true);
                                        preViewLine.transform.position = attachBlock.transform.position + Vector3.down * (blocks[i].GetComponent<RectTransform>().rect.height / 2 * transform.lossyScale.y);
                                    }
                                    break;
                                }
                            }
                        }
                        //Debug.Log((Vector2)mainCam.ScreenToWorldPoint(Input.mousePosition));
                        holdingBlock.transform.position = oriBlockPosition + ((Vector2)mainCam.ScreenToWorldPoint(Input.mousePosition) - oriMousePosition);
                    }
                }
            }
            if (Input.GetMouseButtonUp(0))
            {
                if (holding)
                {
                    RaycastHit2D raycastHit = Physics2D.Raycast(mainCam.ScreenToWorldPoint(Input.mousePosition), Vector3.forward);
                    if (raycastHit)
                    {
                        if (raycastHit.collider.name == "Trash Can")
                        {
                            Block temp = holdingBlock;
                            while (true)
                            {
                                blocks.Remove(temp);
                                if (temp.GetNextBlock())
                                {
                                    temp = temp.GetNextBlock();
                                }
                                else
                                {
                                    break;
                                }
                            }
                            Destroy(holdingBlock.gameObject);
                            raycastHit.collider.GetComponent<Animation>().Play("TrashClose");
                        }
                    }
                    holdingBlock.GetComponent<Collider2D>().enabled = true;
                    if (attachBlock)
                    {
                        if (holdingBlock.transform.position.y - attachBlock.transform.position.y > 0)
                        {
                            attachBlock.SetParent(holdingBlock);
                            attachBlock.transform.localScale = Vector3.one;
                        }
                        else
                        {
                            holdingBlock.SetParent(attachBlock);
                            holdingBlock.transform.localScale = Vector3.one;
                        }
                    }

                    holding = false;
                    preViewLine.SetActive(false);
                }
                holdingBlock = null;
                trashOn = false;
            }
            if (Input.GetMouseButtonDown(1))
            {
                moveOri = mainCam.ScreenToWorldPoint(Input.mousePosition);
            }
            if (Input.GetMouseButton(1))
            {
                Vector3 temp = mainCam.ScreenToWorldPoint(Input.mousePosition) - moveOri;
                gameObject.transform.position += temp;
                moveOri = mainCam.ScreenToWorldPoint(Input.mousePosition);
            }
            if (Input.mouseScrollDelta != Vector2.zero)
            {
                if ((transform.localScale + new Vector3(Input.mouseScrollDelta.y, Input.mouseScrollDelta.y, 0) * 0.1f).x > 0.1f)
                    transform.localScale += new Vector3(Input.mouseScrollDelta.y, Input.mouseScrollDelta.y, 0) * 0.1f;
            }
        }
        if (play)
        {
            foreach (InputButtonBlock inputButton in inputButtonBlocks)
            {
                if (inputButton.GetCode() != "")
                {
                    KeyCode kc = (KeyCode)System.Enum.Parse(typeof(KeyCode), inputButton.GetCode());
                    if (Input.GetKey(kc))
                    {
                        PlayBlocks(inputButton);
                    }
                }
            }
            if (updateBlocks.Count > 0)
            {
                foreach (Block updateBlock in updateBlocks)
                {
                    if(updateBlock)
                    PlayBlocks(updateBlock);
                }
            }
        }
    }

    public void CreateLogShowBlock(Vector3 _position)
    {
        GameObject temp = Instantiate(logShowBlock, _position, Quaternion.identity, transform);
        temp.transform.parent = transform;
        temp.transform.position = _position;
        blocks.Add(temp.GetComponent<Block>());
        temp.GetComponent<ShowLogBlock>().SetText(log);
    }

    public void CreateStartBlock(Vector3 _position)
    {
        GameObject temp = Instantiate(startBlock, _position, Quaternion.identity, transform);
        temp.transform.parent = transform;
        temp.transform.position = _position;
        blocks.Add(temp.GetComponent<Block>());
        startBlocks.Add(temp.GetComponent<Block>());
    }

    public void CreatePlayerMoveBlock(Vector3 _position)
    {
        GameObject temp = Instantiate(playerMoveBlock, _position, Quaternion.identity, transform);
        temp.transform.parent = transform;
        temp.transform.position = _position;
        blocks.Add(temp.GetComponent<Block>());
        temp.GetComponent<PlayerMove>().SetPlayer(player);
    }

    //public void CreatePlayerMoveXBlock(Vector3 _position)
    //{
    //    GameObject temp = Instantiate(playerMoveXBlock, _position, Quaternion.identity, transform);
    //    temp.transform.parent = transform;
    //    temp.transform.position = _position;
    //    blocks.Add(temp.GetComponent<Block>());
    //    temp.GetComponent<PlayerMoveXBlock>().SetPlayer(player);
    //}

    //public void CreatePlayerMoveYBlock(Vector3 _position)
    //{
    //    GameObject temp = Instantiate(playerMoveYBlock, _position, Quaternion.identity, transform);
    //    temp.transform.parent = transform;
    //    temp.transform.position = _position;
    //    blocks.Add(temp.GetComponent<Block>());
    //    temp.GetComponent<PlayerMoveYBlock>().SetPlayer(player);
    //}

    public void CreatRepeatBlock(Vector3 _position)
    {
        GameObject temp = Instantiate(repeatStartBlock, _position, Quaternion.identity, transform);
        temp.transform.parent = transform;
        temp.transform.position = _position;
        blocks.Add(temp.GetComponent<Block>());

        GameObject temp2 = Instantiate(repeatEndBlock, _position, Quaternion.identity, transform);
        temp2.transform.parent = transform;
        temp2.transform.position = _position;
        blocks.Add(temp2.GetComponent<Block>());
        temp2.GetComponent<Block>().SetParent(temp.GetComponent<Block>());
        temp2.GetComponent<RepeatEndBlock>().SetStart(temp.GetComponent<RepeatStartBlock>());
    }

    public void CreatePlayerRotateBlock(Vector3 _position)
    {
        GameObject temp = Instantiate(playerRotateBlock, _position, Quaternion.identity, transform);
        temp.transform.parent = transform;
        temp.transform.position = _position;
        blocks.Add(temp.GetComponent<Block>());
        temp.GetComponent<PlayerRotationBlock>().SetPlayer(player);
    }

    public void CreateFunctionStartBlock(Vector3 _position)
    {
        GameObject temp = Instantiate(functionStartBlock, _position, Quaternion.identity, transform);
        temp.transform.parent = transform;
        temp.transform.position = _position;
        blocks.Add(temp.GetComponent<Block>());
        functionStartBlocks.Add(temp.GetComponent<FunctionStartBlock>());
    }

    public void CreateFunctionCallBlock(Vector3 _position)
    {
        GameObject temp = Instantiate(functionCallBlock, _position, Quaternion.identity, transform);
        temp.transform.parent = transform;
        temp.transform.position = _position;
        blocks.Add(temp.GetComponent<Block>());
        temp.GetComponent<FunctionCallBlock>().SetBlockCoding(this);
    }

    public void CreateInputButtonBlock(Vector3 _position)
    {
        GameObject temp = Instantiate(inputButtonBlock, _position, Quaternion.identity, transform);
        temp.transform.parent = transform;
        temp.transform.position = _position;
        blocks.Add(temp.GetComponent<Block>());
        inputButtonBlocks.Add(temp.GetComponent<InputButtonBlock>());
    }

    public void CreatePlayerMoveUp(Vector3 _position)
    {
        GameObject temp = Instantiate(playerMoveUp, _position, Quaternion.identity, transform);
        temp.transform.parent = transform;
        temp.transform.position = _position;
        blocks.Add(temp.GetComponent<Block>());
        temp.GetComponent<PlayerMoveUp>().SetPlayer(player);
    }

    public void CreateIfBlcok(Vector3 _position)
    {
        GameObject temp = Instantiate(ifBlock, _position, Quaternion.identity, transform);
        temp.transform.parent = transform;
        temp.transform.position = _position;
        blocks.Add(temp.GetComponent<Block>());
        GameObject temp2 = Instantiate(ifEndBlock, _position, Quaternion.identity, transform);
        temp2.transform.parent = transform;
        temp2.transform.position = _position;
        blocks.Add(temp2.GetComponent<Block>());
        temp2.GetComponent<Block>().SetParent(temp.GetComponent<Block>());
        temp.GetComponent<IfBlock>().SetIf(player, temp2.GetComponent<Block>());
        temp2.GetComponent<IfEndBlock>().SetStart(temp.GetComponent<IfBlock>());
    }

    public void CreateElseBlcok(Vector3 _position)
    {
        GameObject temp = Instantiate(elseBlock, _position, Quaternion.identity, transform);
        temp.transform.parent = transform;
        temp.transform.position = _position;
        blocks.Add(temp.GetComponent<Block>());
        GameObject temp2 = Instantiate(elseEndBlock, _position, Quaternion.identity, transform);
        temp2.transform.parent = transform;
        temp2.transform.position = _position;
        blocks.Add(temp2.GetComponent<Block>());
        temp.GetComponent<ElseBlock>().SetElseEndBlock(temp2.GetComponent<Block>());
        temp2.GetComponent<Block>().SetParent(temp.GetComponent<Block>());
    }

    public void CreateColorSetBlock(Vector3 _position)
    {
        GameObject temp = Instantiate(colorSetBlock, _position, Quaternion.identity, transform);
        temp.transform.parent = transform;
        temp.transform.position = _position;
        blocks.Add(temp.GetComponent<Block>());
        temp.GetComponent<ColorSetBlock>().SetPlayer(player);
    }

    public void CreateUpdateBlock(Vector3 _position)
    {
        GameObject temp = Instantiate(updateBlock, _position, Quaternion.identity, transform);
        temp.transform.parent = transform;
        temp.transform.position = _position;
        blocks.Add(temp.GetComponent<Block>());
        updateBlocks.Add(temp.GetComponent<Block>());
    }

    public void CreateDelayBlock(Vector3 _position)
    {
        GameObject temp = Instantiate(delayBlock, _position, Quaternion.identity, transform);
        temp.transform.parent = transform;
        temp.transform.position = _position;
        blocks.Add(temp.GetComponent<Block>());
        temp.GetComponent<DelayBlock>().SetBlockCoding(this);
    }

    public void CreateIntervalBlock(Vector3 _position)
    {
        GameObject temp = Instantiate(intervalBlock, _position, Quaternion.identity, transform);
        temp.transform.parent = transform;
        temp.transform.position = _position;
        blocks.Add(temp.GetComponent<Block>());
        startBlocks.Add(temp.GetComponent<Block>());
        temp.GetComponent<IntervalBlock>().SetBlockCoding(this);
    }

    public void CreateGravityBlock(Vector3 _position)
    {
        GameObject temp = Instantiate(GravityBlock, _position, Quaternion.identity, transform);
        temp.transform.parent = transform;
        temp.transform.position = _position;
        blocks.Add(temp.GetComponent<Block>());
        temp.GetComponent<GravityBlock>().SetPlayer(player);
    }

    public void CreateGravitySetBlock(Vector3 _position)
    {
        GameObject temp = Instantiate(GravitySetBlock, _position, Quaternion.identity, transform);
        temp.transform.parent = transform;
        temp.transform.position = _position;
        blocks.Add(temp.GetComponent<Block>());
        temp.GetComponent<GravitySetBlock>().SetPlayer(player);
    }

    public void CreateCollisionEnterBlock(Vector3 _position)
    {
        GameObject temp = Instantiate(CollisionEnterBlock, _position, Quaternion.identity, transform);
        temp.transform.parent = transform;
        temp.transform.position = _position;
        blocks.Add(temp.GetComponent<Block>());
        collisionEnterBlocks.Add(temp.GetComponent<CollisionEnterBlock>());
    }
    public void CreateSetTagBlock(Vector3 _position)
    {
        GameObject temp = Instantiate(SetTagBlock, _position, Quaternion.identity, transform);
        temp.transform.parent = transform;
        temp.transform.position = _position;
        blocks.Add(temp.GetComponent<Block>());
        temp.GetComponent<SetTagBlock>().blockCoding = this;
    }

    public void CreateAddForceBlock(Vector3 _position)
    {
        GameObject temp = Instantiate(AddForceBlock, _position, Quaternion.identity, transform);
        temp.transform.parent = transform;
        temp.transform.position = _position;
        blocks.Add(temp.GetComponent<Block>());
        temp.GetComponent<AddForce>().SetPlayer(player);
    }

    public void CreatePlayerSetPosition(Vector3 _position)
    {
        GameObject temp = Instantiate(playerSetPosition, _position, Quaternion.identity, transform);
        temp.transform.parent = transform;
        temp.transform.position = _position;
        blocks.Add(temp.GetComponent<Block>());
        temp.GetComponent<PlayerSetPosition>().SetPlayer(player);
    }

    public void CreateEditValBlock(Vector3 _position)
    {
        GameObject temp = Instantiate(EditValBlock, _position, Quaternion.identity, transform);
        temp.transform.parent = transform;
        temp.transform.position = _position;
        blocks.Add(temp.GetComponent<Block>());
    }
    public void CreateRestartBlock(Vector3 _position)
    {
        GameObject temp = Instantiate(RestartBlock, _position, Quaternion.identity, transform);
        temp.transform.parent = transform;
        temp.transform.position = _position;
        blocks.Add(temp.GetComponent<Block>());
    }

    public void PlayBlocks(Block _start)
    {
        StartCoroutine(Play(_start));
    }

    public void StartBlockPlay()
    {
        foreach (Block startBlock in startBlocks)
        { 
            PlayBlocks(startBlock);
        }
    }

    IEnumerator Play(Block _start)
    {

        Block nowBlock = _start;
        while (true)
        {
            nowBlock.Play();
            if (delay != 0)
            {

                float temp = delay;
                delay = 0;
                yield return new WaitForSeconds(temp);
            }
            if (!nowBlock.GetNext())
            {
                break;
            }
            nowBlock = nowBlock.GetNext();
        }
    }

    public List<FunctionStartBlock> GetFunctions()
    {
        return functionStartBlocks;
    }

    public void Play()
    {
        play = true;
        Debug.Log(player);
        Debug.Log(gameObject);
        player.GetComponent<Unit>().PlayStart();
        StartBlockPlay();
    }

    public void Stop()
    {
        play = false;
        player.GetComponent<Unit>().Stop();
        StopAllCoroutines();
        log.text = "";
        foreach (Block startBlock in startBlocks)
        {
            if (startBlock.GetComponent<IntervalBlock>())
                startBlock.GetComponent<IntervalBlock>().End();
        }
    }

    public void CollisionEnter(string code)
    {
        if (collisionEnterBlocks.Count > 0)
        {
            foreach (CollisionEnterBlock collisionEnterBlock in collisionEnterBlocks)
            {
                if (code == collisionEnterBlock.GetCode())
                {
                    PlayBlocks(collisionEnterBlock);
                }
            }
        }
        return;
    }
}
