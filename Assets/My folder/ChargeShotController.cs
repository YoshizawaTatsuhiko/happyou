using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class ChargeShotController : MonoBehaviour
{
    /// <summary>�`���[�W�V���b�g�̃v���n�u</summary>
    [SerializeField] GameObject _bulletPrefab = default;
    /// <summary>bullet �𔭎˂��� muzzle</summary>
    [SerializeField] Transform _muzzle = default;
    /// <summary>�`���[�W�V���b�g�̃C���X�^���X</summary>
    GameObject _bullet;

    void Update()
    {
        //���N���b�N�������Ă���(�`���[�W���Ă���)�Ԃ̏���
        if( Input.GetButtonDown("Fire1"))
        {
            if(_bullet == null)
            {
                _bullet = Instantiate(_bulletPrefab, _muzzle.transform.position, transform.rotation);
            }
        }

        if (Input.GetButtonUp("Fire1"))
        {
            if (_bullet != null)
            {
                _bullet.GetComponent<ChargeBulletController>().Release();
            }
        }
    }
}
