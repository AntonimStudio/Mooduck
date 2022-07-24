using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionDamage : MonoBehaviour
{
    [SerializeField] private int damage;
    [SerializeField] private string collisionTag;

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.tag == collisionTag)
        {
            Health hp = collision.gameObject.GetComponent<Health>();
            hp.TakeDamage(damage);
        }
    }
}
