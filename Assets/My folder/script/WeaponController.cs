using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponController : MonoBehaviour
{
    [SerializeField] float _centerInterval = 1f;
    float _centerN;
    [SerializeField] GameObject _centerBullet = default;
    [SerializeField] Transform _centerMuzzle = default;

    void Start()
    {
        _centerN = _centerInterval;
    }
    void FixedUpdate()
    {
        if (Input.GetButton("Fire1"))
        {
            MainAttack();
        }
    }

    void MainAttack()
    {
        _centerN += Time.deltaTime;
        //’e‚Ì”­ŽËŠÔŠu
        if (_centerN >= _centerInterval)
        {
            _centerN = 0;

            //main weapon
            var bul = Instantiate(_centerBullet, _centerMuzzle.position, transform.rotation);
            bul.transform.position = _centerMuzzle.position;
        }
    }
}
