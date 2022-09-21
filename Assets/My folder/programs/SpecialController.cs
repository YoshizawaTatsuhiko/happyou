using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class SpecialController : MonoBehaviour
{
    /// <summary>�Q�[�W�̌������x</summary>
    [SerializeField] float _changeInterval = 1f;
    /// <summary>�X�y�V�����Q�[�W</summary>
    [SerializeField] Slider _slider = default;
    /// <summary>�Q�[�W�̍ő��</summary>
    [SerializeField] float _maxGauge;
    /// <summary>���݂̃Q�[�W��</summary>
    float _currentGauge;

    Special _sp;

    void Start()
    {
        _currentGauge = 0f;
        _sp = FindObjectOfType<Special>();
    }

    void Update()
    {
        //�E�N���b�N�ŃX�y�V�����A�^�b�N
        if (Input.GetButton("Fire2"))
        {
            if (_currentGauge == _maxGauge)
            {
                _sp.SpecialWeapon();
                _currentGauge = 0f;  //Special Gauge�̏�����
            }
        }
    }

    /// <summary>�X�y�V�����Q�[�W���Ǘ�����</summary>
    /// <param name="SP">�Q�[�W�̑�����</param>
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
