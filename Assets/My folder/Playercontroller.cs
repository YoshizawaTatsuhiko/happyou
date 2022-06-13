using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Playercontroller : MonoBehaviour
{
    [SerializeField] float C_interval = 1f;
    [SerializeField] float n;
    [SerializeField] float _macineSpeed;
    Rigidbody2D _rb;
    GameObject _MainShooter;
    void Start()
    {
        Cursor.visible = false;
        n = C_interval;
        _rb = GetComponent<Rigidbody2D>();
    }
    // Update is called once per frame

    [SerializeField] ShootManager _bulletC = default;
    [SerializeField] Transform muzzle_C = default;
    void FixedUpdate()
    {       
        if (Input.GetButton("Fire1"))
        {   
            //空間でのマウス位置の計算
            Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition); 
            Vector3 vec = mousePosition - transform.position;
            _rb.velocity = Vector2.zero;
            _rb.AddForce(vec.normalized * _macineSpeed, ForceMode2D.Impulse);

            n += Time.deltaTime;
            //弾の発射間隔
            if (n >= C_interval)
            {
                n = 0;

                //main weapon
                var bul1 = Instantiate(_bulletC, muzzle_C.position, this.transform.rotation);
                bul1.Direction = Vector3.up;
                bul1.transform.position = muzzle_C.position;
            }
        }
        else
        {
            _rb.velocity = Vector3.zero;
        }

        //クリックを離したら、機体が止まる(止まらない)
        //if(Input.GetMouseButtonUp(0))
        //{
        //    _rb.velocity = Vector3.zero;
        //    Debug.Log("a");
        //}
    }
}
    