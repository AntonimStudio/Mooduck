using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 Этот код отвечает за передвижение персонажа, как понятно из его названия. Прыжки, ходьба, проверка на землю под ногам - всё здесь.
 */
public class CharacterMovement : MonoBehaviour
{
    public Rigidbody2D rb;
    private BoxCollider2D bc;
    private Animator anim;
    private SpriteRenderer sprite;
    [SerializeField] private float speed;
    [SerializeField] private float airSpeedCoef;  //Переменная отвечающая за дополнительное ускорение в воздухе
    [SerializeField] private float jumpAmount;
    [SerializeField] private float gravityScale;
    [SerializeField] private float fallingGravityScale;
    [SerializeField] private LayerMask platformlayerMask;
    private float extraHeight = 0.07f;
    private Vector3 input;

    [SerializeField] private float maxVelocity;


    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        bc = GetComponent<BoxCollider2D>();
        anim = GetComponent<Animator>();
    }


    private void Update()
    {
        if (rb.velocity.magnitude >= maxVelocity)
        {
            rb.velocity = rb.velocity.normalized * maxVelocity;
        }
        if (IsGrounded()) { State = States.idle; }
        if (Input.GetButton("Horizontal")) Run();
        Jump();
    }

    private enum States
    {
        idle, run, jump, flying
    }

    private States State
    {
        get { return (States)anim.GetInteger("state"); }
        set { anim.SetInteger("state", (int)value); }
    }

    private void Run()
    {
        input = new Vector2(Input.GetAxis("Horizontal"), 0);

        //Разворот персонажа вправо или влево
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
            rb.MovePosition(transform.position + input * Time.deltaTime * speed); //строчка отвечающая за передвижение
            State = States.run;
        }
        else { rb.MovePosition(transform.position + airSpeedCoef * input * Time.deltaTime * speed); } //строчка отвечающая за передвижение в воздухе
        //transform.position += airSpeedCoef * input * speed * Time.deltaTime;    - это старый способ, в котором было несколько багов
    }

    public void Jump()   // Суперский метод для прыжка, который позволяет при падении увеличивать гравитацию
    {
        if (Input.GetKeyDown(KeyCode.Space) && IsGrounded())
        {
            rb.AddForce(Vector2.up * jumpAmount, ForceMode2D.Impulse);   //Собственно, сам прыжок
            State = States.jump;
        }
        if (rb.velocity.y >= 0)
        {
            rb.gravityScale = gravityScale; //Стандартная гравитация
        }
        else if (rb.velocity.y < 0)
        {
            rb.gravityScale = fallingGravityScale;   //Меняем гравитацию при падении
        }
    }


    public bool IsGrounded()   //Проверка на землю под ногами с помощью BoxCast. 
    {
        RaycastHit2D raycastHit = Physics2D.BoxCast(bc.bounds.center, bc.bounds.size, 0f, Vector2.down, extraHeight, platformlayerMask);
        return raycastHit.collider != null;
    }
}
