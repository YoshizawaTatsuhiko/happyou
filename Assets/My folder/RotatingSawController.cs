using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatingSawController : MonoBehaviour
{
    [SerializeField] Animator _anim;
    [SerializeField] float _damage;
    GameObject boss;

    public void Weapon()
    {
        boss = GameObject.FindGameObjectWithTag("BOSS");
        boss.GetComponent<HPmanager>().UpdateHP(_damage);
    }

    void OnTriggerStay2D(Collider2D collision)
    {
        Debug.Log("OK");
        if(Input.GetButton("Fire1"))
        {
            _anim.Play("pivot");

            if (collision.gameObject.tag == "BOSS")
            {
                Weapon();
            }
        }
    }
}
