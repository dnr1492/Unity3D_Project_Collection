using UnityEngine;

public class RouletteController : MonoBehaviour
{
    private enum Dir { Left = 1, Right = -1 }
    private Dir eDir;  //ȸ�� ����

    private float curRotSpeed = 0;  //���� ȸ�� �ӵ�
    private int setRotSpeed = 2;   //ȸ�� �ӵ�
    private float setAtten = 0.99f;  //����(����) ���

    private void Update()
    {
        SetRot();
        StartRot();
    }

    /// <summary>
    /// ���� ���콺�� Ŭ���ϸ� ȸ�� ����� ȸ�� �ӵ��� ����
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
    /// ȸ�� ����
    /// </summary>
    private void StartRot()
    {
        this.transform.Rotate(0, 0, this.curRotSpeed);
        this.curRotSpeed *= setAtten;  //ȸ�� ����
    }
}
