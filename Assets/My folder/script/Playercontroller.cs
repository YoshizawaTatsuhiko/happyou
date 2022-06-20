using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Playercontroller : MonoBehaviour
{
    [SerializeField] float C_interval = 1f;
    [SerializeField] float n;
    [SerializeField] float _macineSpeed;
    Rigidbody2D _rb;
    //GameObject _MainShooter;
    GameObject _HPmanager;
    void Start()
    {
        Cursor.visible = false;
        n = C_interval;
        _rb = GetComponent<Rigidbody2D>();
        _HPmanager = GameObject.Find("player");
    }
    // Update is called once per frame

    [SerializeField] ShootManager _bulletC = default;
    [SerializeField] Transform muzzle_C = default;
    void FixedUpdate()
    {       
        if (Input.GetButton("Fire1"))
        {   
            //‹óŠÔ‚Å‚Ìƒ}ƒEƒXˆÊ’u‚ÌŒvŽZ
            Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition); 
            Vector3 vec = mousePosition - transform.position;
            _rb.velocity = Vector2.zero;
            _rb.AddForce(vec.normalized * _macineSpeed, ForceMode2D.Impulse);

            n += Time.deltaTime;
            //’e‚Ì”­ŽËŠÔŠu
            if (n >= C_interval)
            {
                n = 0;

                //main weapon
                var bul1 = Instantiate(_bulletC, muzzle_C.position,transform.rotation);
                bul1.Direction = Vector3.up;
                bul1.transform.position = muzzle_C.position;
            }
        }
        else
        {
            _rb.velocity = Vector3.zero;
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
    