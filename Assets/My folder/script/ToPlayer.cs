using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToPlayer : MonoBehaviour
{
    GameObject _target = default;

    void Start()
    {
        _target = GameObject.FindWithTag("Player");

        if(_target != null)
        {
            Vector2 direction = _target.transform.position - transform.position;
            transform.up = direction;
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
