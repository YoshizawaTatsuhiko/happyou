using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpecialAttackController : Weapon
{
    [SerializeField] float _damage = 1.0f;
    HpManager _bossHP;

    void Start()
    {
        _bossHP = GameObject.FindGameObjectWithTag("BOSS").GetComponent<HpManager>();
    }

    public override void Attack()
    {
        _bossHP.ReduceHP(_damage);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        CommonOnTrigger(collision);
    }
}
