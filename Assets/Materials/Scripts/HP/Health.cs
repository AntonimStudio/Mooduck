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

    public void TakeDamage(int damage, int pushForce)
    {
        if (!godMode && gameObject.tag == "Player")
        {
            hp -= damage;
            godMode = true;
            Invoke("OffGodMode", 0.5f);
            cm.rb.AddForce(Vector2.up * pushForce, ForceMode2D.Impulse);

        }
        else if (gameObject.tag == "Cow"  || gameObject.tag == "Bullet")
        {
            hp -= damage;
        }

        if (hp <= 0)
        {
            Destroy(gameObject);   //ÑÆÅ×Ü ÏÐÈ ÏÅÐÂÎÉ ÆÅ ÂÎÇÌÎÆÍÎÑÒÈ!!!!!!!!!!!!!!!!!!!!!!!!!!
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
