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
                case WeaponType.Bullet:
                    _bullet.SetActive(true);
                    _saw.SetActive(false);
                    break;

                case WeaponType.RotatingSaw:
                    _bullet.SetActive(false);
                    _saw.SetActive(true);
                    break;
            }
        }
    }   
}

/// <summary>�؂�ւ��镐��̎��</summary>
 public enum WeaponType
{
    /// <summary>�f�t�H���g����</summary>
    Bullet,
    /// <summary>�ߋ����̂�����</summary>
    RotatingSaw,
//    /// <summary>�f�t�H���g�X�L��</summary>
//    SpecialShot,
//    /// <summary>��莞�Ԗ��G</summary>
//    Barrier,
}
