using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToPlayer : MonoBehaviour
{
    GameObject _target;

    // Start is called before the first frame update
    void Start()
    {
        _target = GameObject.FindWithTag("Player");
        Vector2 direction = _target.transform.position - transform.position;
        transform.up = direction;

        if(_target == null)
        {
            Destroy(gameObject);
        }
    }
}
