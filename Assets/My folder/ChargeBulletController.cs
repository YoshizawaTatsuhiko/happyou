using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]

public class ChargeBulletController : Weapon
{
    /// <summary>�e��</summary>
    [SerializeField] float _speed = 1f;
    /// <summary>�^����_���[�W</summary>
    [SerializeField] float _damage = 1f;
    /// <summary>�X�y�V�����Q�[�W�㏸�l</summary>
    [SerializeField] float _charge = 1f;
    /// <summary>�e����������܂ł̎���</summary>
    [SerializeField] float _lifeTime = 1f;
    /// <summary>�`���[�W���Ԃ̍ő�l</summary>
    [SerializeField] float _chargeTime = 3f;
    /// <summary>�`���[�W���Ԃ̌v��</summary>
    float _chargeTimer = 0f;
    /// <summary>_bullet�̊g��{��</summary>
    [SerializeField] float _scaleMagnification = 1f;
    Rigidbody2D _rb;
    HpManager _bossHp;
    SpecialController _spGauge;

    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _bossHp = GameObject.FindGameObjectWithTag("BOSS").GetComponent<HpManager>();
        _spGauge = FindObjectOfType<SpecialController>();
    }

    void Update()
    {
        Vector2 bulletScale = transform.localScale;

        //���N���b�N�������Ă���(�`���[�W���Ă���)�Ԃ̏���
        if (Input.GetButton("Fire1"))
        {
            _chargeTimer += Time.deltaTime;
            _rb.velocity = Vector2.zero;

            if (_chargeTimer <= _chargeTime)
            {
                bulletScale.x += _scaleMagnification;
                bulletScale.y += _scaleMagnification;
            }

            transform.localScale = bulletScale;
        }

        //���N���b�N�𗣂����Ƃ��̏���
        if (Input.GetButtonUp("Fire1"))
        {
            //�`���[�W���Ԃ��ő�`���[�W���Ԃ̂R���̂P����
            if (_chargeTimer < _chargeTime / 3)
            {
                Destroy(gameObject);
            }

            //�`���[�W���Ԃ��ő�`���[�W���Ԃ̂R���̂P�ȏ�
            else if (_chargeTimer >= _chargeTime / 3)
            {
                _speed *= 1 / 3;
                _damage *= 2 / 3;
                _charge *= 2 / 3;
            }

            //�`���[�W���Ԃ��ő�`���[�W���Ԃ̂R���̂Q�ȏ�
            else if (_chargeTimer >= _chargeTime * 2 / 3)
            {
                _speed *= 2 / 3;
                _damage *= 3 / 3;
                _charge *= 3 / 3;
            }

            //�ő�܂Ń`���[�W������
            else if (_chargeTimer == _chargeTime)
            {
                _speed *= 3 / 3;
                _damage *= 3 / 2;
                _charge *= 3 / 2;
            }

            _rb.velocity = Vector2.up * _speed;
            _chargeTimer = 0f;
            Destroy(gameObject, _lifeTime);
        }
    }

    protected override void Attack()
    {
        _bossHp.ReduceHP(_damage);
        _spGauge.UpdateGauge(_charge);
    }
}
