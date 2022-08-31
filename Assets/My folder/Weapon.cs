using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Weapon : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "BOSS")
        {
            Attack();
        }
    }

    /// <summary> �E�G�|�����ʂ̐ڐG�����B�p�����OnTriggerEnter2D�ŌĂԁB</summary>
    /// <param name="collision"> �ڐG�Ώ� </param>
    protected void CommonOnTrigger(Collider2D collision)
    {
        if (collision.gameObject.tag == "BOSS")
        {
            Attack();
        }
    }

    public abstract void Attack();
}