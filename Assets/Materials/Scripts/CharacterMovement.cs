using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    public Rigidbody2D rb;
    private CapsuleCollider2D cc;
    private Animator anim;
    [SerializeField] private float speed;
    [SerializeField] private float airSpeedCoef;  //Переменная отвечающая за дополнительное ускорение в воздухе
    [SerializeField] private float jumpAmount;
    [SerializeField] private float gravityScale;
    [SerializeField] private float fallingGravityScale;
    [SerializeField] private float maxVelocity;
    [SerializeField] private LayerMask platformlayerMask;
    private bool equip = false;
    private float extraHeight = 0.07f;
    public int direction;
    private Vector3 input;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        cc = GetComponent<CapsuleCollider2D>();
        anim = GetComponent<Animator>();
    }

    private void Update()
    {
        if (rb.velocity.magnitude >= maxVelocity)
        {
            rb.velocity = rb.velocity.normalized * maxVelocity;
        }

        if (IsGrounded()  && !equip) { State = States.idle; } 
        else if (IsGrounded() && equip) { State = States.idlegun; }

        if (Input.GetButton("Horizontal")) Run();
        Jump();
    }

    private enum States
    {
        idle, run, jump, flying, idlegun, rungun, jumpgun
    }

    private States State
    {
        get { return (States)anim.GetInteger("state"); }
        set { anim.SetInteger("state", (int)value); }
    }

    private void Run()
    {
        input = new Vector2(Input.GetAxis("Horizontal"), 0);

        flip();

        if (IsGrounded())
        {
            rb.MovePosition(transform.position + input * Time.deltaTime * speed); //строчка отвечающая за передвижение
            if (!equip) { State = States.run; }
            else State = States.rungun; 
        }
        else { rb.MovePosition(transform.position + airSpeedCoef * input * Time.deltaTime * speed); } //строчка отвечающая за передвижение в воздухе

        //transform.position += airSpeedCoef * input * speed * Time.deltaTime;    - это старый способ, в котором было несколько багов
    }

    public void Jump() 
    {
        if (Input.GetKeyDown(KeyCode.Space) && IsGrounded())
        {
            rb.AddForce(Vector2.up * jumpAmount, ForceMode2D.Impulse);
            if (!equip) { State = States.jump; }
            else if (equip) { State = States.jumpgun; }
        }
        if (rb.velocity.y >= 0) { rb.gravityScale = gravityScale; }
        else if (rb.velocity.y < 0) { rb.gravityScale = fallingGravityScale; }
    }

    private void flip()
    {
        if (Input.GetAxis("Horizontal") < 0)
        {
            direction = -1;
            transform.localRotation = Quaternion.Euler(0, 180, 0);
        }
        if (Input.GetAxis("Horizontal") > 0)
        {
            direction = 1;
            transform.localRotation = Quaternion.Euler(0, 0, 0);
        }
    }

    public bool IsGrounded()
    {
        RaycastHit2D raycastHit = Physics2D.BoxCast(cc.bounds.center, cc.bounds.size, 0f, Vector2.down, extraHeight, platformlayerMask);
        return raycastHit.collider != null;
    }

    public void ChangeAnim()
    {
        equip = true;
    }

    public void ChangeAnimBack()
    {
        equip = false;
    }
}
