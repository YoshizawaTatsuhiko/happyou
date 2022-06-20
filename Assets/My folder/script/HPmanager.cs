using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class HPmanager : MonoBehaviour
{

    [SerializeField] private Image _hpBar;
    [SerializeField] private float _maxHP;
    [SerializeField] Image _scene;

    public Collider2D col1;
    public Collider2D col2;

    // Start is called before the first frame update

    private float _currentHP;
    void Start()
    {
        _currentHP = _maxHP;
    }

    // Update is called once per frame
    void Update()
    {
        if(_currentHP <= 0)
        {
            _scene.gameObject.SetActive(true);
            col1.enabled = false;
            col2.enabled = false;
            Destroy(gameObject);
        }
    }

    public void UpdateHP(float damage)
    {
        _currentHP = Mathf.Clamp(_currentHP - damage, 0, _maxHP);
        _hpBar.fillAmount = _currentHP / _maxHP;
    }
}