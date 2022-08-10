using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Barrel : MonoBehaviour, BulletDestroyer
{
    [SerializeField] private ParticleSystem particles;

    public void TakeBullet(Bullet bullet)
    {
        Destroy(bullet.gameObject);
        Instantiate(particles, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}
