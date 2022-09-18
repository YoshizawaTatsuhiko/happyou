using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpecialController : MonoBehaviour
{
    [SerializeField] GameObject _spBullet = default;
    [SerializeField] Transform _specialMuzzle = default;
    [SerializeField] float _maxGauge;
    float _currentGauge;
    [SerializeField] Image _gauge;

    void Start()
    {
        _currentGauge = 0f;
        _gauge.fillAmount = _currentGauge;
    }

    void FixedUpdate()
    {
        //右クリックでスペシャルアタック
        if (Input.GetButton("Fire2"))
        {
            SpecialWeapon();
        }
    }

    void SpecialWeapon()
    {
        if (_currentGauge == _maxGauge)
        {
            //special weapon
            var bul2 = Instantiate(_spBullet, _specialMuzzle.position, transform.rotation);
            bul2.transform.position = _specialMuzzle.position;

            //bulletのインターバル初期化
            _currentGauge = 0f;
            _gauge.fillAmount = _currentGauge;
        }
    }

    public void UpdateGauge(float MP)
    {
        if (_currentGauge <= _maxGauge)
        {
            _currentGauge = Mathf.Clamp(_currentGauge + MP, 0, _maxGauge);
            _gauge.fillAmount = _currentGauge / _maxGauge;
        }
    }
}
