using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]

public class ChargeBulletController : Weapon
{
    float _damage;
    float _charge;
    Rigidbody2D _rb;
    HpManager _bossHp;
    SpecialController _spGauge;

    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _bossHp = GameObject.FindGameObjectWithTag("BOSS").GetComponent<HpManager>();
        _spGauge = FindObjectOfType<SpecialController>();
    }

    public void ChargeBulletValue(float speed, float damege, float charge)
    {
        _rb.velocity = Vector2.up * speed;
        _damage = damege;
        _charge = charge;
    }

    protected override void Attack()
    {
        _bossHp.ReduceHP(_damage);
        _spGauge.UpdateGauge(_charge);
    }
}
