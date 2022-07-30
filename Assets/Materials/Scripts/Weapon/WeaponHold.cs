using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/*
 * Класс, который не работает вообще. Он СОВСЕМ не подает признаков жизни, ни ошибок, и , собственно, никаких действий
 * Идея в том, чтобы игрок мог поднимать оружие
 */
public class WeaponHold : MonoBehaviour
{
    public bool equip;
    public float distance = 0.3f;
    public RaycastHit2D hit;
    public Transform holdPoint; //Здесь задаются координаты дочернего объекта у игрока
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
                hit = Physics2D.Raycast(transform.position, Vector2.right * transform.localScale.x, distance); //RayCast ищет впереди объект для того, чтобы его поднять

                if (hit.collider != null && hit.collider.tag == "Gun")// Если объект - это дробовик, то поднимаем
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
            } //Тут должно было быть прописано выкидывание оружия
        }*/

        if (equip)
        {
            hit.collider.gameObject.transform.position = holdPoint.position;  //Здесь мы поднимаем дробовик, перемещая его к дочернему объекту
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red; //Прорисовка RayCast
        Gizmos.DrawLine(transform.position, transform.position + Vector3.right * transform.localScale.x * distance);
    }
}
