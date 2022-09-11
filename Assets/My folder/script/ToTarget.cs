using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToTarget : MonoBehaviour
{
    [SerializeField] GameObject _target = default;

    void Start()
    {
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
