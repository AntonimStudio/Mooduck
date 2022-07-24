using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    public BoxCollider2D bc;
    private CharacterMovement cm;
    [SerializeField] public int hp;
    [SerializeField] public int maxHp;
    private bool godMode = false;


    private void Start()
    {
        hp = maxHp;
        cm = GetComponent<CharacterMovement>();
        bc = GetComponent<BoxCollider2D>();
    }

    public void TakeDamage(int damage)
    {
        if (!godMode && gameObject.tag == "Player")
        {
            hp -= damage;
            godMode = true;
            Invoke("OffGodMode", 1f);
            cm.Jump();

        }
        else if (gameObject.tag == "Cow"  || gameObject.tag == "Bullet")
        {
            hp -= damage;
        }

        if (hp <= 0)
        {
            Destroy(gameObject);   //����� ��� ������ �� �����������!!!!!!!!!!!!!!!!!!!!!!!!!!
        }
    }

    public void SetHealth(int bonusHp)
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
}
