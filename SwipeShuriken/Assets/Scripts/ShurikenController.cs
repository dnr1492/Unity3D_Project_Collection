using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShurikenController : MonoBehaviour
{
    private float curSpeed = 0;  //�ӵ�
    private float rotSpeed = 0;  //ȸ�� �ӵ�
    private Vector2 startPos;  //���콺 ���� ��ư�� Ŭ���� ��ǥ
    private Vector2 endPos;  //���콺 ���� ��ư�� ������ �� ��ǥ

    void Update()
    {
        SetDragPos();
        Move();
        Rotation();
    }

    /// <summary>
    /// ��������(�巡��) ��ġ�� ����
    /// </summary>
    private void SetDragPos()
    {
        if (Input.GetMouseButtonDown(0)) this.startPos = Input.mousePosition;
        else if (Input.GetMouseButtonUp(0))
        {
            this.endPos = Input.mousePosition;

            SetMoveSpeed();
            SetRotSpeed();
        }
    }

    /// <summary>
    /// ��������(�巡��) �Ÿ�(����)�� ���
    /// </summary>
    /// <returns></returns>
    private float CalDistance()
    {
        float swipeLength = this.endPos.y - this.startPos.y;
        return swipeLength;
    }

    /// <summary>
    /// �̵� �ӵ��� ����
    /// </summary>
    private void SetMoveSpeed()
    {
        this.curSpeed = CalDistance() / 5000.0f;
    }

    /// <summary>
    /// ȸ�� �ӵ��� ����
    /// </summary>
    private void SetRotSpeed()
    {
        this.rotSpeed = 10;
    }

    /// <summary>
    /// �̵�
    /// </summary>
    private void Move()
    {
        transform.Translate(0, this.curSpeed, 0, Space.World);  //���� ���� y������ �̵�
        this.curSpeed *= 0.98f;  //����
    }

    /// <summary>
    /// ȸ��
    /// </summary>
    private void Rotation()
    {
        transform.Rotate(0, 0, this.rotSpeed);  //z������ ȸ��
        this.rotSpeed *= 0.96f;  //����
    }
}
