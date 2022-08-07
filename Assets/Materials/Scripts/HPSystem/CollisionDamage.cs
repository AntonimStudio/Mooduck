using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/*
  Класс для получение урона, ничего необычного
 */ 
public class CollisionDamage : MonoBehaviour
{
    [SerializeField] private int damage;
    [SerializeField] private int pushForce;
    [SerializeField] private float timeOfInvincibility;

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<Mooduck>())
        {
            PlayerHealth hp = collision.gameObject.GetComponent<PlayerHealth>();
            hp.TakeDamage(damage, pushForce, timeOfInvincibility, Vector2.up);
        }
    }
}
