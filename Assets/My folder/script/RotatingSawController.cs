using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatingSawController : Weapon
{
    [SerializeField] Animator _anim;
    [SerializeField] float _damage;
    [SerializeField] float _charge;
    SpecialController _spGauge;
    HpManager _bHP;
    Collider2D _circleCol;
    bool _judge = false;

    void Start()
    {
        _spGauge = FindObjectOfType<SpecialController>();
        _bHP = GameObject.FindGameObjectWithTag("BOSS").GetComponent<HpManager>();
        _circleCol = GetComponent<CircleCollider2D>();
    }

    void Update()
    {
        if(_judge == true)
        {
            _circleCol.enabled = true;
            _anim.Play("Pivot");
        }
    }

    public override void Attack()
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
            _judge = true;
        }
        else
        {
            _judge = false;
        }
    }
}
