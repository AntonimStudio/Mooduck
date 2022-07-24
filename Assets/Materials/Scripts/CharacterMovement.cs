using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    private BoxCollider2D bc;
    private Animator anim;
    private SpriteRenderer sprite;
    [SerializeField] private float speed = 5;
    [SerializeField] private float airSpeedCoef = 1.25f;
    [SerializeField] private float jumpAmount = 35;
    [SerializeField] private float gravityScale = 10;
    [SerializeField] private float fallingGravityScale = 40;
    [SerializeField] private LayerMask platformlayerMask;
    private float extraHeight = 0.07f;
    private Vector3 input;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        bc = GetComponent<BoxCollider2D>();
        anim = GetComponent<Animator>();
    }


    private void Update()
    {
        if (IsGrounded()) { State = States.idle; }
        if (Input.GetButton("Horizontal")) Run();
        if (Input.GetKeyDown(KeyCode.Space) && IsGrounded()) Jump();
    }

    private enum States
    {
        idle, run, jump
    }

    private States State
    {
        get { return (States)anim.GetInteger("state"); }
        set { anim.SetInteger("state", (int)value); }
    }

    private void Run()
    {
        input = new Vector2(Input.GetAxis("Horizontal"), 0);

        //flip
        if (Input.GetAxis("Horizontal") < 0)
        {
            transform.localRotation = Quaternion.Euler(0, 180, 0);
        }
        if (Input.GetAxis("Horizontal") > 0)
        {
            transform.localRotation = Quaternion.Euler(0, 0, 0);
        }

        if (IsGrounded())
        {
            transform.position += input * speed * Time.deltaTime;
            State = States.run;
        }
        else { transform.position += airSpeedCoef * input * speed * Time.deltaTime; }
    }

    private void Jump()
    {
        rb.AddForce(Vector2.up * jumpAmount, ForceMode2D.Impulse);
        State = States.jump;

        if (rb.velocity.y >= 0)
        {
            rb.gravityScale = gravityScale;
        }
        else if (rb.velocity.y < 0)
        {
            rb.gravityScale = fallingGravityScale;
        }
    }

    public bool IsGrounded()
    {
        RaycastHit2D raycastHit = Physics2D.BoxCast(bc.bounds.center, bc.bounds.size, 0f, Vector2.down, extraHeight, platformlayerMask);
        return raycastHit.collider != null;
    }
}
