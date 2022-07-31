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
        cc = GetComponent<CameraController>();
        if (!shop) shop = FindObjectOfType<Shop>().transform;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        cc.Zoom(shop.transform); //���������� � ���������� ������, ���������� ��������, ���� ����� ������ � ��� �������
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        cc.ZoomOut(); //���������, ���� ����� �������
    }
}
