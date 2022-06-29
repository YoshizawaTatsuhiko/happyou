using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]

public class BossBulletManager : MonoBehaviour
{
    //�e��
    [SerializeField] float _speed = 3f;
    //�e�����܂ł̎���
    [SerializeField] float b_lifeTime = 5f;
    Rigidbody2D _rb;

    [SerializeField] Transform _player;

    // Start is called before the first frame update
    void Start()
    {
        _player = GameObject.FindWithTag("Player").transform;

        //�v���C���[�Ɍ����������x�N�g�����擾����
        Vector3 direction = _player.position - transform.position;
        direction = direction.normalized;

        //�e�̎ˏo����
        _rb = GetComponent<Rigidbody2D>();
        //_rb.velocity = transform.up * _speed;
        _rb.velocity = direction * _speed;



        //���Ԃ����������
        Destroy(gameObject, b_lifeTime);

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            Destroy(gameObject);
        }
    }
}
