using UnityEngine;
using System.Collections;

public class Explosion : MonoBehaviour
{
    [SerializeField] private float lifeTime = 0.01f;
    [SerializeField] private float force = 700f;
    [SerializeField] private float explodeAnotherBarrelTime = 0.5f;
    public float LifeTime => lifeTime;
    
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Rigidbody2D rb))
        {
            Vector2 target = collision.transform.position;
            Vector2 bomb = transform.position;
            Vector2 direction = force * (target - bomb);
            rb.AddForce(direction);
        }

        if (collision.TryGetComponent(out Barrel barrel))
        {
            barrel.Exploding(1f);
        }
    }
}
