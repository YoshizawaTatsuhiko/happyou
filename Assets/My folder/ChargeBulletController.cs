using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]

public class ChargeBulletController : Weapon
{
    /// <summary>弾速</summary>
    [SerializeField] float _speed = 1f;
    /// <summary>与えるダメージ</summary>
    [SerializeField] float _damage = 1f;
    /// <summary>スペシャルゲージ上昇値</summary>
    [SerializeField] float _charge = 1f;
    /// <summary>弾が消失するまでの時間</summary>
    [SerializeField] float _lifeTime = 1f;
    /// <summary>チャージ時間の最大値</summary>
    [SerializeField] float _chargeTime = 3f;
    /// <summary>チャージ時間の計測</summary>
    float _chargeTimer = 0f;
    /// <summary>_bulletの拡大倍率</summary>
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

        //左クリックを押している(チャージしている)間の処理
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

        //左クリックを離したときの処理
        if (Input.GetButtonUp("Fire1"))
        {
            //チャージ時間が最大チャージ時間の３分の１未満
            if (_chargeTimer < _chargeTime / 3)
            {
                Destroy(gameObject);
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
