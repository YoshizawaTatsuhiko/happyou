using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeWeapon : MonoBehaviour
{
    [SerializeField] GameObject _main;
    [SerializeField] GameObject _saw;

    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.TryGetComponent(out Item item))
        {
            switch (item.WeaponType)
            {
                case WeaponType.bullet:
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

/// <summary>�؂�ւ��镐��̎��</summary>
 public enum WeaponType
{
    /// <summary>�f�t�H���g����</summary>
    bullet,
    /// <summary>�ߋ����̂�����</summary>
    saw,
}