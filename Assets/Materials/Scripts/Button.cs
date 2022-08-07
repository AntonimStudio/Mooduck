using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button : MonoBehaviour
{
    private Animator anim;
    [SerializeField] private float speed = 5;
    [SerializeField] private bool buttonPushed = false;
    [SerializeField] private GameObject wall;
    [SerializeField] private GameObject pos0;
    [SerializeField] private GameObject pos1;
    private Vector3 startPoint;
    private Vector3 endPoint;

    void Start()
    {
        anim = GetComponent<Animator>();
        State = States.unpushed;
        startPoint = new Vector3(pos0.transform.position.x, pos0.transform.position.y, pos0.transform.position.z);
        endPoint = new Vector3(pos1.transform.position.x, pos1.transform.position.y, pos1.transform.position.z);
    }

    private enum States
    {
        unpushed, pushed, worked
    }

    private States State
    {
        get { return (States)anim.GetInteger("state"); }
        set { anim.SetInteger("state", (int)value); }
    }

    private void Update()
    {
        if (buttonPushed)
        {
            wall.transform.position = Vector3.MoveTowards(wall.transform.position, endPoint, Time.deltaTime * speed);
            State = States.pushed;
        }
        else wall.transform.position = Vector3.MoveTowards(wall.transform.position, startPoint, Time.deltaTime * 2 * speed);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<PressureResponse>()) { buttonPushed = true; }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<PressureResponse>())
        {
            State = States.unpushed;
            buttonPushed = false;
        }
    }
}
