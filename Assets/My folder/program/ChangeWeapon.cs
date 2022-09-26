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

/// <summary>�؂�ւ��镐��̎��</summary>
 public enum WeaponType
{
    /// <summary>�f�t�H���g����</summary>
    bullet,
    /// <summary>�ߋ����̂�����</summary>
    saw,
    /// <summary>�f�t�H���g�X�L��</summary>
    specialShot,
    /// <summary>��莞�Ԗ��G</summary>
    barrier,
}
