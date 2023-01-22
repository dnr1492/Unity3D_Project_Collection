using UnityEngine;

public class CarController : MonoBehaviour
{
    private float curSpeed = 0;
    private Vector3 startPos;  //���콺 ���� ��ư�� Ŭ���� ��ǥ
    private Vector3 endPos;  //���콺 ���� ��ư�� ������ �� ��ǥ

    private void Update()
    {
        SetDragPos();
        MoveCar();
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

            SetCarSpeed();
            ExecuteCarSound();
        }
    }

    /// <summary>
    /// ��������(�巡��) �Ÿ�(����)�� ���
    /// </summary>
    /// <returns></returns>
    private float CalDistance()
    {
        float swipeLength = this.endPos.x - this.startPos.x;
        return swipeLength;
    }

    /// <summary>
    /// car�� �ӵ��� ����
    /// </summary>
    private void SetCarSpeed()
    {
        this.curSpeed = CalDistance() / 5000.0f;
    }

    /// <summary>
    /// car �̵�
    /// </summary>
    private void MoveCar()
    {
        this.transform.Translate(this.curSpeed, 0, 0);  //x������ �̵�
        this.curSpeed *= 0.98f;  //����
    }

    /// <summary>
    /// car �Ҹ� ����
    /// </summary>
    private void ExecuteCarSound()
    {
        gameObject.GetComponent<AudioSource>().Play();
    }
}
