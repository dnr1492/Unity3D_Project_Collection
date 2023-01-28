using UnityEngine;

public class ArrowController : MonoBehaviour
{
    private PlayerController player;
    private GameDirector gameDirector;

    private float radius = 0.5f;  //ȭ���� �浹 ����
    private int arrowScroe = 10;  //ȭ���� ���� ��� ȹ���� ����

    private void Start()
    {
        this.player = GameObject.FindObjectOfType<PlayerController>();
        this.gameDirector = GameObject.FindObjectOfType<GameDirector>();
    }

    private void Update()
    {
        //�� �����Ӹ��� ������� ���� (-y���̹Ƿ� �Ʒ���)
        transform.Translate(0, -0.01f, 0);
        //transform.Translate(0, 0.01f, 0);  //�� �����Ӹ��� ������� ��� (+y���̹Ƿ� ����)

        //ȭ���� ȭ�� ������ ������
        if (transform.position.y < -3.99f)
        {
            //�ش� ��ũ��Ʈ�� ȭ�쿡 �����Ƿ� ���⼭ gameObject�� ȭ���� �ǹ�
            Destroy(gameObject);

            if (!this.gameDirector.isGameOver) this.gameDirector.IncreaseScore(this.arrowScroe); 
        }

        //�浹 ����
        Vector3 arrowPos = this.transform.position;  //ȭ���� ��ġ
        Vector3 playerPos = this.player.transform.position;  //�÷��̾��� ��ġ
        Vector2 direction = playerPos - arrowPos;  //ȭ�쿡�� �÷��̾���� ����
        float distance = direction.magnitude;  //ȭ��� �÷��̾� ���� �Ÿ�(����) ver.1
        //float distance = Vector3.Distance(playerPos, arrowPos);  //ȭ��� �÷��̾� ���� �Ÿ�(����) ver.2
        //float distance = (playerPos - arrowPos).magnitude;  //ȭ��� �÷��̾� ���� �Ÿ�(����) ver.3
        if (distance < this.radius + this.player.radius)
        {
            this.player.hp -= 1;
            this.gameDirector.UpdateHpGauge(this.player.hp, this.player.maxHp);

            Destroy(gameObject);
        }

        Debug.DrawLine(arrowPos, playerPos, Color.red);
    }
  
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, this.radius);
    }
}
