using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/*
  Класс для получение урона, конкретно для коров
 */
public class CowCollisionDamage : MonoBehaviour
{
    [SerializeField] private int damage;
    [SerializeField] private string collisionTag;
    [SerializeField] public int pushForce;
    [SerializeField] public float timeOfInvincibility;

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Health hp = collision.gameObject.GetComponent<Health>();
            hp.TakeDamage(damage, pushForce, timeOfInvincibility);
        }
    }

}
