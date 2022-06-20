using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootManager : MonoBehaviour
{
    public Vector2 Direction;
    //’e‘¬
    [SerializeField] float _speed = 3f;
    //’eÁ¸‚Ü‚Å‚ÌŠÔ
    [SerializeField] float b_lifeTime = 5f;

    // Start is called before the first frame update
    void Start()
    {
        //’e‚ÌËo•ûŒü
        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        rb.velocity = Direction * _speed;
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
