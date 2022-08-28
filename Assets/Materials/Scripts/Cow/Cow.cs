using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cow : MonoBehaviour, BulletDestroyer
{
    private Animator anim;
    private Rigidbody2D rb;
    private BoxCollider2D bc;
    [SerializeField] private BoxCollider2D damageBoxCollider;
    [SerializeField] private int pushForce;
    [SerializeField] private float speed;
    [SerializeField] private int kolvo;
    [SerializeField] private float jumpDistance;
    [SerializeField] private GameObject[] gameObjects;
    [SerializeField] private Vector3[] points;
    private int now = 0;
    private bool rotate = true;
    private bool death = false;

    void Start()
    {
        bc = GetComponent<BoxCollider2D>();
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        for (int i = 0; i < kolvo; i++)
        {
            points[i] = new Vector3(gameObjects[i].transform.position.x, gameObjects[i].transform.position.y, gameObjects[i].transform.position.z);
        }

    }

    void FixedUpdate()
    {
        if (now == kolvo) { now = 0; }
        transform.position = new Vector3(Mathf.MoveTowards(transform.position.x, points[now].x, speed * Time.deltaTime), transform.position.y, transform.position.z);
        if (!death) State = States.run;
        else State = States.death;
        if (transform.position.x == points[now].x && !death) 
        { 
            now++;
            if (rotate)
            {
                transform.localRotation = Quaternion.Euler(0, 0, 0);
                rotate = false;
            }
            else
            {
                transform.localRotation = Quaternion.Euler(0, 180, 0);
                rotate = true;
            }
        }
        /*
        RaycastHit2D raycastHit = Physics2D.Raycast(transform.position, transform.right * (rotate ? 1 : -1), jumpDistance); 
        if (raycastHit)
        {
            Debug.Log("Jump");
            Debug.DrawRay(transform.position, transform.right * (rotate ? 1 : -1), Color.green , jumpDistance);
        }
        RaycastHit2D raycastHit = Physics2D.BoxCast(bc.bounds.center, bc.bounds.size, 0f, transform.right * (rotate ? 1 : -1), jumpDistance);
        if (raycastHit)
        {
            Debug.Log("Jump");
            Debug.DrawRay(transform.position, transform.right * (rotate ? 1 : -1), Color.green, jumpDistance);
        }
        */
    }

    private States State
    {
        get { return (States)anim.GetInteger("state"); }
        set { anim.SetInteger("state", (int)value); }
    }

    private enum States
    {
        idle, run, death
    }

    public void TakeBullet(Bullet bullet)
    {
        Destroy(bullet.gameObject);
        rb.AddForce(Vector2.up * pushForce, ForceMode2D.Impulse);
        death = true;
        bc.enabled = false;
        damageBoxCollider.enabled = false;
    }

}