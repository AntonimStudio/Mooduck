using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour
{
    [SerializeField] public Transform shop;
    [SerializeField] public CameraController cc;

    private void Start()
    {
        cc = GetComponent<CameraController>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        cc.Zoom(shop);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        cc.ZoomOut();
    }
}
