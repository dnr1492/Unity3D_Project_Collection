using UnityEngine;

public class ArrowController : MonoBehaviour
{
    private PlayerController player;
    private GameDirector gameDirector;

    private float radius = 0.5f;  //화살의 충돌 범위
    private int arrowScroe = 10;  //화살을 피할 경우 획득할 점수

    private void Start()
    {
        this.player = GameObject.FindObjectOfType<PlayerController>();
        this.gameDirector = GameObject.FindObjectOfType<GameDirector>();
    }

    private void Update()
    {
        //매 프레임마다 등속으로 낙하 (-y축이므로 아래로)
        transform.Translate(0, -0.01f, 0);
        //transform.Translate(0, 0.01f, 0);  //매 프레임마다 등속으로 상승 (+y축이므로 위로)

        //화살이 화면 밖으로 나가면
        if (transform.position.y < -3.99f)
        {
            //해당 스크립트가 화살에 있으므로 여기서 gameObject는 화살을 의미
            Destroy(gameObject);

            if (!this.gameDirector.isGameOver) this.gameDirector.IncreaseScore(this.arrowScroe); 
        }

        //충돌 판정
        Vector3 arrowPos = this.transform.position;  //화살의 위치
        Vector3 playerPos = this.player.transform.position;  //플레이어의 위치
        Vector2 direction = playerPos - arrowPos;  //화살에서 플레이어로의 방향
        float distance = direction.magnitude;  //화살과 플레이어 간의 거리(길이) ver.1
        //float distance = Vector3.Distance(playerPos, arrowPos);  //화살과 플레이어 간의 거리(길이) ver.2
        //float distance = (playerPos - arrowPos).magnitude;  //화살과 플레이어 간의 거리(길이) ver.3
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
