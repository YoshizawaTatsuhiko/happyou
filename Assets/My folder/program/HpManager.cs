using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using DG.Tweening;

public class HpManager : MonoBehaviour
{
    [SerializeField] float _changeInterval = 1f;
    [SerializeField] Slider _slider = default;
    /// <summary>ç≈ëÂHP</summary>
    [SerializeField] private float _maxHP;
    [SerializeField] Image _image;
    /// <summary>GodMode</summary>
    [SerializeField] bool _super = false;
    /// <summary>åªç›ÇÃHP</summary>
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
        //playerÇ™éÄÇÒÇæÇÁGameOver
        if(gameObject.tag == "Player")
        {
            _image.gameObject.SetActive(true);
        }

        //BOSSÇ™éÄÇÒÇæÇÁGameClear
        else if(gameObject.tag == "BOSS")
        {
            _image.gameObject.SetActive(true);
        }
        Destroy(gameObject);
    }

    /// <summary>HPÇä«óùÇ∑ÇÈ</summary>
    /// <param name="damage">ó^Ç¶ÇÈÉ_ÉÅÅ[ÉW</param>
    public void ReduceHP(float damage)
    {
        _currentHP -= damage;
        DOTween.To(() => _slider.value,
            x => _slider.value = x, _currentHP / _maxHP, _changeInterval);
    }
}