using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Weapon : MonoBehaviour
{
    [SerializeField] AudioSource _audio;
    GameObject _player;

    void Start()
    {
        _audio = FindObjectOfType<AudioSource>();
        _player = GameObject.Find("Player");
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "")
        {
            _audio.Play();
        }
    }

    public abstract void AttackBehavior();
}