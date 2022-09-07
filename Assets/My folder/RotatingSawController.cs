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
    Collider2D _circleCol;

    void Start()
    {
        _spGauge = FindObjectOfType<SpecialController>();
        _bHP = GameObject.FindGameObjectWithTag("BOSS").GetComponent<HPmanager>();
        _circleCol = GetComponent<CircleCollider2D>();
        _circleCol.enabled = false;
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
            _circleCol.enabled = true;
            _anim.Play("pivot");
        }
    }
}
