using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Instanciate : MonoBehaviour
{
    [SerializeField] GameObject _prefab;
    [SerializeField, Range(0, 10)] float _n;
    // Start is called before the first frame update
    void Start()
    {
        Instantiate();
    }

    public void Instantiate()
    {
        Instantiate(_prefab, transform.position, transform.rotation);
    }

    public void Destroy()
    {
        Destroy(_prefab, _n);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
