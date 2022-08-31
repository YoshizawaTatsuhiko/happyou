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

    /// <summary> ウエポン共通の接触処理。継承先のOnTriggerEnter2Dで呼ぶ。</summary>
    /// <param name="collision"> 接触対象 </param>
    protected void CommonOnTrigger(Collider2D collision)
    {
        if (collision.gameObject.tag == "BOSS")
        {
            Attack();
        }
    }

    public abstract void Attack();
}