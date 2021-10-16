using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unit : MonoBehaviour
{
    Vector3 oriPo;
    Vector3 oriSc;
    public BlockCoding blockCoding;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    virtual public void PlayStart()
    {
        Debug.Log(gameObject.name);
        oriPo = transform.localPosition;
        oriSc = transform.localScale;
    }
    virtual public void Stop()
    {
        transform.rotation = Quaternion.identity;
        transform.localPosition = oriPo;
        transform.localScale = oriSc;
        if(GetComponent<UnityEngine.UI.Image>())
        GetComponent<UnityEngine.UI.Image>().color = Color.white;
        if (GetComponent<Rigidbody2D>())
        {
            GetComponent<Rigidbody2D>().velocity = Vector2.zero;
            GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeAll;
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("충돌 " + collision.gameObject.name);
        if(collision.transform.GetComponent<Unit>())
         blockCoding.CollisionEnter(collision.transform.GetComponent<Unit>().blockCoding.tag);
        else
            blockCoding.CollisionEnter("");
    }
}
