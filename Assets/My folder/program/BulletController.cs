using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]

public class BulletController : Weapon
{
    /// <summary>弾速</summary>
    [SerializeField] float _speed = 3f;
    /// <summary>弾消失までの時間</summary>
    [SerializeField] float _lifeTime = 5f;
    /// <summary>与えるダメージ</summary>
    [SerializeField] float _damage = 1f;
    /// <summary>スペシャルゲージ上昇値</summary>
    [SerializeField] float _charge = 1f;
    Rigidbody2D _rb;
    /// <summary>BOSSのHP</summary>
    HpManager _bossHP;
    /// <summary>スペシャルゲージ</summary>
    SpecialController _spGauge;

    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _rb.velocity = Vector2.up * _speed;    //弾のベクトル
        Destroy(gameObject, _lifeTime);    //時間が来たら消失
        _spGauge = FindObjectOfType<SpecialController>();
        _bossHP = GameObject.FindGameObjectWithTag("BOSS")?.GetComponent<HpManager>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "BOSS" || collision.gameObject.tag == "damage1")
        {
            CommonOnTrigger(collision);
            Destroy(gameObject);
        }
    }

    protected override void Attack()
    {
        _bossHP.ReduceHP(_damage);
        _spGauge.UpdateGauge(_charge);
    }
}
