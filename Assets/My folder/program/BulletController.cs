using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]

public class BulletController : Weapon
{
    /// <summary>�e��</summary>
    [SerializeField] float _speed = 3f;
    /// <summary>�e�����܂ł̎���</summary>
    [SerializeField] float _lifeTime = 5f;
    /// <summary>�^����_���[�W</summary>
    [SerializeField] float _damage = 1f;
    /// <summary>�X�y�V�����Q�[�W�㏸�l</summary>
    [SerializeField] float _charge = 1f;
    Rigidbody2D _rb;
    /// <summary>BOSS��HP</summary>
    HpManager _bossHP;
    /// <summary>�X�y�V�����Q�[�W</summary>
    SpecialController _spGauge;

    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _rb.velocity = Vector2.up * _speed;    //�e�̃x�N�g��
        Destroy(gameObject, _lifeTime);    //���Ԃ����������
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
