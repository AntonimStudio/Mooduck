using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    [SerializeField] public Transform holdPoint;
    [SerializeField] public GameObject mooduck;
    [SerializeField] public GameObject gun;
    [SerializeField] public GameObject muzzle;
    [SerializeField] private float throwForce = 15f; 
    private int direction;
    public bool equip = false;
    private bool up = false;

    private void Start()
    {
        gun.GetComponent<GunAnimation>().State = GunAnimation.States.idle;
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (Input.GetKeyDown(KeyCode.F) && collision.gameObject.tag == "Player") 
        {
            equip = true;
            gun.gameObject.transform.rotation = new Quaternion(0f, 0f, 0f, 0f);
            gun.GetComponent<GunAnimation>().State = GunAnimation.States.equiped;
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
            mooduck.GetComponent<CharacterMovement>().ChangeAnim();
            gun.gameObject.GetComponent<Rigidbody2D>().freezeRotation = true;
            gun.GetComponent<PolygonCollider2D>().gameObject.transform.position = new Vector3(holdPoint.position.x, holdPoint.position.y, -3f);
            gun.gameObject.GetComponent<PolygonCollider2D>().enabled = false;
            if (direction == -1)
            {
                gun.gameObject.transform.localRotation = Quaternion.Euler(0, 180, 0);
                muzzle.gameObject.transform.Rotate (0, 180, 0);
            }
            if (direction == 1)
            {
                gun.gameObject.transform.localRotation = Quaternion.Euler(0, 0, 0);
                muzzle.gameObject.transform.Rotate(0, 0, 0);
            }

            if (holdPoint.position.x >= mooduck.transform.position.x && equip == true)
            {
                gun.gameObject.transform.localScale = new Vector2(gun.gameObject.transform.localScale.x * 1, gun.gameObject.transform.localScale.y * 1);
            }
            if (holdPoint.position.x < mooduck.transform.position.x && equip == true)
            {
                gun.gameObject.transform.localScale = new Vector2(gun.gameObject.transform.localScale.x * 1, gun.gameObject.transform.localScale.y * 1);
            }

            if (Input.GetKeyUp(KeyCode.F)) { up = true;  }

            if (Input.GetKeyDown(KeyCode.F) && up)
            {
                equip = false;
                up = false;
                mooduck.GetComponent<CharacterMovement>().ChangeAnimBack();
                gun.gameObject.GetComponent<PolygonCollider2D>().enabled = true;
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
                gun.GetComponent<GunAnimation>().State = GunAnimation.States.idle;
            }
        }

    }
}
