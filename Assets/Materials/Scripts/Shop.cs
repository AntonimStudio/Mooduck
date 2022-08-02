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
        cc.Zoom(transform); //Отправляем в Контроллер Камеры, координаты магазина, если игрок входит в его область
        //MainCamera.transform.position = Vector3.Lerp(MainCamera.transform.position, transform.position, 2 * Time.deltaTime);
        MainCamera.orthographicSize = 3f;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        MainCamera.orthographicSize = 5f;
        cc.ZoomOut(); //Отключаем, если игрок выходит
    }
}
