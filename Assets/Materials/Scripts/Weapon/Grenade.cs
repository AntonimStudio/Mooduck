using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grenade : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float time = 1.5f;
    [SerializeField] private ParticleSystem particles;
    [SerializeField] private Explosion boom;
    private CharacterMovement characterMovement;
    private Rigidbody2D rb;
    private int direction;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = (transform.right * characterMovement.direction + transform.up) * speed;
        StartCoroutine(Booming());
    }

    public void Init(CharacterMovement characterMovement)
    {
        this.characterMovement = characterMovement;
    }

    private IEnumerator Booming()
    {
        yield return new WaitForSeconds(time);
        Destroy(Instantiate(particles, transform.position, Quaternion.identity), particles.duration + particles.startLifetime);
        Destroy(gameObject);
        Destroy(Instantiate(boom, transform.position, Quaternion.identity), boom.LifeTime);
    }
}
