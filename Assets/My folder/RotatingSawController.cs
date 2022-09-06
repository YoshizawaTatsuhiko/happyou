using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatingSawController : Weapon
{
    [SerializeField] Animator _anim;
    [SerializeField] float _damage;
    [SerializeField] float _charge;
    SpecialController _spGauge;
    HPmanager _bHP;

    void Start()
    {
        _spGauge = FindObjectOfType<SpecialController>();
        _bHP = GameObject.FindGameObjectWithTag("BOSS").GetComponent<HPmanager>();
    }

    void Update()
    {
        if(Input.GetButton("Fire1"))
        {
            _anim.Play("pivot");
        }
    }

    public override void Attack()
    {
        _bHP.UpdateHP(_damage);
        _spGauge.UpdateGauge(_charge);
    }

    void OnTriggerStay2D(Collider2D collision)
    {
        Debug.Log("OK");
        CommonOnTrigger(collision);
    }
}
