using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class SpecialController : MonoBehaviour
{
    /// <summary>ゲージの減少速度</summary>
    [SerializeField] float _changeaInterval = 1f;
    /// <summary>スキルゲージ</summary>
    [SerializeField] Slider _slider = default;
    [SerializeField] GameObject _spBullet = default;
    [SerializeField] Transform _specialMuzzle = default;
    /// <summary>ゲージの最大量</summary>
    [SerializeField] float _maxGauge;
    /// <summary>現在のゲージ量</summary>
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
        if(_currentGauge == _maxGauge)
        {
            //special weapon
            var s_weapon = Instantiate
                (_spBullet, _specialMuzzle.position, transform.rotation);
            s_weapon.transform.position = _specialMuzzle.position;

            //Special Gaugeの初期化
            _currentGauge = 0f;
        }
    }

    /// <summary>スキルを管理する</summary>
    /// <param name="SP">ゲージの増加量</param>
    public void UpdateGauge(float SP)
    {
        if(_currentGauge < _maxGauge)
        {
            _currentGauge += SP;
            DOTween.To(() => _slider.value, 
                x => _slider.value = x, _currentGauge / _maxGauge, _changeaInterval);
        }
    }
}
