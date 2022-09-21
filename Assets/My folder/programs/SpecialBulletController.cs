using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpecialBulletController : Special
{
    [SerializeField] GameObject _spBullet = default;
    [SerializeField] Transform _specialMuzzle = default;

    public override void SpecialWeapon()
    {
        //special weapon
        var s_weapon = Instantiate(
                    _spBullet, _specialMuzzle.position, transform.rotation);
        s_weapon.transform.position = _specialMuzzle.position;
    }
}
