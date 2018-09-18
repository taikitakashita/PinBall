using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class TotalScoreCounter : MonoBehaviour {


    // 合計スコアの初期化
    private int totalscore = 0;

    //合計を表示するテキスト
    private GameObject totalscoreText;

    // Use this for initialization
    void Start ()
    {
        //シーン中のTotalScoreオブジェクトを取得
        this.totalscoreText = GameObject.Find("TotalScoreText");

        //TotalScoreの初期表示
        this.totalscoreText.GetComponent<Text>().text = "TotalScore：" + this.totalscore.ToString();
    }
	
	// Update is called once per frame
	void Update ()
    {

    }

    //衝突時に呼ばれる関数
    void OnCollisionEnter(Collision other)
    {
        // 合計スコアにターゲットごとに取得できるスコアを加点
        if (other.gameObject.CompareTag("SmallStarTag"))
        {
            this.totalscore += 10;
            // TotalScoreTextの表示を更新
            this.totalscoreText.GetComponent<Text>().text = "TotalScore：" + this.totalscore;
        }
        else if (other.gameObject.CompareTag("LargeStarTag") || other.gameObject.CompareTag("SmallCloudTag"))
        {
            this.totalscore += 20;
            // TotalScoreTextの表示を更新
            this.totalscoreText.GetComponent<Text>().text = "TotalScore：" + this.totalscore;
        }
        else if (other.gameObject.CompareTag("LargeCloudTag"))
        {
            this.totalscore += 50;
            // TotalScoreTextの表示を更新
            this.totalscoreText.GetComponent<Text>().text = "TotalScore：" + this.totalscore;
        }
    }
}
