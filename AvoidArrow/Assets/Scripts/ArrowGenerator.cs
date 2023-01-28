using UnityEngine;

public class ArrowGenerator : MonoBehaviour
{
    [SerializeField] GameObject arrowPrefab;
    [SerializeField] GameDirector gameDirector;

    private float spanTime = 1;  //스폰 시간
    private float curTime = 0;  //현재 시간

    private void Update()
    {
        if(this.gameDirector.isGameOver) return;

        //매 프레임마다 현재 시간을 누적
        this.curTime += Time.deltaTime;

        //만약 현재 시간이 1초이상이라면
        if (this.curTime >= this.spanTime)
        {
            this.curTime = 0;
            GameObject go = Instantiate<GameObject>(this.arrowPrefab);  //프리팹 인스턴스화. 즉, 프리팹을 동적으로 생성
            float px = Random.Range(-8.7f, 8.7f);  //-8.7 ~ 7.7
            go.transform.position = new Vector3(px, 4.44f, 0);
        }
    }
}
