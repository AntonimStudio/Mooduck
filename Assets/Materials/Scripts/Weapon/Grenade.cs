using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grenade : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float time = 1.5f;
    [SerializeField] private ParticleSystem particles;
    private GameObject mooduck;
    private CharacterMovement characterMovement;
    private Rigidbody2D rb;
    private int direction;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        mooduck = GameObject.Find("Mooduck");
        characterMovement = mooduck.GetComponent<CharacterMovement>();
        rb.velocity = (transform.right * characterMovement.direction + transform.up) * speed;
        Invoke(nameof(Boom), time);
    }

    public void Boom()
    {
        Instantiate(particles, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}
