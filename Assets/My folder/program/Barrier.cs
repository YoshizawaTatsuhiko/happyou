using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Barrier : Special
{
    [SerializeField] GameObject _barrier = default;
    [SerializeField] float _barrierTime = 1f;
    Animator _anim;

    void Start()
    {
        _anim = GetComponent<Animator>();
    }

    public override void SpecialWeapon()
    {
        StartCoroutine("DifenceTime");
    }

    IEnumerator DifenceTime()
    {
        _barrier.SetActive(true);
        yield return new WaitForSeconds(_barrierTime);
        _barrier.SetActive(false);
    }
}
