using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float _centerInterval = 1f;
    [SerializeField] float _centerN;
    [SerializeField] float _macineSpeed;
    Rigidbody2D _rb;
    void Start()
    {
        Cursor.visible = false;
        _centerN = _centerInterval;
        _rb = GetComponent<Rigidbody2D>();
    }
    // Update is called once per frame

    [SerializeField] BulletManager _centerBullet = default;
    [SerializeField] Transform _centerMuzzle = default;

    void FixedUpdate()
    {
        PlayerControl();

        if (Input.GetButton("Fire1"))
        {
            MainAttack();
        }

        if (Input.GetButton("Fire2"))
        {
            GetComponent<GaugeController>().SpecialBullet();
        }
    }
      
    private void PlayerControl()
    {
        //‹óŠÔ‚Å‚Ìƒ}ƒEƒXˆÊ’u‚ÌŒvŽZ
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector3 vec = mousePosition - transform.position;
        _rb.velocity = Vector2.zero;
        _rb.AddForce(vec.normalized * _macineSpeed, ForceMode2D.Impulse);
    }
    
    void MainAttack()
    {
        _centerN += Time.deltaTime;
        //’e‚Ì”­ŽËŠÔŠu
        if (_centerN >= _centerInterval)
        {
            _centerN = 0;

            //main weapon
            var bul = Instantiate(_centerBullet, _centerMuzzle.position, transform.rotation);
            bul.transform.position = _centerMuzzle.position;
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
    