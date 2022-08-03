using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    [SerializeField] public Transform holdPoint;
    [SerializeField] public Transform mooduck;
    [SerializeField] public GameObject gun;
    [SerializeField] private float throwForce = 15f; 
    private Vector3 pos;
    private int direction;
    private bool equip = false;
    private bool up = false;

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (Input.GetKeyDown(KeyCode.E) && collision.gameObject.tag == "Player") 
        {
            equip = true;
            gun.gameObject.transform.rotation = new Quaternion(0f, 0f, 0f, 0f);
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
    }

    private void Update()
    {
        if (Input.GetAxis("Horizontal") < 0)    {direction = -1;}
        if (Input.GetAxis("Horizontal") > 0)    {direction = 1; }

        if (equip) 
        {

            gun.gameObject.GetComponent<Rigidbody2D>().freezeRotation = true;
            gun.GetComponent<PolygonCollider2D>().gameObject.transform.position = new Vector3(holdPoint.position.x, holdPoint.position.y, -3f);

            if (direction == -1)
            {
                gun.gameObject.transform.localRotation = Quaternion.Euler(0, 180, 0);
            }
            if (direction == 1)
            {
                gun.gameObject.transform.localRotation = Quaternion.Euler(0, 0, 0);
            }

            if (holdPoint.position.x >= mooduck.position.x && equip == true)
            {
                gun.gameObject.transform.localScale = new Vector2(gun.gameObject.transform.localScale.x * 1, gun.gameObject.transform.localScale.y * 1);
            }
            if (holdPoint.position.x < transform.position.x && equip == true)
            {
                gun.gameObject.transform.localScale = new Vector2(gun.gameObject.transform.localScale.x * 1, gun.gameObject.transform.localScale.y * 1);
            }

            if (Input.GetKeyUp(KeyCode.E)) { up = true;  }

            if (Input.GetKeyDown(KeyCode.E) && up)
            {
                equip = false;
                up = false;
                gun.gameObject.GetComponent<Rigidbody2D>().freezeRotation = false;
                if (gun.gameObject.GetComponent<Rigidbody2D>() != null && direction == 1)
                {
                    gun.gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(transform.localScale.x * direction, 1) * throwForce;
                    gun.gameObject.transform.localRotation = Quaternion.Euler(0, 0, 0);
                }
                else if (gun.gameObject.GetComponent<Rigidbody2D>() != null && direction == -1)
                {
                    gun.gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(transform.localScale.x * direction, 1) * throwForce;
                    gun.gameObject.transform.localRotation = Quaternion.Euler(0, 180, 0);
                }
            }
        }

    }
}
