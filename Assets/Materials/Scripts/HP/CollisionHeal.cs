using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionHeal : MonoBehaviour
{
    [SerializeField] private int heal;
    [SerializeField] private string collisionTag = "Player";


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == collisionTag)
        {
            Health hp = collision.gameObject.GetComponent<Health>();

            if (hp.hp != hp.maxHp)
            {
                hp.SetHealth(heal);
                Destroy(gameObject);
            }
        }
    }
}
