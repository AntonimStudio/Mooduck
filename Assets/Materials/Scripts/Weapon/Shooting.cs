using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{

    public Transform muzzle;
    public GameObject bullet;
    public GameObject gun;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && gun.GetComponent<Gun>().equip)
        {
            Shoot();
        }
    }

    private void Shoot()
    {
        Instantiate(bullet, muzzle.position, Quaternion.identity);
    }
}
