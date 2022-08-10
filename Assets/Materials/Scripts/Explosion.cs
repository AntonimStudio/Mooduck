using UnityEngine;
using System.Collections;

public class Explosion : MonoBehaviour
{
    private bool exploted = false;
    private CircleCollider2D ExplosionCollider;

    private void Start()
    {
        ExplosionCollider = gameObject.GetComponent<CircleCollider2D>();
        exploted = false;
    }

    public void Explode()
    {
        exploted = true;
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (exploted == true)
        {
            if (collision.gameObject.GetComponent<Rigidbody2D>() != null)
            {
                Vector2 target = collision.gameObject.transform.position;
                Vector2 bomb = this.gameObject.transform.position;
                Vector2 direction = 10000f * (target - bomb);
                collision.gameObject.GetComponent<Rigidbody2D>().AddForce(direction);
            }
        }
    }
}
