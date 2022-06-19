using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpecialManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    [SerializeField] ShootManager _bulletS = default;

    [SerializeField] Transform muzzle_S1 = default;
    [SerializeField] Transform muzzle_S2 = default;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButton("Fire2"))
        {
            //special weapon
            var bul2 = Instantiate(_bulletS, muzzle_S1.position, transform.rotation);
            bul2.Direction = Vector3.up;
            bul2.transform.position = muzzle_S1.position;
            
            var bul3 = Instantiate(_bulletS, muzzle_S2.position, transform.rotation);
            bul3.Direction = Vector3.up;
            bul3.transform.position = muzzle_S2.position;
        }

    }
}
