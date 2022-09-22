using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]

public class ChargeShotController : MonoBehaviour
{
    /// <summary>チャージショットの弾</summary>
    [SerializeField] GameObject _bullet = default;
    /// <summary>bullet を発射する muzzle</summary>
    [SerializeField] Transform _muzzle = default;
    /// <summary>チャージ時間の最大値</summary>
    [SerializeField] float _chargeTime = 3f;
    /// <summary>チャージ時間の計測</summary>
    float _chargeTimer = 0f;
    /// <summary>弾速</summary>
    [SerializeField] float _speed = 1f;
    /// <summary>与えるダメージ</summary>
    [SerializeField] float _damage = 1f;
    /// <summary>スペシャルゲージ上昇値</summary>
    [SerializeField] float _charge = 1f;
    AudioSource _chargeSound;
    ChargeBulletController _cbc;

    void Start()
    {
        _chargeSound = GetComponent<AudioSource>();
    }

    void Update()
    {
        Vector2 bulletScale;  //弾の大きさ
        bulletScale = _bullet.transform.localScale;

        //左クリックを押している(チャージしている)間の処理
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

        //左クリックを離したときの処理
        else
        {
            _bullet.transform.localScale = bulletScale;

            //チャージ時間が最大チャージ時間の３分の１未満
            if(_chargeTimer < _chargeTime / 3)
            {
                Destroy(_bullet);
            }

            //チャージ時間が最大チャージ時間の３分の１以上
            else if (_chargeTimer >= _chargeTime / 3)
            {
                _speed *= 1 / 3;
                _damage *= 2 / 3;
                _charge *= 2 / 3;
            }

            //チャージ時間が最大チャージ時間の３分の２以上
            else if (_chargeTimer >= _chargeTime * 2 / 3)
            {
                _speed *= 2 / 3;
                _damage *= 3 / 3;
                _charge *= 3 / 3;
            }

            //最大までチャージした時
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
