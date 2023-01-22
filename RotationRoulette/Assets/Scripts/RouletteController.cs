using UnityEngine;

public class RouletteController : MonoBehaviour
{
    private enum Dir { Left = 1, Right = -1 }
    private Dir eDir;  //회전 방향

    private float curRotSpeed = 0;  //현재 회전 속도
    private int setRotSpeed = 2;   //회전 속도
    private float setAtten = 0.99f;  //감쇠(감속) 계수

    private void Update()
    {
        SetRot();
        StartRot();
    }

    /// <summary>
    /// 왼쪽 마우스를 클릭하면 회전 방향과 회전 속도를 설정
    /// </summary>
    private void SetRot()
    {
        if (Input.GetMouseButtonDown(0))
        {
            int random = Random.Range(-1, 1);  //-1~0
            if (random == -1) this.eDir = Dir.Left;
            else if (random == 0) this.eDir = Dir.Right;

            this.curRotSpeed = this.setRotSpeed * (int)this.eDir;
        }
    }

    /// <summary>
    /// 회전 시작
    /// </summary>
    private void StartRot()
    {
        this.transform.Rotate(0, 0, this.curRotSpeed);
        this.curRotSpeed *= setAtten;  //회전 감속
    }
}
