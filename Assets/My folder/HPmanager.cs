using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class HPmanager : MonoBehaviour
{

    [SerializeField] private Image _hpBar;
    [SerializeField] private float _maxHP;

    // Start is called before the first frame update

    private float _currentHP;
    void Start()
    {
        _currentHP = _maxHP;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UpdateHP(float damage)
    {
        _currentHP = Mathf.Clamp(_currentHP - damage, 0, _maxHP);
        _hpBar.fillAmount = _currentHP / _maxHP;
    }
}
