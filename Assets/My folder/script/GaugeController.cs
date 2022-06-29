using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GaugeController : MonoBehaviour
{
    [SerializeField] BulletManager _bulletS = default;
    [SerializeField] Transform muzzle_S1 = default;
    [SerializeField] Transform muzzle_S2 = default;
    [SerializeField] float _maxGauge;
    float _currentGauge;
    [SerializeField] Image _gauge;

    // Start is called before the first frame update
    void Start()
    {
        _currentGauge = 0f;
        _gauge.fillAmount = _currentGauge;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SpecialBullet()
    {
        if (_currentGauge >= _maxGauge)
        {
            //special weapon
            var bul2 = Instantiate(_bulletS, muzzle_S1.position, transform.rotation);
            bul2.transform.position = muzzle_S1.position;

            var bul3 = Instantiate(_bulletS, muzzle_S2.position, transform.rotation);
            bul3.transform.position = muzzle_S2.position;

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
