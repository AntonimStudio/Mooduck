using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pushroom : MonoBehaviour, BulletDestroyer
{
    [SerializeField] private int num = 1; //�� ����� ����� ������� �����������, � ������� ���� ��������� ������
    [SerializeField] private float pushForce = 18f;
    private Rigidbody2D rb;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        rb = collision.gameObject.GetComponent<Rigidbody2D>();
        if (collision.gameObject.GetComponent<Mooduck>() && num == 1)
        {
            rb.AddForce(Vector2.up * pushForce, ForceMode2D.Impulse); //������������ �����
        } 
        else if (collision.gameObject.GetComponent<Mooduck>() && num == 2)
        {
            rb.AddForce(Vector2.right * pushForce, ForceMode2D.Impulse); //������������ ������
        }
        else if (collision.gameObject.GetComponent<Mooduck>() && num == 3)
        {
            rb.AddForce(Vector2.left * pushForce, ForceMode2D.Impulse); //������������ �����
        }
    }

    public void TakeBullet(Bullet bullet)
    {
        Destroy(bullet.gameObject);
    }
}
