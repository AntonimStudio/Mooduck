using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    [SerializeField] private CharacterMovement characterMovement;
    [SerializeField] private Transform muzzle;
    [SerializeField] private Bullet bullet;
    [SerializeField] private Gun gun;
    [SerializeField] private float repulsiveForce;
    [SerializeField] private float reloadTime = 0.5f;
    private bool reload = true;

    private void Update()
    {
        if (Input.GetKey(KeyCode.E) && reload && gun.equip)
        {
            Shoot();
            reload = false;
            characterMovement.rb.AddForce(transform.right * repulsiveForce * characterMovement.direction);
            StartCoroutine(OffReloading());
        }
    }

    private void Shoot()
    {
        Instantiate(bullet, muzzle.position, Quaternion.identity).Init(characterMovement.direction);
    }

    private IEnumerator OffReloading()
    {
        yield return new WaitForSeconds(reloadTime);
        reload = true;
    }
}
