using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/*
 * Класс, который не работает вообще. Он СОВСЕМ не подает признаков жизни, ни ошибок, и , собственно, никаких действий
 * Идея в том, чтобы игрок мог поднимать оружие
 */
public class WeaponHold : MonoBehaviour
{
    public bool hold;
    public float distance = 2f;
    private RaycastHit2D hit;
    public Transform holdPoint;
    public float throwForce = 5f;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (!hold)
            {
                Debug.Log("Попытка");
                Physics2D.queriesStartInColliders = false;

                hit = Physics2D.Raycast(transform.position, Vector2.right * transform.localScale.x, distance);

                if (hit.collider != null && hit.collider.tag == "Box")
                {
                    Debug.Log("1");
                    hold = true;
                }
            }
            else
            {
                Debug.Log("12");
                hold = false;
                if (hit.collider.gameObject.GetComponent<Rigidbody2D>() != null)
                {

                    hit.collider.gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(transform.localScale.x, 1) * throwForce;
                }
            }
        }

        if (hold)
        {

            hit.collider.gameObject.transform.position = holdPoint.position;

            if (holdPoint.position.x > transform.position.x && hold == true)
            {
                hit.collider.gameObject.transform.localScale = new Vector2(transform.localScale.x * 1, transform.localScale.y * 1);
            }
            if (holdPoint.position.x < transform.position.x && hold == true)
            {
                hit.collider.gameObject.transform.localScale = new Vector2(transform.localScale.x * 1, transform.localScale.y * 1);
            }
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawLine(transform.position, transform.position + Vector3.right * transform.localScale.x * distance);
    }
}