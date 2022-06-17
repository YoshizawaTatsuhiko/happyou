using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossController : MonoBehaviour
{
    GameObject _HPmanager;

    // Start is called before the first frame update
    void Start()
    {
        _HPmanager = GameObject.Find("Boss1");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "weapon1")
        {
            _HPmanager.GetComponent<HPmanager>().UpdateHP(1f);
            Debug.Log("B_hit");
        }
    }
}
