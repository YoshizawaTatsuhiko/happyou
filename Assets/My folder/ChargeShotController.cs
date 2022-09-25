using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChargeShotController : MonoBehaviour
{
    /// <summary>�`���[�W�V���b�g�̒e</summary>
    [SerializeField] GameObject _bullet = default;
    /// <summary>bullet �𔭎˂��� muzzle</summary>
    [SerializeField] Transform _muzzle = default;

    void Update()
    {
        //���N���b�N�������Ă���(�`���[�W���Ă���)�Ԃ̏���
        if(Input.GetButtonDown("Fire1"))
        {
            Instantiate(_bullet, _muzzle.transform.position, transform.rotation);
        }
    }
}
