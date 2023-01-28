using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private GameDirector gameDirector;

    public float radius = 1.0f;  //�÷��̾��� �ݰ�(������), �������� �����Ͽ� �浹 ������ ���� ����
    public float maxHp = 10;
    public float hp;

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, this.radius);
    }

    private void Start()
    {
        this.gameDirector = GameObject.FindObjectOfType<GameDirector>();
        this.hp = this.maxHp;
    }

    private void Update()
    {
        if (this.gameDirector.isGameOver) return;

        //Ű���� ���� ȭ��ǥ�� ������
        if (Input.GetKeyDown(KeyCode.LeftArrow)) this.transform.Translate(-3, 0, 0);  //x�� �������� 3 �����δ�

        //Ű���� ������ ȭ��ǥ�� ������
        if (Input.GetKeyDown(KeyCode.RightArrow)) this.transform.Translate(3, 0, 0);  //x�� ���������� 3 �����δ�

        //�÷��̾ ȭ�� ������ �� ������ �ϱ�
        //(Viewport ����) ī�޶��� ���� �ϴ��� (0,0 , 0.0) �̸�, ���� ����� (1.0 , 1.0)
        Vector3 pos = Camera.main.WorldToViewportPoint(this.transform.position);
        if (pos.x < 0.05f) pos.x = 0.05f;
        if (pos.x > 0.95f) pos.x = 0.95f;
        //if (pos.y < 0.1f) pos.y = 0.1f;
        //if (pos.y > 0.9f) pos.y = 0.9f;
        this.transform.position = Camera.main.ViewportToWorldPoint(pos);

        //�÷��̾ ȭ�� ������ �� ������ �ϱ� 2
        //if (this.transform.position.x <= -7.82f)
        //{
        //    var pos = this.transform.position;
        //    pos.x = -7.82f;
        //    this.transform.position = pos;
        //}
        //if (this.transform.position.x >= 7.77f)
        //{
        //    var pos = this.transform.position;
        //    pos.x = 7.77f;
        //    this.transform.position = pos;
        //}
    }
}
