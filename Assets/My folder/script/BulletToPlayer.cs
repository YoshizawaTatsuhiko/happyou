using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletToPlayer : MonoBehaviour
{
    GameObject _target;

    // Start is called before the first frame update
    void Start()
    {
        _target = GameObject.FindWithTag("Player");
        Vector2 direction = _target.transform.position - transform.position;
        transform.up = direction;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
