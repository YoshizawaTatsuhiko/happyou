using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    [SerializeField] WeaponType _weaponType;
    public WeaponType WeaponType => _weaponType;

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player");
        {
            Destroy(gameObject);
        }
    }
}
