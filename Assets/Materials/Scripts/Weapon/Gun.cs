using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    [SerializeField] private Transform holdPoint;
    [SerializeField] private GameObject mooduck;
    [SerializeField] private GameObject gun;
    [SerializeField] private GameObject muzzle;
    [SerializeField] private float throwForce = 15f;
    private CharacterMovement characterMovement;
    private Rigidbody2D rigibodyOfGun;
    private PolygonCollider2D colliderOfGun;
    private GunAnimation gunAnimation;
    private Transform gunTransform;
    public int direction;
    public bool equip = false;
    private bool up = false;

    private void Start()
    {
        gun.GetComponent<GunAnimation>().State = GunAnimation.States.idle;
        rigibodyOfGun = gun.GetComponent<Rigidbody2D>();
        colliderOfGun = gun.GetComponent<PolygonCollider2D>();
        gunAnimation = gun.GetComponent<GunAnimation>();
        characterMovement = mooduck.GetComponent<CharacterMovement>();
        gunTransform = gun.GetComponent<Transform>();
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (Input.GetKeyDown(KeyCode.F) && collision.gameObject.tag == "Player") 
        {
            equip = true;
            gun.transform.rotation = new Quaternion(0f, 0f, 0f, 0f);
            gunAnimation.State = GunAnimation.States.equiped;
            rigibodyOfGun.gravityScale = 0f;
        }
    }

    private void Update()
    {
        if (Input.GetAxis("Horizontal") < 0)  {direction = -1;}
        if (Input.GetAxis("Horizontal") > 0)  {direction = 1;}

        if (equip) 
        {
            PickUp();
            if (Input.GetKeyUp(KeyCode.F)) { up = true;  }
            if (Input.GetKeyDown(KeyCode.F) && up) { Throw();}
        }
    }

    private void PickUp()
    {
        characterMovement.ChangeAnim();
        rigibodyOfGun.freezeRotation = true;
        colliderOfGun.transform.position = new Vector3(holdPoint.position.x, holdPoint.position.y, -3f);
        colliderOfGun.enabled = false;
        if (direction == -1){gunTransform.localRotation = Quaternion.Euler(0, 180, 0);}
        if (direction == 1) {gunTransform.localRotation = Quaternion.Euler(0, 0, 0);}
    }

    private void Throw()
    {
        equip = false;
        up = false;
        rigibodyOfGun.gravityScale = 6f;
        characterMovement.ChangeAnimBack();
        colliderOfGun.enabled = true;
        rigibodyOfGun.freezeRotation = false;
        if (rigibodyOfGun != null && direction == 1)
        {
            rigibodyOfGun.velocity = new Vector2(transform.localScale.x * direction, 1) * throwForce;
            gunTransform.localRotation = Quaternion.Euler(0, 0, 0);
        }
        else if (rigibodyOfGun != null && direction == -1)
        {
            rigibodyOfGun.velocity = new Vector2(transform.localScale.x * direction, 1) * throwForce;
            gunTransform.localRotation = Quaternion.Euler(0, 180, 0);
        }
        gunAnimation.State = GunAnimation.States.idle;
    }
}
