using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int hp = 3;
    public int maxHp;
    private CharacterMovement characteMovement;
    private CapsuleCollider2D playerCollider;
    [SerializeField] private GameObject loseButton;
    [SerializeField] private GameObject UI;
    [SerializeField] private GameObject AlsoUI;
    private bool godMode = false;

    private void Start()
    {
        hp = maxHp;
        characteMovement = GetComponent<CharacterMovement>();
        playerCollider = GetComponent<CapsuleCollider2D>();
    }

    public void TakeDamage(int damage, int pushForce, float timeOfInvincibility, Vector2 direction)
    {
         
        if (!godMode)
        {
            hp -= damage;
            characteMovement.rb.AddForce(direction * pushForce, ForceMode2D.Impulse);  //������������ ������

            godMode = true;
            Invoke("OffGodMode", timeOfInvincibility);   //���������� �����, ��� ������ ������ ���������� �� �����-�� �����
        }
        if (hp <= 0)
        {
            playerCollider.enabled = false;
            Invoke("Lose", 2);            //��������� ������ ���������
            Invoke("Exterminate", 4);     //����������� ������� ������
        }
    }

    public void SetHealth(int bonusHp)
    {
        hp += bonusHp;
        if (hp > maxHp){ hp = maxHp; }
    }

    private void OffGodMode()
    {
        godMode = false;
    }

    private void Lose()
    {
        loseButton.SetActive(true);
        UI.SetActive(false);
        AlsoUI.SetActive(false);
        Time.timeScale = 0f;
    }

    private void Exterminate()
    {
        Destroy(gameObject);
    }
}
