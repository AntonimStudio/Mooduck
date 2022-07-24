using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private Transform player;
    private Vector3 pos;

    private void Start()
    {
        if (!player) player = FindObjectOfType<CharacterMovement>().transform;
    }

    private void Update()
    {
        pos = player.position;
        pos.z = -10f;

        if (pos.y >= 0)
        {
            transform.position = Vector3.Lerp(transform.position, pos, Time.deltaTime);
        }
        else
        {
            pos.y = 0f;
            transform.position = Vector3.Lerp(transform.position, pos, Time.deltaTime);
        }
    }

}
