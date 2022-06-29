using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]

public class BulletManager : MonoBehaviour
{
    //’e‘¬
    [SerializeField] float _speed = 3f;
    //’eÁ¸‚Ü‚Å‚ÌŠÔ
    [SerializeField] float b_lifeTime = 5f;
    Rigidbody2D _rb;
    // Start is called before the first frame update
    void Start()
    {
        //’e‚ÌËo•ûŒü
        _rb = GetComponent<Rigidbody2D>();
        _rb.velocity = Vector2.up * _speed;
        //ŠÔ‚ª—ˆ‚½‚çÁ¸
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
