using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button : MonoBehaviour
{
    private Animator anim;
    public bool buttonPushed = false;
    public GameObject wall;
    public GameObject pos0;
    public GameObject pos1;
    private Vector3 startPoint;
    private Vector3 endPoint;
    public float speed = 5;

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
            
        else
            wall.transform.position = Vector3.MoveTowards(wall.transform.position, startPoint, Time.deltaTime * 2*speed);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player" || collision.gameObject.tag == "Cow" || collision.gameObject.tag == "Gun" || collision.gameObject.tag == "Box")
        {
            buttonPushed = true;
            /*
            wall.transform.position = Vector3.Lerp(endPoint, startPoint, Time.deltaTime * speed);
            */
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player" || collision.gameObject.tag == "Cow" || collision.gameObject.tag == "Gun" || collision.gameObject.tag == "Box")
        {
            State = States.unpushed;
            buttonPushed = false;
        }
    }
}
