using UnityEngine;

public class CarController : MonoBehaviour
{
    private float curSpeed = 0;
    private Vector3 startPos;  //마우스 왼쪽 버튼을 클릭한 좌표
    private Vector3 endPos;  //마우스 왼쪽 버튼을 떼었을 때 좌표

    private void Update()
    {
        SetDragPos();
        MoveCar();
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

            SetCarSpeed();
            ExecuteCarSound();
        }
    }

    /// <summary>
    /// 스와이프(드래그) 거리(길이)를 계산
    /// </summary>
    /// <returns></returns>
    private float CalDistance()
    {
        float swipeLength = this.endPos.x - this.startPos.x;
        return swipeLength;
    }

    /// <summary>
    /// car의 속도를 설정
    /// </summary>
    private void SetCarSpeed()
    {
        this.curSpeed = CalDistance() / 5000.0f;
    }

    /// <summary>
    /// car 이동
    /// </summary>
    private void MoveCar()
    {
        this.transform.Translate(this.curSpeed, 0, 0);  //x축으로 이동
        this.curSpeed *= 0.98f;  //감속
    }

    /// <summary>
    /// car 소리 실행
    /// </summary>
    private void ExecuteCarSound()
    {
        gameObject.GetComponent<AudioSource>().Play();
    }
}
