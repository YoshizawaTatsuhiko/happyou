using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]

public class BossBulletManager : MonoBehaviour
{
    //弾速
    [SerializeField] float _speed = 3f;
    //弾消失までの時間
    [SerializeField] float b_lifeTime = 5f;
    Rigidbody2D _rb;
    Transform _player;

    void Start()
    {
        _player = GameObject.FindWithTag("Player")?.transform;

        if(_player != null)
        {        
            //プレイヤーに向かう方向ベクトルを取得する
            Vector3 direction = _player.position - transform.position;
            direction = direction.normalized;
            //弾の射出方向
            _rb = GetComponent<Rigidbody2D>();
            _rb.velocity = direction * _speed;
        }
        //時間が来たら消失
        Destroy(gameObject, b_lifeTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            Destroy(gameObject);
        }
    }
}
