using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CowCollisionDamage : MonoBehaviour
{
    [SerializeField] private int damage;
    [SerializeField] private int pushForce;
    [SerializeField] private float timeOfInvincibility;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<Mooduck>())
        {
            PlayerHealth hp = collision.gameObject.GetComponent<PlayerHealth>();
            hp.TakeDamage(damage, pushForce, timeOfInvincibility, Vector2.up);
        }
    }
}
