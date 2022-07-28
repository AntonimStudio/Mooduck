using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pushroom : MonoBehaviour
{
    public int num = 1;
    public float pushForce = 18f;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && num == 1)
        {
            collision.gameObject.GetComponent<Rigidbody2D>().AddForce(Vector2.up * pushForce, ForceMode2D.Impulse);
        } 
        else if (collision.gameObject.CompareTag("Player") && num == 2)
        {
            collision.gameObject.GetComponent<Rigidbody2D>().AddForce(Vector2.right * pushForce, ForceMode2D.Impulse);
        }
        else if (collision.gameObject.CompareTag("Player") && num == 3)
        {
            collision.gameObject.GetComponent<Rigidbody2D>().AddForce(Vector2.left * pushForce, ForceMode2D.Impulse);
        }
    }
}
