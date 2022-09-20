using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using DG.Tweening;

public class HpManager : MonoBehaviour
{
    [SerializeField] float _changeInterval = 1f;
    [SerializeField] Slider _slider = default;
    /// <summary>�ő�HP</summary>
    [SerializeField] private float _maxHP;
    [SerializeField] Image _image;
    /// <summary>GodMode</summary>
    [SerializeField] bool _super = false;
    /// <summary>���݂�HP</summary>
    private float _currentHP;
    //GameObject _player;

    void Start()
    {
        _currentHP = _maxHP;
        Cursor.visible = true;
        //_player = GameObject.FindGameObjectWithTag("Player");

        if(_super == true && gameObject.tag == "Player")
        {
            _currentHP = Mathf.Infinity;
        }
    }

    void Update()
    {
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
        }

        //BOSS�����񂾂�GameClear
        else if(gameObject.tag == "BOSS")
        {
            _image.gameObject.SetActive(true);
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