using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]

public class BulletManager : MonoBehaviour
{
    //弾速
    [SerializeField] float _speed = 3f;
    //弾消失までの時間
    [SerializeField] float b_lifeTime = 5f;
    Rigidbody2D _rb;
    // Start is called before the first frame update
    void Start()
    {
        //弾の射出方向
        _rb = GetComponent<Rigidbody2D>();
        _rb.velocity = Vector2.up * _speed;
        //時間が来たら消失
        Destroy(this.gameObject, b_lifeTime);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "BOSS" || collision.gameObject.tag == "damage1")
        {
            Destroy(gameObject);
        }
    }
}
