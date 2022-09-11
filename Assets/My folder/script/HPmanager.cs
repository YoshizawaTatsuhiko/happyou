using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class HpManager : MonoBehaviour
{
    [SerializeField] private Image _hpBar;
    /// <summary>�ő�HP</summary>
    [SerializeField] private float _maxHP;
    [SerializeField] Image _image;
    /// <summary>�f�o�b�O�p GodMode</summary>
    [SerializeField] bool _super = false;
    /// <summary>����HP</summary>
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
        //player�����񂾂�gameover
        if (gameObject.tag == "Player")
        {
            _image.gameObject.SetActive(true);
        }

        //BOSS�����񂾂�gameclear
        if (gameObject.tag == "BOSS")
        {
            _image.gameObject.SetActive(true);
        }
        Destroy(gameObject);
    }

    /// <summary>HP���Ǘ�����</summary>
    /// <param name="damage">�^����_���[�W</param>
    public void ReduceHP(float damage)
    {
        //Debug.Log($"{damage}�̃_���[�W���󂯂�");
        _currentHP = Mathf.Clamp(_currentHP - damage, 0, _maxHP);
        _hpBar.fillAmount = _currentHP / _maxHP;
    }
}