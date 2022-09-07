using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeWeapon : MonoBehaviour
{
    [SerializeField] GameObject _main;
    [SerializeField] GameObject _saw;

    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.TryGetComponent<Item>(out Item item))
        {
            switch (item.WeaponType)
            {
                case WeaponType.main:
                    _main.SetActive(true);
                    _saw.SetActive(false);
                    break;

                case WeaponType.saw:
                    _main.SetActive(false);
                    _saw.SetActive(true);
                    break;
            }
        }
    }   
}

/// <summary>切り替える武器の種類</summary>
 public enum WeaponType
{
    /// <summary>デフォルト武器</summary>
    main,
    /// <summary>近距離のこぎり</summary>
    saw,
}
