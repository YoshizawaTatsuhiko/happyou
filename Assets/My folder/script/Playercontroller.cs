using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Playercontroller : MonoBehaviour
{
    [SerializeField] float C_interval = 1f;
    [SerializeField] float C_n;
    [SerializeField] float _macineSpeed;
    Rigidbody2D _rb;
    void Start()
    {
        Cursor.visible = false;
        C_n = C_interval;
        _rb = GetComponent<Rigidbody2D>();
    }
    // Update is called once per frame

    [SerializeField] ShootManager _bulletC = default;
    [SerializeField] Transform muzzle_C = default;

    void FixedUpdate()
    {
        PlaterControl();

        if (Input.GetButton("Fire1"))
        {
            MainBullet();
        }

        if (Input.GetButton("Fire2"))
        {
            GetComponent<GaugeController>().SpecialBullet();
        }
    }
      
    private void PlaterControl()
    {
        //空間でのマウス位置の計算
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector3 vec = mousePosition - transform.position;
        _rb.velocity = Vector2.zero;
        _rb.AddForce(vec.normalized * _macineSpeed, ForceMode2D.Impulse);
    }
    
    void MainBullet()
    {
        C_n += Time.deltaTime;
        //弾の発射間隔
        if (C_n >= C_interval)
        {
            C_n = 0;

            //main weapon
            var bul1 = Instantiate(_bulletC, muzzle_C.position, transform.rotation);
            bul1.Direction = Vector3.up;
            bul1.transform.position = muzzle_C.position;
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "damage1")
        {
            GetComponent<HPmanager>().UpdateHP(1f);
            Debug.Log("P_hit");
        }
    }
}
    