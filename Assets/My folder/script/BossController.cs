using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossController : MonoBehaviour
{
    GameObject _HPmanager;
    [SerializeField] SpecialController _gaugeCon;

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "weapon1")
        {
            _HPmanager.GetComponent<HPmanager>().UpdateHP(1);
            _gaugeCon.UpdateGauge(0.1f);
            Debug.Log("B_hit");
        }

        if (collision.gameObject.tag == "weapon2")
        {
            _HPmanager.GetComponent<HPmanager>().UpdateHP(10);
            Debug.Log("B_hit");
        }
    }
}
