using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainManager : MonoBehaviour
{
    [SerializeField] float C_interval = 1f;
    [SerializeField] float n;

    // Start is called before the first frame update
    void Start()
    {
        n = C_interval;
    }

    [SerializeField] ShootManager _bulletC = default;
    [SerializeField] Transform muzzle_C = default;

    // Update is called once per frame
    void Update()
    {
        MainShooter();
    }

     void MainShooter()
    {
        if (Input.GetButton("Fire1"))
        {
            //’e‚Ì”­ŽËŠÔŠu
            if (n > C_interval)
            {
                n = 0;

                //main weapon
                var bul1 = Instantiate(_bulletC, muzzle_C.position, this.transform.rotation);
                bul1.Direction = Vector3.up;
                bul1.transform.position = muzzle_C.position;
            }
        }
    }
}
