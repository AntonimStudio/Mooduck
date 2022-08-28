using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowingGrenades : MonoBehaviour
{
    [SerializeField] private Transform muzzle;
    [SerializeField] private CharacterMovement characterMovement;
    [SerializeField] private Grenade grenade;
    [SerializeField] private float reloadTime = 0.5f;
    private bool reload = true;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q) && reload)
        {
            Throw();
            reload = false;
            StartCoroutine(OffReloading());
        }
    }

    private void Throw()
    {
        Instantiate(grenade, muzzle.position, Quaternion.identity).Init(characterMovement);
    }

    private IEnumerator OffReloading()
    {
        yield return new WaitForSeconds(reloadTime);
        reload = true;
    }
}
