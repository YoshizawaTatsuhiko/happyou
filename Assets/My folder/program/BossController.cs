using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossController : MonoBehaviour
{
    Animator _anim1;

    void Start()
    {
        _anim1 = GetComponent<Animator>();
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "weapon1")
        {
            _anim1.Play("Hit Effect");
            Debug.Log("B_hit");
        }

        if (collision.gameObject.tag == "weapon2")
        {
            Debug.Log("S_hit");
        }
    }
}
