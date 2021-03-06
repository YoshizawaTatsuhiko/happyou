using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class HPmanager : MonoBehaviour
{
    [SerializeField] private Image _hpBar;
    [SerializeField] private float _maxHP;
    [SerializeField] Image _image;

    // Start is called before the first frame update

    private float _currentHP;
    void Start()
    {
        _currentHP = _maxHP;
        Cursor.visible = true;
    }

    // Update is called once per frame
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

    public void UpdateHP(float damage)
    {
        if (_currentHP > 0)
        {
            _currentHP = Mathf.Clamp(_currentHP - damage, 0, _maxHP);
            _hpBar.fillAmount = _currentHP / _maxHP;
        }
    }
}