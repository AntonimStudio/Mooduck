using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponHold : MonoBehaviour
{
    public bool equip;
    public float distance = 0.3f;
    public RaycastHit2D hit;
    public Transform holdPoint;
    public float put = 1f;

    public void Start()
    {
        
    }


    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            if (!equip)
            {
                Physics2D.queriesStartInColliders = false;
                hit = Physics2D.Raycast(transform.position, Vector2.right * transform.localScale.x, distance);

                if (hit.collider != null && hit.collider.tag == "Gun")
                {
                    equip = true;
                }
            }
        }
        /*else
        {
            equip = false;

            if (hit.collider.gameObject.GetComponent<Rigidbody2D>() != null)
            {
                hit.collider.gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(transform.localScale.x, 1) * put;
            }
        }*/

        if (equip)
        {
            hit.collider.gameObject.transform.position = holdPoint.position;
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawLine(transform.position, transform.position + Vector3.right * transform.localScale.x * distance);
    }
}
