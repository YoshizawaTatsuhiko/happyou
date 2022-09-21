using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class SpecialController : MonoBehaviour
{
    /// <summary>ゲージの減少速度</summary>
    [SerializeField] float _changeInterval = 1f;
    /// <summary>スペシャルゲージ</summary>
    [SerializeField] Slider _slider = default;
    /// <summary>ゲージの最大量</summary>
    [SerializeField] float _maxGauge;
    /// <summary>現在のゲージ量</summary>
    float _currentGauge;

    Special _sp;

    void Start()
    {
        _currentGauge = 0f;
        _sp = FindObjectOfType<Special>();
    }

    void Update()
    {
        //右クリックでスペシャルアタック
        if (Input.GetButton("Fire2"))
        {
            if (_currentGauge == _maxGauge)
            {
                _sp.SpecialWeapon();
                _currentGauge = 0f;  //Special Gaugeの初期化
            }
        }
    }

    /// <summary>スペシャルゲージを管理する</summary>
    /// <param name="SP">ゲージの増加量</param>
    public void UpdateGauge(float SP)
    {
        if(_currentGauge < _maxGauge)
        {
            _currentGauge += SP;
            DOTween.To(() => _slider.value, 
                x => _slider.value = x, _currentGauge / _maxGauge, _changeInterval);
        }
    }
}
