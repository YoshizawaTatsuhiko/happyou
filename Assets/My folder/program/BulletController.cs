using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]

public class BulletController : Weapon
{
    [SerializeField] float _speed = 3f;    //�e��
    [SerializeField] float _lifeTime = 5f;    //�e�����܂ł̎���
    [SerializeField] float _damage = 1f;    //�_���[�W�l
    [SerializeField] float _charge = 1f;    //�X�y�V�����Q�[�W�㏸�l
    Rigidbody2D _rb;
    HpManager _bossHP;
    SpecialController _spGauge;

    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _rb.velocity = Vector2.up * _speed;    //�e�̑��x
        Destroy(gameObject, _lifeTime);    //���Ԃ����������
        _spGauge = FindObjectOfType<SpecialController>();
        _bossHP = GameObject.FindGameObjectWithTag("BOSS").GetComponent<HpManager>();
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
        _bossHP.ReduceHP(_damage);
        _spGauge.UpdateGauge(_charge);
    }
}
