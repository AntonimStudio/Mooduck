using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CowCollisionDamage : MonoBehaviour
{
    [SerializeField] private int damage;
    [SerializeField] private string collisionTag;
    [SerializeField] public int pushForce;

    private void OnTriggerStay2D(Collider2D collision)
    {
        Health hp = collision.gameObject.GetComponent<Health>();
        hp.TakeDamage(damage, pushForce);
    }
}
