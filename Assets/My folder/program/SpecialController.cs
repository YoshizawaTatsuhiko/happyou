using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class SpecialController : MonoBehaviour
{
    /// <summary>�Q�[�W�̌������x</summary>
    [SerializeField] float _changeaInterval = 1f;
    /// <summary>�X�L���Q�[�W</summary>
    [SerializeField] Slider _slider = default;
    [SerializeField] GameObject _spBullet = default;
    [SerializeField] Transform _specialMuzzle = default;
    /// <summary>�Q�[�W�̍ő��</summary>
    [SerializeField] float _maxGauge;
    /// <summary>���݂̃Q�[�W��</summary>
    float _currentGauge;

    void Start()
    {
        _currentGauge = 0f;
    }

    void Update()
    {
        //�E�N���b�N�ŃX�y�V�����A�^�b�N
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

            //Special Gauge�̏�����
            _currentGauge = 0f;
        }
    }

    /// <summary>�X�L�����Ǘ�����</summary>
    /// <param name="SP">�Q�[�W�̑�����</param>
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
