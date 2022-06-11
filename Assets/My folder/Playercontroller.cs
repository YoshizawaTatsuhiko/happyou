using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Playercontroller : MonoBehaviour
{
    [SerializeField] float _macineSpeed;
    Rigidbody2D _rb;
    [SerializeField] GameObject _MainShooter;
    void Start()
    {
        Cursor.visible = false;
        _rb = GetComponent<Rigidbody2D>();
    }
    // Update is called once per frame
    void FixedUpdate()
    {       
        if (Input.GetButton("Fire1"))
        {   
            Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition); //空間でのマウス位置の計算
            Vector3 vec = mousePosition - transform.position;
            _rb.velocity = Vector2.zero;
            _rb.AddForce(vec.normalized * _macineSpeed, ForceMode2D.Impulse);
            //Debug.Log(mousePosition);
            //mousePosition.z = 0;
            //this.transform.position = mousePosition;

            _MainShooter.GetComponent<MainManager>();
        }

        //クリックを離したら、機体が止まる(止まらない)
        if(Input.GetMouseButtonUp(0))
            {
                _rb.velocity = Vector2.zero;
            }
    }
}
    