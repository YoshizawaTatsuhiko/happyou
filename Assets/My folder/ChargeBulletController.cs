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
    /// <summary>�e���ł����Ȃ�Â���t���O�itrue �̎��ł����Ȃ�j</summary>
    bool _isGrowing = true;

    /// <summary>�e���ł����Ȃ�̂���߁A���˂���</summary>
    public void Release()
    {
        _isGrowing = false;

        //�`���[�W���Ԃ��ő�`���[�W���Ԃ̂R���̂P�����̎�
        if (_chargeTimer < _chargeTime / 3)
        {
            Destroy(gameObject);
        }

        //�`���[�W���Ԃ��ő�`���[�W���Ԃ̂R���̂P�ȏ�̎�
        else if (_chargeTimer >= _chargeTime / 3)
        {
            _speed *= 1f / 3;
            _damage *= 2f / 3;
            _charge *= 2f / 3;
        }

        //�`���[�W���Ԃ��ő�`���[�W���Ԃ̂R���̂Q�ȏ�̎�
        else if (_chargeTimer >= _chargeTime * 2 / 3)
        {
            _speed *= 2f / 3;
        }

        //�ő�܂Ń`���[�W������
        else if (_chargeTimer == _chargeTime)
        {
            _damage *= 1.5f;
            _charge *= 1.5f;
        }

        _rb.velocity = Vector2.up * _speed;
        _chargeTimer = 0f;
        Destroy(gameObject, _lifeTime);
    }

    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _bossHp = GameObject.FindGameObjectWithTag("BOSS").GetComponent<HpManager>();
        _spGauge = FindObjectOfType<SpecialController>();
    }

    void Update()
    {
        Vector2 bulletScale = transform.localScale;

        // �ł����Ȃ鏈��
        if (_isGrowing)
        { 
            //���N���b�N�������Ă���(�`���[�W���Ă���)�Ԃ̏���
            _chargeTimer += Time.deltaTime;
            _rb.velocity = Vector2.zero;

            if (_chargeTimer <= _chargeTime)
            {
                bulletScale.x += _scaleMagnification;
                bulletScale.y += _scaleMagnification;
            }

            transform.localScale = bulletScale;
        }
    }

    protected override void Attack()
    {
        _bossHp.ReduceHP(_damage);
        _spGauge.UpdateGauge(_charge);
    }
}
