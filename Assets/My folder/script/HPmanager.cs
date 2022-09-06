using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class HPmanager : MonoBehaviour
{
    [SerializeField] private Image _hpBar;
    [SerializeField] private float _maxHP;
    [SerializeField] Image _image;
    [SerializeField] bool _super = false;
    private float _currentHP;
    GameObject _player;

    void Start()
    {
        _currentHP = _maxHP;
        Cursor.visible = true;
        _player = GameObject.FindGameObjectWithTag("Player");

        if(_super == true)
        {
            
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
            Destroy(gameObject);
        }

        //BOSSが死んだらgameclear
        if (gameObject.tag == "BOSS")
        {
            _image.gameObject.SetActive(true);
            Destroy(gameObject);
        }
    }

    /// <summary>HPを管理する</summary>
    /// <param name="damage">与えるダメージ</param>
    public void UpdateHP(float damage)
    {
        Debug.Log($"{damage}のダメージを受けた");
        _currentHP -= damage;
        _hpBar.fillAmount = _currentHP / _maxHP;
    }
}