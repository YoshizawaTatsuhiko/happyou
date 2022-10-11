using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class ChargeShotController : MonoBehaviour
{
    /// <summary>チャージショットのプレハブ</summary>
    [SerializeField] GameObject _bulletPrefab = default;
    /// <summary>bullet を発射する muzzle</summary>
    [SerializeField] Transform _muzzle = default;
    /// <summary>チャージショットのインスタンス</summary>
    GameObject _bullet;

    void Update()
    {
        //左クリックを押している(チャージしている)間の処理
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
