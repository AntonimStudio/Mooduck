using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/*
 ������ �� ��������, �� ���� ��� ������ ���� ������ �� ������� ������ ������ �� �������, ���� ����� ������ � ��� �������.
*/
public class Shop : MonoBehaviour
{
    [SerializeField] public Transform shop;
    public CameraController cc;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        cc.Zoom(transform); //���������� � ���������� ������, ���������� ��������, ���� ����� ������ � ��� �������
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        cc.ZoomOut(); //���������, ���� ����� �������
    }
}
