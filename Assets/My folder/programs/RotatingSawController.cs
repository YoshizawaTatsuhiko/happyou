using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatingSawController : Weapon
{
    [SerializeField] float _damage;
    [SerializeField] float _charge;
    SpecialController _spGauge;
    HpManager _bHP;
    Collider2D _circleCol;
    Animator _anim;

    void Start()
    {
        _spGauge = FindObjectOfType<SpecialController>();
        _bHP = GameObject.FindGameObjectWithTag("BOSS").GetComponent<HpManager>();
        _circleCol = GetComponent<CircleCollider2D>();
        _anim = GetComponent<Animator>();
    }

    void Update()
    {
        if(Input.GetButton("Fire1"))
        {
            _anim.enabled = true;
            _anim.Play("RotatingSaw");
        }
        else
        {
            _anim.enabled = false;
        }
    }

    protected override void Attack()
    {
        _bHP.ReduceHP(_damage);
        _spGauge.UpdateGauge(_charge);
    }

    void OnTriggerStay2D(Collider2D collision)
    {
        if (Input.GetButton("Fire1"))
        {
            Debug.Log("OK");
            CommonOnTrigger(collision);
            _circleCol.enabled = true;
        }
    }
}
