using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
public class Generator : MonoBehaviour
{
    /// <summary>ÉAÉCÉeÉÄÇÃê∂ê¨</summary>
    [SerializeField] GameObject[] _item;
    [SerializeField] float _interval;
    BoxCollider2D _bc;
    float _time;

    void Start()
    {
        _bc = GetComponent<BoxCollider2D>();
    }

    void Update()
    {
        _time += Time.deltaTime;

        float RandomX = Random.Range((-_bc.size.x) / 2, (_bc.size.x) / 2);
        float RandomY = Random.Range((-_bc.size.y) / 2, (_bc.size.y) / 2);
        int n = Random.Range(0, _item.Length+1);
        if (_time >= _interval)
        {
            GameObject _Item = Instantiate(_item[n]);
            _Item.transform.position = new Vector2(RandomX + transform.position.x, RandomY + transform.position.y);
            _time = 0;
        }
    }
}