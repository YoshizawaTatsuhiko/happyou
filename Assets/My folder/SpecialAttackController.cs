using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpecialAttackController : Weapon
{
    [SerializeField] float _damage = 1.0f;
    HPmanager _bossHP;

    void Start()
    {
        _bossHP = GameObject.FindGameObjectWithTag("BOSS").GetComponent<HPmanager>();
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
