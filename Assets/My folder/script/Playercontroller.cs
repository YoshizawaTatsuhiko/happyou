using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : HPmanager
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

    [SerializeField] BulletManager _bulletC = default;
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
        //‹óŠÔ‚Å‚Ìƒ}ƒEƒXˆÊ’u‚ÌŒvŽZ
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector3 vec = mousePosition - transform.position;
        _rb.velocity = Vector2.zero;
        _rb.AddForce(vec.normalized * _macineSpeed, ForceMode2D.Impulse);
    }
    
    void MainBullet()
    {
        C_n += Time.deltaTime;
        //’e‚Ì”­ŽËŠÔŠu
        if (C_n >= C_interval)
        {
            C_n = 0;

            //main weapon
            var bul = Instantiate(_bulletC, muzzle_C.position, transform.rotation);
            bul.transform.position = muzzle_C.position;
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
    