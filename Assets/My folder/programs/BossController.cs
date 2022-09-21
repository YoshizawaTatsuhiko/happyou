using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossController : MonoBehaviour
{
    Animator _anim;
    void Start()
    {
        _anim = GetComponent<Animator>();
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "weapon1")
        {
            _anim.Play("Hit Effect");
            Debug.Log("B_hit");
        }

        if (collision.gameObject.tag == "weapon2")
        {
            Debug.Log("S_hit");
        }
    }
}