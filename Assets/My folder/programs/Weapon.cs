using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Weapon : MonoBehaviour
{
    /// <summary> ƒEƒGƒ|ƒ“‹¤’Ê‚ÌÚGˆ—BŒp³æ‚ÌOnTriggerEnter2D‚ÅŒÄ‚ÔB</summary>
    /// <param name="collision"> ÚG‘ÎÛ </param>
    protected void CommonOnTrigger(Collider2D collision)
    {
        if(collision.gameObject.tag == "BOSS")
        {
            Attack();
        }
    }

    ///<summary>BOSS‚ÉUŒ‚‚ª“–‚½‚Á‚½‚Ìˆ—</summary>
    protected abstract void Attack();
}