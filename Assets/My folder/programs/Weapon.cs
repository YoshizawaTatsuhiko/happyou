using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Weapon : MonoBehaviour
{
    /// <summary> �E�G�|�����ʂ̐ڐG�����B�p�����OnTriggerEnter2D�ŌĂԁB</summary>
    /// <param name="collision"> �ڐG�Ώ� </param>
    protected void CommonOnTrigger(Collider2D collision)
    {
        if(collision.gameObject.tag == "BOSS")
        {
            Attack();
        }
    }

    ///<summary>BOSS�ɍU���������������̏���</summary>
    protected abstract void Attack();
}