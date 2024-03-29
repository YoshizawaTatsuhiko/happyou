using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefaultWeaponController : MonoBehaviour
{
    [SerializeField] float _Interval = 1f;
    float _centerN;
    [SerializeField] GameObject _Bullet = default;
    [SerializeField] Transform _Muzzle = default;

    void Start()
    {
        _centerN = _Interval;
    }
    void FixedUpdate()
    {
        if (!FinishFragController.Instance.IsFinished && Input.GetButton("Fire1"))
        {
            MainAttack();
        }
    }

    void MainAttack()
    {
        _centerN += Time.deltaTime;
        //�e�̔��ˊԊu
        if (_centerN > _Interval)
        {
            _centerN = 0;

            //default weapon
            var bul = Instantiate(_Bullet, _Muzzle.position, transform.rotation);
            bul.transform.position = _Muzzle.position;
        }
    }
}
