using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Barrel : MonoBehaviour, BulletDestroyer
{
    [SerializeField] private ParticleSystem particles;
    [SerializeField] private Explosion boom;

    public void TakeBullet(Bullet bullet)
    {
        Destroy(bullet.gameObject);
        StartCoroutine(Exploding(0f));
    }

    public IEnumerator Exploding(float time)
    {
        yield return new WaitForSeconds(time);
        Destroy(Instantiate(particles, transform.position, Quaternion.identity), particles.duration + particles.startLifetime);
        Destroy(gameObject);
        Destroy(Instantiate(boom, transform.position, Quaternion.identity), boom.LifeTime);
    }
}
