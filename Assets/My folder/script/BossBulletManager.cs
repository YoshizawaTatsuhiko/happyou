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

    [SerializeField] Transform _player;

    // Start is called before the first frame update
    void Start()
    {
        _player = GameObject.FindWithTag("Player").transform;

        //プレイヤーに向かう方向ベクトルを取得する
        Vector3 direction = _player.position - transform.position;
        direction = direction.normalized;

        //弾の射出方向
        _rb = GetComponent<Rigidbody2D>();
        //_rb.velocity = transform.up * _speed;
        _rb.velocity = direction * _speed;



        //時間が来たら消失
        Destroy(gameObject, b_lifeTime);

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            Destroy(gameObject);
        }
    }
}
