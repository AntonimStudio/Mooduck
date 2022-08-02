using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    [SerializeField] public Transform holdPoint;
    [SerializeField] public GameObject gun;
    private Vector3 pos;
    private bool equip = false;

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            equip = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        
    }

    private void Update()
    {
        if (equip) 
        { 
            gun.GetComponent<BoxCollider2D>().gameObject.transform.position = new Vector3(holdPoint.position.x, holdPoint.position.y, -3f);
        }
    }
}
