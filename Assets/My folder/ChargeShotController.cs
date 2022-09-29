using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class ChargeShotController : MonoBehaviour
{
    /// <summary>チャージショットの弾</summary>
    [SerializeField] GameObject _bullet = default;
    /// <summary>bullet を発射する muzzle</summary>
    [SerializeField] Transform _muzzle = default;
    /// <summary>弾の生成を司るList</summary>
    List<GameObject> _goList = new List<GameObject>();

    void Update()
    {
        //左クリックを押している(チャージしている)間の処理
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
