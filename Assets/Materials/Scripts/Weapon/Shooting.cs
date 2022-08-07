using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    [SerializeField] private Transform muzzle;
    [SerializeField] private Bullet bullet;
    [SerializeField] private Gun gun;
    [SerializeField] private float reloadTime = 0.5f;
    private bool reload = true;
    private bool pressing = false;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && gun.equip) pressing = true;
        else if (Input.GetKeyUp(KeyCode.E) && gun.equip) pressing = false;

        if (pressing && reload)
        {
            Shoot();
            reload = false;
            Invoke("OffReload", reloadTime);
        }
    }

    private void Shoot()
    {
        Instantiate(bullet, muzzle.position, Quaternion.identity).Init(gun.direction);
    }

    private void OffReload()
    {
        reload = true;
    }
}
