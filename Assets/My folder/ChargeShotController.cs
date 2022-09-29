using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class ChargeShotController : MonoBehaviour
{
    /// <summary>�`���[�W�V���b�g�̒e</summary>
    [SerializeField] GameObject _bullet = default;
    /// <summary>bullet �𔭎˂��� muzzle</summary>
    [SerializeField] Transform _muzzle = default;
    /// <summary>�e�̐������i��List</summary>
    List<GameObject> _goList = new List<GameObject>();

    void Update()
    {
        //���N���b�N�������Ă���(�`���[�W���Ă���)�Ԃ̏���
        if(Input.GetButtonDown("Fire1"))
        {
            if(_bullet != null)
            {
                Instantiate(_bullet, _muzzle.transform.position, transform.rotation);
            }
            else
            {
                _goList.Add(_bullet);
            }
        }
    }
}
