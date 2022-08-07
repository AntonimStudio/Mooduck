using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Camera))]

public class CameraController : MonoBehaviour
{
    [SerializeField] private Transform player;
    [SerializeField] private float speed;
    [SerializeField] private float zoomSpeed;
    private Camera mainCamera;
    private float defaultSize = 5;
    private float zoomSize = 3;
    private Vector3 pos;
    private Vector3 areaPos;
    private bool zoom = false;

    private void Start()
    {
        if (!player) player = FindObjectOfType<CharacterMovement>().transform;   //Находим игрока
        mainCamera = Camera.main;
    }

    private void Update()
    {
        if (!zoom)
        {
            pos = player.position;
            pos.z = -10f;
            if (pos.y < 0) { pos.y = 0f; }
            mainCamera.orthographicSize = Mathf.Lerp(mainCamera.orthographicSize, defaultSize, zoomSpeed * Time.deltaTime);
            transform.position = Vector3.Lerp(transform.position, pos, speed * Time.deltaTime);
        }
        else
        {
            transform.position = Vector3.Lerp(transform.position, areaPos, speed * Time.deltaTime);
            mainCamera.orthographicSize = Mathf.Lerp(mainCamera.orthographicSize, zoomSize, zoomSpeed * Time.deltaTime);
        }
    }

    public void Zoom(Transform area)
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
