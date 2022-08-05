using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/*
 Вообще не работает, но этот код должен меня объект за которым следит камера на магазин, если игрок входит в его область.
*/
public class Shop : MonoBehaviour
{
    public CameraController cc;
    public Camera MainCamera;
    

    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<Mooduck>()) cc.Zoom(transform); //Отправляем в Контроллер Камеры, координаты магазина, если игрок входит в его область
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.GetComponent<Mooduck>()) cc.ZoomOut(); //Отключаем, если игрок выходит
    }
}
