using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossController : HPmanager
{
    GameObject _HPmanager;
    [SerializeField] GaugeController _gaugeCon;

    // Start is called before the first frame update
    void Start()
    {
        _HPmanager = GameObject.Find("Boss1");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "weapon1")
        {
            _HPmanager.GetComponent<HPmanager>().UpdateHP(1f);
            _gaugeCon.UpdateGauge(0.1f);
            Debug.Log("B_hit");
        }

        else if (collision.gameObject.tag == "weapon2")
        {
            _HPmanager.GetComponent<HPmanager>().UpdateHP(12f);
            Debug.Log("B_hit");
        }
    }
}
