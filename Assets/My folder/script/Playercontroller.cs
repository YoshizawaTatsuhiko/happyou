using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Playercontroller : MonoBehaviour
{
    [SerializeField] float C_interval = 1f;
    [SerializeField] float C_n;
    [SerializeField] float S_interval = 1f;
    [SerializeField] float S_n;
    [SerializeField] float _macineSpeed;
    Rigidbody2D _rb;
    //GameObject _MainShooter;
    GameObject _HPmanager;
    void Start()
    {
        Cursor.visible = false;
        C_n = C_interval;
        S_n = S_interval;
        _rb = GetComponent<Rigidbody2D>();
        _HPmanager = GameObject.Find("player");
    }
    // Update is called once per frame

    [SerializeField] ShootManager _bulletC = default;
    [SerializeField] Transform muzzle_C = default;
    [SerializeField] ShootManager _bulletS = default;
    [SerializeField] Transform muzzle_S1 = default;
    [SerializeField] Transform muzzle_S2 = default;
    void FixedUpdate()
    {
        PlaterControl();

        if (Input.GetButton("Fire1"))
        {
            MainBullet();
        }

        else if (Input.GetButton("Fire2"))
        {
            SpecialBullet();
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
    
    private void MainBullet()
    {
        C_n += Time.deltaTime;
        //’e‚Ì”­ŽËŠÔŠu
        if (C_n >= C_interval)
        {
            C_n = 0;

            //main weapon
            var bul1 = Instantiate(_bulletC, muzzle_C.position, transform.rotation);
            bul1.Direction = Vector3.up;
            bul1.transform.position = muzzle_C.position;
        }
    }

    private void SpecialBullet()
    {
        S_n += Time.deltaTime;

        if (S_n >= S_interval)
        {
            S_n = 0;
            //special weapon
            var bul2 = Instantiate(_bulletS, muzzle_S1.position, transform.rotation);
            bul2.Direction = Vector3.up;
            bul2.transform.position = muzzle_S1.position;

            var bul3 = Instantiate(_bulletS, muzzle_S2.position, transform.rotation);
            bul3.Direction = Vector3.up;
            bul3.transform.position = muzzle_S2.position;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "damage1")
        {
            _HPmanager.GetComponent<HPmanager>().UpdateHP(1f);
            Debug.Log("P_hit");
        }
    }
}
    