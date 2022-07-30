using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/*
  Класс для получение урона, ничего необычного
 */ 
public class CollisionDamage : MonoBehaviour
{
    [SerializeField] private int damage;
    [SerializeField] private string collisionTag;
    [SerializeField] public int pushForce;
    [SerializeField] public float timeOfInvincibility;

    private void OnCollisionStay2D(Collision2D collision) //Если мы касаемся объекта, то получаем урон
    {
        if (collision.gameObject.tag == collisionTag)
        {
            Health hp = collision.gameObject.GetComponent<Health>();
            hp.TakeDamage(damage, pushForce, timeOfInvincibility); //Отправляем урон, силу отталкивания и вреямы неуязвимости
        }
    }
}
