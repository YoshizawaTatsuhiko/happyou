using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using DG.Tweening;

public class HpManager : MonoBehaviour
{
    /// <summary>�Q�[�W�̌������x</summary>
    [SerializeField] float _changeInterval = 1f;
    /// <summary>HP�Q�[�W</summary>
    [SerializeField] Slider _slider = default;
    /// <summary>�ő�HP</summary>
    [SerializeField] private float _maxHP;
    /// <summary>���݂�HP</summary>
    private float _currentHP;
    /// <summary>���񂾂�C���[�W��\��</summary>
    [SerializeField] Image _image;
    /// <summary>�f�o�b�O�p���G���[�h</summary>
    [SerializeField] bool _super = false;
    /// <summary>HP�����ȉ��ɂȂ�����o��������</summary>
    [SerializeField] GameObject _hands = default;
    [SerializeField] GameObject _onDestroy = default;

    void Start()
    {
        _currentHP = _maxHP;

        if(_super )
        {
            _currentHP = Mathf.Infinity;
        }
    }

    void Update()
    {
        if(gameObject.tag == "BOSS")
        {
            if(_currentHP <= _maxHP * 3 / 5)
            {
                _hands.SetActive(true);
            }
        }

        if(_currentHP <= 0)
        {
            ImageLord();
        }
    }

    private void ImageLord()
    {
        //player�����񂾂�GameOver
        if(gameObject.tag == "Player")
        {
            _image.gameObject.SetActive(true);
            Cursor.visible = true;
            Instantiate(_onDestroy, transform.position, transform.rotation);
        }

        //BOSS�����񂾂�GameClear
        else if(gameObject.tag == "BOSS")
        {
            _image.gameObject.SetActive(true); 
            Cursor.visible = true;
        }
        Destroy(gameObject);
    }

    /// <summary>HP���Ǘ�����</summary>
    /// <param name="damage">�^����_���[�W</param>
    public void ReduceHP(float damage)
    {
        _currentHP -= damage;
        DOTween.To(() => _slider.value,
            x => _slider.value = x, _currentHP / _maxHP, _changeInterval);
    }
}