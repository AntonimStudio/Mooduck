using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/*
    Класс, позволяющий камере следить за игроком, пока что работает плохо
 */

[RequireComponent(typeof(Camera))]

public class CameraController : MonoBehaviour
{
    [SerializeField] private Transform player;
    [SerializeField] private float speed;
    [SerializeField] private float zoomSpeed;
    private Camera camera;
    private float defaultSize = 5;
    private float zoomSize = 3;
    private Vector3 pos;
    private Vector3 areaPos;
    private bool zoom = false;

    private void Start()
    {
        if (!player) player = FindObjectOfType<CharacterMovement>().transform;   //Находим игрока
        camera = Camera.main;
    }

    private void Update()
    {
        if (!zoom)
        {
            pos = player.position;
            pos.z = -10f;
            camera.orthographicSize = Mathf.Lerp(camera.orthographicSize, defaultSize, zoomSpeed * Time.deltaTime);
            if (pos.y >= 0)
            {
               transform.position = Vector3.Lerp(transform.position, pos, speed * Time.deltaTime); //Следим за игроком, если он выше 0 по у.
            }
            else
            {
                pos.y = 0f;
                transform.position = Vector3.Lerp(transform.position, pos, speed * Time.deltaTime);
            }
            
        }
        else
        {
            transform.position = Vector3.Lerp(transform.position, areaPos, speed * Time.deltaTime);
            camera.orthographicSize = Mathf.Lerp(camera.orthographicSize, zoomSize, zoomSpeed * Time.deltaTime);
        }
    }

    public void Zoom(Transform area)  //Это пока что вообще не работает, но идея в том, чтобы камера могла следить за другим объектом
    {
        zoom = true;
        areaPos = area.position;
        areaPos.z = -10f;
    }

    public void ZoomOut()
    {
        zoom = false;
    }
}
