using UnityEngine;

public class ArrowGenerator : MonoBehaviour
{
    [SerializeField] GameObject arrowPrefab;
    [SerializeField] GameDirector gameDirector;

    private float spanTime = 1;  //���� �ð�
    private float curTime = 0;  //���� �ð�

    private void Update()
    {
        if(this.gameDirector.isGameOver) return;

        //�� �����Ӹ��� ���� �ð��� ����
        this.curTime += Time.deltaTime;

        //���� ���� �ð��� 1���̻��̶��
        if (this.curTime >= this.spanTime)
        {
            this.curTime = 0;
            GameObject go = Instantiate<GameObject>(this.arrowPrefab);  //������ �ν��Ͻ�ȭ. ��, �������� �������� ����
            float px = Random.Range(-8.7f, 8.7f);  //-8.7 ~ 7.7
            go.transform.position = new Vector3(px, 4.44f, 0);
        }
    }
}
