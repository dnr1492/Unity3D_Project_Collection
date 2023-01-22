using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShurikenController : MonoBehaviour
{
    private float curSpeed = 0;  //속도
    private float rotSpeed = 0;  //회전 속도
    private Vector2 startPos;  //마우스 왼쪽 버튼을 클릭한 좌표
    private Vector2 endPos;  //마우스 왼쪽 버튼을 떼었을 때 좌표

    void Update()
    {
        SetDragPos();
        Move();
        Rotation();
    }

    /// <summary>
    /// 스와이프(드래그) 위치를 설정
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
    /// 스와이프(드래그) 거리(길이)를 계산
    /// </summary>
    /// <returns></returns>
    private float CalDistance()
    {
        float swipeLength = this.endPos.y - this.startPos.y;
        return swipeLength;
    }

    /// <summary>
    /// 이동 속도를 설정
    /// </summary>
    private void SetMoveSpeed()
    {
        this.curSpeed = CalDistance() / 5000.0f;
    }

    /// <summary>
    /// 회전 속도를 설정
    /// </summary>
    private void SetRotSpeed()
    {
        this.rotSpeed = 10;
    }

    /// <summary>
    /// 이동
    /// </summary>
    private void Move()
    {
        transform.Translate(0, this.curSpeed, 0, Space.World);  //월드 기준 y축으로 이동
        this.curSpeed *= 0.98f;  //감속
    }

    /// <summary>
    /// 회전
    /// </summary>
    private void Rotation()
    {
        transform.Rotate(0, 0, this.rotSpeed);  //z축으로 회전
        this.rotSpeed *= 0.96f;  //감속
    }
}
