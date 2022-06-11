using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootManager : MonoBehaviour
{
    public Vector2 Direction;
    //弾速
    [SerializeField] float _speed = 3f;
    //弾消失までの時間
    [SerializeField] float b_lifeTime = 5f;

    // Start is called before the first frame update
    void Start()
    {
        //弾の射出方向
        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        rb.velocity = Direction * _speed;
        //時間が来たら消失
        Destroy(this.gameObject, b_lifeTime);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
