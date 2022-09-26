using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeWeapon : MonoBehaviour
{
    [SerializeField] GameObject _bullet = default;
    [SerializeField] GameObject _saw = default;
    [SerializeField] GameObject _specialShot = default;
    [SerializeField] GameObject _barrier = default;

    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.TryGetComponent(out Item item))
        {
            switch (item.WeaponType)
            {
                case WeaponType.bullet:
                    _bullet.SetActive(true);
                    _saw.SetActive(false);
                    break;

                case WeaponType.saw:
                    _bullet.SetActive(false);
                    _saw.SetActive(true);
                    break;
            }

            switch (item.WeaponType)
            {
                case WeaponType.bullet:
                    _specialShot.SetActive(true);
                    _barrier.SetActive(false);
                    break;

                case WeaponType.saw:
                    _specialShot.SetActive(false);
                    _barrier.SetActive(true);
                    break;
            }
        }
    }   
}

/// <summary>切り替える武器の種類</summary>
 public enum WeaponType
{
    /// <summary>デフォルト武器</summary>
    bullet,
    /// <summary>近距離のこぎり</summary>
    saw,
    /// <summary>デフォルトスキル</summary>
    specialShot,
    /// <summary>一定時間無敵</summary>
    barrier,
}
