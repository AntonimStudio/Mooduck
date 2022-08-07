using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cow : MonoBehaviour
{
    private Animator anim;
    public float speed;
    public int kolvo;
    public GameObject[] gameObjects;
    public Vector3[] points;
    private int now = 0;
    [SerializeField] private bool rotate = true;

    void Start()
    {
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
        State = States.run;
        if (transform.position.x == points[now].x) 
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

}