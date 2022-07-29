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

    // Start is called before the first frame update
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
        //player�����񂾂�gameover
        if (gameObject.tag == "Player")
        {
            _image.gameObject.SetActive(true);
            Destroy(gameObject);
        }

        //BOSS�����񂾂�gameclear
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
            Debug.Log($"���̍s�����s���ꂽ�B{damage}");
            _currentHP -= damage;
            //_currentHP = Mathf.Clamp(_currentHP - damage, 0, _maxHP);
            _hpBar.fillAmount = _currentHP / _maxHP;
        }
        else if (_super == true && gameObject.tag == "Player")
        {
            
        }
    }
}