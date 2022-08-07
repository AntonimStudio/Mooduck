/*
using UnityEngine;
using System.Collections;

public class Explosion : MonoBehaviour
{
    public float ExplosionDelay = 0f;
    public float ExplosionRate = 0.1f;
    public float ExplosionRadius = 2f;
    public float ExplosionSpeed = 1f;
    public float CurrentRadius = 0f;
    public bool Exploted = false;
    CircleCollider2D ExplosionCollider;

    public CharacterController Character;
    public Rigidbody2D ShotRB;//Физическое тело персонажа

    // Use this for initialization
    void Start()
    {
        ShotRB = GetComponent<Rigidbody2D>();
        var ObjectCharacter = GameObject.Find("Character");
        Character = ObjectCharacter.GetComponent<CharacterController>();

        ExplosionCollider = gameObject.GetComponent<CircleCollider2D>();
        Exploted = true;
    }

    void FixedUpdate()
    {
        if (Exploted == true)
        {
            if (CurrentRadius < ExplosionRadius)
            {
                CurrentRadius += ExplosionRate;
            }
            else
            {
                Destroy(gameObject);
            }
            ExplosionCollider.radius = CurrentRadius;
        }
    }

    void OnTriggerEnter2D(Collision2D col)
    {
        if (Exploted == true)
        {
            if (col.gameObject.GetComponent<Rigidbody2D>() != null)
            {
                Vector2 target = col.gameObject.transform.position;
                Vector2 bomb = this.gameObject.transform.position;
                Vector2 direction = 10000f * (target - bomb);
                col.gameObject.GetComponent<Rigidbody2D>().AddForce(direction);
            }
        }
    }
}
*/