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
    Transform _player;

    void Start()
    {
        _player = GameObject.FindWithTag("Player")?.transform;

        if(_player != null)
        {        
            //�v���C���[�Ɍ����������x�N�g�����擾����
            Vector3 direction = _player.position - transform.position;
            direction = direction.normalized;
            //�e�̎ˏo����
            _rb = GetComponent<Rigidbody2D>();
            _rb.velocity = direction * _speed;
        }
        //���Ԃ����������
        Destroy(gameObject, b_lifeTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            Destroy(gameObject);
        }
    }
}
