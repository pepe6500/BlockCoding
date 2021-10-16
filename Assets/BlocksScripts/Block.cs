using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
    [SerializeField]
    Block previous;
    [SerializeField]
    Block next;
    [SerializeField]
    public GameObject player;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    virtual public void Play()
    {
        return;
    }


    public void Detach(Transform _gamemanager)
    {
        transform.parent = _gamemanager;
        if (previous)
        {
            previous.SetNext(null);
            previous = null;
        }
    }

    public void SetNext(Block _block)
    {
        next = _block;
    }

    virtual public Block GetNext()
    {
        return next;
    }
    public Block GetNextBlock()
    {
        return next;
    }

    public void SetPrevious(Block _block)
    {
        previous = _block;
    }

    virtual public Block GetPrevious()
    {
        return previous;
    }

    public Block GetLast()
    {
        if (next)
        {
            return next.GetLast();
        }
        else
        {
            return this;
        }
    }

    public virtual void SetParent(Block _block)
    {
        if (previous)
        {
            previous.SetNext(null);
            _block.SetParent(previous);
            _block = _block.GetLast();
        }
        if (_block.GetNextBlock())
        {
            _block.GetNextBlock().SetPrevious(null);
            _block.GetNextBlock().SetParent(GetLast());
            _block.SetNext(null);
        }
        transform.parent = _block.transform;
        previous = _block;
        _block.SetNext(this);
        transform.localPosition = new Vector3(0, -(_block.transform.GetComponent<RectTransform>().rect.height + GetComponent<RectTransform>().rect.height) / 2, 0);
    }

    public void SetPlayer(GameObject _player)
    {
        player = _player;
    }
}
