using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class HpManager : MonoBehaviour
{
    [SerializeField] private Image _hpBar;
    /// <summary>最大HP</summary>
    [SerializeField] private float _maxHP;
    [SerializeField] Image _image;
    /// <summary>デバッグ用 GodMode</summary>
    [SerializeField] bool _super = false;
    /// <summary>現在HP</summary>
    private float _currentHP;
    GameObject _player;

    void Start()
    {
        _currentHP = _maxHP;
        Cursor.visible = true;
        _player = GameObject.FindGameObjectWithTag("Player");

        if(_super == true && gameObject.tag == "Player")
        {
            _currentHP += Mathf.Infinity;
        }
    }

    void Update()
    {
        if (_currentHP <= 0)
        {
            ImageLord();
        }
    }

    private void ImageLord()
    {
        //playerが死んだらgameover
        if (gameObject.tag == "Player")
        {
            _image.gameObject.SetActive(true);
        }

        //BOSSが死んだらgameclear
        if (gameObject.tag == "BOSS")
        {
            _image.gameObject.SetActive(true);
        }
        Destroy(gameObject);
    }

    /// <summary>HPを管理する</summary>
    /// <param name="damage">与えるダメージ</param>
    public void ReduceHP(float damage)
    {
        //Debug.Log($"{damage}のダメージを受けた");
        _currentHP = Mathf.Clamp(_currentHP - damage, 0, _maxHP);
        _hpBar.fillAmount = _currentHP / _maxHP;
    }
}