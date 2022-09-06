using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]

public class BulletController : Weapon
{
    [SerializeField] float _speed = 3f;    //弾速
    [SerializeField] float _lifeTime = 5f;    //弾消失までの時間
    [SerializeField] float _damage = 1f;    //ダメージ値
    [SerializeField] float _charge = 1f;    //スペシャルゲージ上昇値
    Rigidbody2D _rb;
    HPmanager _bossHP;
    SpecialController _spGauge;

    void Awake()
    {
        _bossHP = GameObject.FindGameObjectWithTag("BOSS").GetComponent<HPmanager>();
    }
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();    //弾の射出方向
        _spGauge = FindObjectOfType<SpecialController>();
        Destroy(gameObject, _lifeTime);    //時間が来たら消失
    }

    void Update()
    {
        _rb.velocity = Vector2.up * _speed;    //弾の速度
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "BOSS" || collision.gameObject.tag == "damage1")
        {
            CommonOnTrigger(collision);
            Destroy(gameObject);
        }
    }

    public override void Attack()
    {
        _bossHP.UpdateHP(_damage);
        _spGauge.UpdateGauge(_charge);
    }
}
