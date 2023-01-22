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
    /// car에서 flag까지의 남은 거리를 계산
    /// </summary>
    /// <returns></returns>
    private float CalDistance()
    {
        float distance = this.flag.transform.position.x - this.car.transform.position.x;
        return distance;
    }

    /// <summary>
    /// car에서 flag까지의 남은 거리를 표시
    /// </summary>
    private void DisplayDistance()
    {
        //flag(깃발)까지의 남은 거리가 0 이상이면
        if (CalDistance() >= 0) this.txtDistance.text = "목표 지점까지 " + CalDistance().ToString("F2") + "m";
        //flag(깃발)까지의 남은 거리가 0 미만이면
        else
        {
            this.txtDistance.text = "게임 오버";
            this.car.GetComponent<AudioSource>().clip = null;
        }
    }
}
