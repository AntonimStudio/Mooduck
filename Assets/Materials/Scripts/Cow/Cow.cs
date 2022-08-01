using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cow : MonoBehaviour
{
    private Animator anim;
    private Rigidbody2D rb;
    public float speed;
    public int kolvo;
    public GameObject[] gameObjects;
    public Vector3[] points;
    private int now = 0;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        for (int i = 0; i < kolvo; i++)
        {
            points[i] = new Vector3(gameObjects[i].transform.position.x, gameObjects[i].transform.position.y, gameObjects[i].transform.position.z);
        }

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        rb.AddForce(transform.forward * thrust, ForceMode.VelocityChange);

        if (now == kolvo) { now = 0; }
        gameObject.transform.position = Vector3.MoveTowards(gameObject.transform.position, points[now], Time.deltaTime * speed);
        if (gameObject.transform.position == points[now]) { now++; }
    }
}
