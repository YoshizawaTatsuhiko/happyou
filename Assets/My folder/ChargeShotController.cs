using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]

public class ChargeShotController : MonoBehaviour
{
    /// <summary>�`���[�W�V���b�g�̒e</summary>
    [SerializeField] GameObject _bullet = default;
    /// <summary>bullet �𔭎˂��� muzzle</summary>
    [SerializeField] Transform _muzzle = default;
    /// <summary>�`���[�W���Ԃ̍ő�l</summary>
    [SerializeField] float _chargeTime = 3f;
    /// <summary>�`���[�W���Ԃ̌v��</summary>
    float _chargeTimer = 0f;
    /// <summary>�e��</summary>
    [SerializeField] float _speed = 1f;
    /// <summary>�^����_���[�W</summary>
    [SerializeField] float _damage = 1f;
    /// <summary>�X�y�V�����Q�[�W�㏸�l</summary>
    [SerializeField] float _charge = 1f;
    AudioSource _chargeSound;
    ChargeBulletController _cbc;

    void Start()
    {
        _chargeSound = GetComponent<AudioSource>();
    }

    void Update()
    {
        Vector2 bulletScale;  //�e�̑傫��
        bulletScale = _bullet.transform.localScale;

        //���N���b�N�������Ă���(�`���[�W���Ă���)�Ԃ̏���
        if(Input.GetButton("Fire1"))
        {
            _chargeTimer += Time.deltaTime;
            _chargeSound.Play();
            Instantiate(_bullet, _muzzle.transform.position, transform.rotation);

            if(_chargeTimer <= _chargeTime)
            {
                bulletScale.x += 0.1f;
                bulletScale.y += 0.1f;
            }
        }

        //���N���b�N�𗣂����Ƃ��̏���
        else
        {
            _bullet.transform.localScale = bulletScale;

            //�`���[�W���Ԃ��ő�`���[�W���Ԃ̂R���̂P����
            if(_chargeTimer < _chargeTime / 3)
            {
                Destroy(_bullet);
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

            _cbc.ChargeBulletValue(_speed, _damage, _charge);
            _chargeTimer = 0f;
        }
    }
}
