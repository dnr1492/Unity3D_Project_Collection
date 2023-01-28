using UnityEngine;
using UnityEngine.UI;

public class GameDirector : MonoBehaviour
{
    [SerializeField] Text txtHp, txtTime, txtScore;
    [SerializeField] GameObject hpGauge, gameOverGo;
    [SerializeField] RectTransform mainRt;
    private float playTime;
    private float delta;
    private int totalScore;
    public bool isGameOver;

    void Start()
    {
        this.txtScore.text = string.Format("{0}��", this.totalScore);

        PlayerController player = GameObject.FindObjectOfType<PlayerController>();
        this.txtHp.text = string.Format("{0}/{1}", player.hp, player.maxHp);
    }

    void Update()
    {
        if (this.isGameOver) return;

        this.delta += Time.deltaTime;
        if (this.delta > 1)
        {
            this.delta = 0;
            this.playTime += 1;
            this.txtTime.text = string.Format("{0}�� ", (int)this.playTime);
        }
    }

    /// <summary>
    /// ���� ����
    /// </summary>
    /// <param name="score"></param>
    public void IncreaseScore(int score)
    {
        this.totalScore += score;
        this.txtScore.text = string.Format("{0}��", this.totalScore);
    }

    /// <summary>
    /// ���� ����
    /// </summary>
    private void GameOver()
    {
        Instantiate<GameObject>(this.gameOverGo, this.mainRt);
        this.isGameOver = true;
        Debug.Log("GAME OVER");
    }

    /// <summary>
    /// HP �������� ������Ʈ
    /// </summary>
    /// <param name="hp"></param>
    /// <param name="maxHp"></param>
    public void UpdateHpGauge(float hp, float maxHp)
    {
        this.txtHp.text = string.Format("{0}/{1}", hp, maxHp);
        var per = hp / maxHp;
        this.hpGauge.GetComponent<Image>().fillAmount = per;
        if (per <= 0)
        {
            if (this.isGameOver == false) this.GameOver();
        }
    }
}
