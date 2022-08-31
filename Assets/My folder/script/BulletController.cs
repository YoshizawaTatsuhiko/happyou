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
    HPmanager _bossHP;
    SpecialController _gauge;

    void Awake()
    {
        _bossHP = GameObject.FindGameObjectWithTag("BOSS").GetComponent<HPmanager>();
    }
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();    //�e�̎ˏo����
        Destroy(gameObject, _lifeTime);    //���Ԃ����������
        _gauge = FindObjectOfType<SpecialController>();
        Destroy(gameObject,_lifeTime);
    }

    void Update()
    {
        _rb.velocity = Vector2.up * _speed;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "BOSS" || collision.gameObject.tag == "damage1")
        {
            CommonOnTrigger(collision);
        }
    }

    public override void Attack()
    {
        _bossHP.UpdateHP(_damage);
        _gauge.UpdateGauge(_charge);
    }
}
