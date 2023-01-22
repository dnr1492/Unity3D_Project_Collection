using UnityEngine;
using UnityEngine.UI;

public class GameDirector : MonoBehaviour
{
    private GameObject car, flag;
    [SerializeField] Text txtDistance;

    private void Awake()
    {
        this.car = GameObject.Find("car");
        this.flag = GameObject.Find("flag");
    }

    private void Update()
    {
        DisplayDistance();
    }

    /// <summary>
    /// car���� flag������ ���� �Ÿ��� ���
    /// </summary>
    /// <returns></returns>
    private float CalDistance()
    {
        float distance = this.flag.transform.position.x - this.car.transform.position.x;
        return distance;
    }

    /// <summary>
    /// car���� flag������ ���� �Ÿ��� ǥ��
    /// </summary>
    private void DisplayDistance()
    {
        //flag(���)������ ���� �Ÿ��� 0 �̻��̸�
        if (CalDistance() >= 0) this.txtDistance.text = "��ǥ �������� " + CalDistance().ToString("F2") + "m";
        //flag(���)������ ���� �Ÿ��� 0 �̸��̸�
        else
        {
            this.txtDistance.text = "���� ����";
            this.car.GetComponent<AudioSource>().clip = null;
        }
    }
}
