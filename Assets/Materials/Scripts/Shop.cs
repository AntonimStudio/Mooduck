using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/*
 ������ �� ��������, �� ���� ��� ������ ���� ������ �� ������� ������ ������ �� �������, ���� ����� ������ � ��� �������.
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
        cc.GetComponent<CameraController>().Zoom(shop.transform); //���������� � ���������� ������, ���������� ��������, ���� ����� ������ � ��� �������
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        cc = GetComponent<CameraController>();
        cc.GetComponent<CameraController>().ZoomOut(); //���������, ���� ����� �������
    }
}
