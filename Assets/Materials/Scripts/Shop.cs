using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/*
 Вообще не работает, но этот код должен меня объект за которым следит камера на магазин, если игрок входит в его область.
*/
public class Shop : MonoBehaviour
{
    [SerializeField] public Transform shop;
    [SerializeField] public CameraController cc;

    private void Start()
    {
        shop = GetComponent<Transform>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        cc = GetComponent<CameraController>();
        cc.GetComponent<CameraController>().Zoom(shop.transform); //Отправляем в Контроллер Камеры, координаты магазина, если игрок входит в его область
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        cc = GetComponent<CameraController>();
        cc.GetComponent<CameraController>().ZoomOut(); //Отключаем, если игрок выходит
    }
}
