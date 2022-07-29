using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemDropController : MonoBehaviour
{
    /// <summary>ドロップするアイテム</summary>
    [SerializeField] GameObject[] _dropItem;
    /// <summary>   アイテムの生成確率</summary>
    [SerializeField] float _itemDropProbability;
    float _timer;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        var random = Random.Range(0, 1f);

        if(random < _itemDropProbability)
        {

        }
    }
}
