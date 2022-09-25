using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChargeShotController : MonoBehaviour
{
    /// <summary>チャージショットの弾</summary>
    [SerializeField] GameObject _bullet = default;
    /// <summary>bullet を発射する muzzle</summary>
    [SerializeField] Transform _muzzle = default;

    void Update()
    {
        //左クリックを押している(チャージしている)間の処理
        if(Input.GetButtonDown("Fire1"))
        {
            Instantiate(_bullet, _muzzle.transform.position, transform.rotation);
        }
    }
}
