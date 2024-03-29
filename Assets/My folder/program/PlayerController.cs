using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    /// <summary>機体の移動速度</summary>
    [SerializeField] float _machineSpeed;
    Rigidbody2D _rb;
    void Start()
    {
        Cursor.visible = false;
        _rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        PlayerControl();
    }
      
    private void PlayerControl()
    {
        if (FinishFragController.Instance.IsFinished)
        {
            _rb.simulated = false;
            return;
        }

        //空間でのマウス位置の計算
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector3 vec = mousePosition - transform.position;
        _rb.velocity = Vector2.zero;
        _rb.AddForce(vec.normalized * _machineSpeed, ForceMode2D.Force);
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        //攻撃を受けたらダメージをくらう
        if (collision.gameObject.tag == "damage1")
        {
            GetComponent<HpManager>().ReduceHP(1f);
        }
    }
}
    