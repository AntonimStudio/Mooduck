using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/*
    ���, ����������� ������ ������, ������� � ����� ��. � ���� ����� ���������� ������ ������. 
 */
public class Health : MonoBehaviour
{
    private CharacterMovement cm;
    private Rigidbody2D rb;
    [SerializeField] public int hp = 3;
    [SerializeField] public int maxHp;
    public GameObject loseButton;
    public GameObject UI;
    public GameObject AlsoUI;
    private bool godMode = false;



    private void Start()
    {
        hp = maxHp;
        cm = GetComponent<CharacterMovement>();
    }

    public void TakeDamage(int damage, int pushForce, float timeOfInvincibility, Vector2 direction)
    {
         
        if (!godMode && gameObject.tag == "Player")  //��������� ����� ��� ������
        {
            hp -= damage;
            cm.rb.AddForce(direction * pushForce, ForceMode2D.Impulse);  //������������ ������

            godMode = true;
            Invoke("OffGodMode", timeOfInvincibility);   //���������� �����, ��� ������ ������ ���������� �� �����-�� �����

        }
        else if (gameObject.tag == "Cow"  || gameObject.tag == "Bullet")  //���������  ����� ��� ���������, ���� ��� ��� ���������
        {
            hp -= damage;
        }

        if (hp <= 0 && gameObject.tag == "Player")   //������ ������
        {
            gameObject.GetComponent<CapsuleCollider2D>().enabled = false;
            Invoke("YouLoseButton", 2);     //��������� ������ ���������
            Invoke("Extermination", 5);     //����������� ������� ������
        }
        else if (hp <= 0 && gameObject.tag == "Cow")    //������ �����, ���� ��� ��� ���������
        {
            gameObject.GetComponent<BoxCollider2D>().enabled = false;
            Invoke("Extermination", 5);
        }
    }

    public void SetHealth(int bonusHp)    //���������� ��, ��������, ��� �������� �������
    {
        hp += bonusHp;

        if (hp > maxHp)
        {
            hp = maxHp;
        }
    }

    private void OffGodMode()
    {
        godMode = false;
    }

    private void YouLoseButton()
    {
        loseButton.SetActive(true);
        UI.SetActive(false);
        AlsoUI.SetActive(false);
        Time.timeScale = 0f;
    }

    private void Extermination()
    {
        Destroy(gameObject);
    }
}
