using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hoge : MonoBehaviour
{
    [SerializeField] float _speed;
    Rigidbody2D _rb;

    bool b;

    // Start is called before the first frame update
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButton("Fire1"))
        {
            Debug.Log("—Í‚ð‰Á‚¦‚é");
            b = true;
        }
    }

    void FixedUpdate()
    {
        if (b)
        {
            Vector3 mPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector3 vec = mPos - transform.position;

            _rb.velocity = Vector2.zero;
            _rb.AddForce(vec.normalized * _speed, ForceMode2D.Impulse);

            b = false;
        }
    }
}