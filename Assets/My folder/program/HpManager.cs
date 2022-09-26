using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using DG.Tweening;

public class HpManager : MonoBehaviour
{
    /// <summary>ゲージの減少速度</summary>
    [SerializeField] float _changeInterval = 1f;
    /// <summary>HPゲージ</summary>
    [SerializeField] Slider _slider = default;
    /// <summary>最大HP</summary>
    [SerializeField] private float _maxHP;
    /// <summary>現在のHP</summary>
    private float _currentHP;
    /// <summary>死んだらイメージを表示</summary>
    [SerializeField] Image _image;
    /// <summary>GodMode</summary>
    [SerializeField] bool _super = false;
    /// <summary>HPが一定以下になったら出現させる</summary>
    [SerializeField] GameObject _hands = default;

    void Start()
    {
        _currentHP = _maxHP;

        if(_super == true && gameObject.tag == "Player")
        {
            _currentHP = Mathf.Infinity;
        }
    }

    void Update()
    {
        if(gameObject.tag == "BOSS")
        {
            if(_currentHP <= _maxHP / 2)
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
        //playerが死んだらGameOver
        if(gameObject.tag == "Player")
        {
            _image.gameObject.SetActive(true);
            Cursor.visible = true;
        }

        //BOSSが死んだらGameClear
        else if(gameObject.tag == "BOSS")
        {
            _image.gameObject.SetActive(true); 
            Cursor.visible = true;
        }
        Destroy(gameObject);
    }

    /// <summary>HPを管理する</summary>
    /// <param name="damage">与えるダメージ</param>
    public void ReduceHP(float damage)
    {
        _currentHP -= damage;
        DOTween.To(() => _slider.value,
            x => _slider.value = x, _currentHP / _maxHP, _changeInterval);
    }
}