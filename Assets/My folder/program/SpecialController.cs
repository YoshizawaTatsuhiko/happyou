using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class SpecialController : MonoBehaviour
{
    [SerializeField] float _changeaInterval = 1f;
    [SerializeField] Slider _slider = default;
    [SerializeField] GameObject _spBullet = default;
    [SerializeField] Transform _specialMuzzle = default;
    [SerializeField] float _maxGauge;
    float _currentGauge;

    void Start()
    {
        _currentGauge = 0f;
    }

    void Update()
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
            var s_weapon = Instantiate
                (_spBullet, _specialMuzzle.position, transform.rotation);
            s_weapon.transform.position = _specialMuzzle.position;

            //Special Gaugeの初期化
            _currentGauge = 0f;
        }
    }

    public void UpdateGauge(float MP)
    {
        if (_currentGauge < _maxGauge)
        {
            _currentGauge += MP;
            DOTween.To(() => _slider.value, 
                x => _slider.value = x, _currentGauge / _maxGauge, _changeaInterval);
        }
    }
}
