using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionHeal : MonoBehaviour
{
    [SerializeField] private int heal;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<Mooduck>())
        {
            PlayerHealth hp = collision.gameObject.GetComponent<PlayerHealth>();

            if (hp.hp != hp.maxHp)
            {
                hp.SetHealth(heal);
                Destroy(gameObject);
            }
        }
    }
}
