using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private ParticleSystem particles;
    private Rigidbody2D rb;
    private int direction;
    
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = transform.right * speed * direction;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out BulletDestroyer destroyer))
        {
            Destroy(Instantiate(particles, transform.position, Quaternion.identity), particles.duration + particles.startLifetime);
            destroyer.TakeBullet(this); 
        }
    }

    public void Init(int direction)
    {
        this.direction = direction;
    }
}
