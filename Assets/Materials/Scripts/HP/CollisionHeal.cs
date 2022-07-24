using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionHeal : MonoBehaviour
{
    [SerializeField] private int heal;
    [SerializeField] private string collisionTag;

    public void Start()
    {

    }

    private void Update()
    {
        /*
        if (hp.hp != hp.maxHp)
        {
            Physics2D.IgnoreCollision(hp.bc, bc, false);
        }
        else Physics2D.IgnoreCollision(hp.bc, bc, true);
        */
    }

    private void OnCollisionEnter2D(Collision2D collision)
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
