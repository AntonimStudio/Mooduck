using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/*
    Код, позволяющий давать игроку, коровам и пулям хп. К нему часто обращаются другие классы. 
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

    public void TakeDamage(int damage, int pushForce, float timeOfInvincibility)
    {
         
        if (!godMode && gameObject.tag == "Player")  //Получение урона для игрока
        {
            hp -= damage;
            cm.rb.AddForce(Vector2.up * pushForce, ForceMode2D.Impulse);  //Отталкивание игрока

            godMode = true;
            Invoke("OffGodMode", timeOfInvincibility);   //Вызыванием класс, что делает игрока неуязвимым на какое-то время

        }
        else if (gameObject.tag == "Cow"  || gameObject.tag == "Bullet")  //Получение  урона для остальных, пока что код недописан
        {
            hp -= damage;
        }

        if (hp <= 0 && gameObject.tag == "Player")   //Смерть игрока
        {
            gameObject.GetComponent<BoxCollider2D>().enabled = false;
            Invoke("YouLoseButton", 2);     //Появление кнопки проигрыша
            Invoke("Extermination", 5);     //Уничтожение объекта игрока
        }
        else if (hp <= 0 && gameObject.tag == "Cow")    //Смерть коров, пока что код недописан
        {
            gameObject.GetComponent<BoxCollider2D>().enabled = false;
            Invoke("Extermination", 5);
        }
    }

    public void SetHealth(int bonusHp)    //Добавление хп, например, при съедании вишенки
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
    }

    private void Extermination()
    {
        Destroy(gameObject);
    }
}
