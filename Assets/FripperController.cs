﻿using UnityEngine;
using System.Collections;

public class FripperController : MonoBehaviour
{
    //HingiJointコンポーネントを入れる
    private HingeJoint myHingeJoint;

    //初期の傾き
    private float defaultAngle = 20;
    //弾いた時の傾き
    private float flickAngle = -20;

    //左右に指がタッチされているかの判定フラグ
    private bool lefttouch;
    private bool righttouch;

    // Use this for initialization
    void Start()
    {
        //HingeJointコンポーネント取得
        this.myHingeJoint = GetComponent<HingeJoint>();

        //フリッパーの傾きを設定
        SetAngle(this.defaultAngle);
    }

    // Update is called once per frame
    void Update()
    {

        //左矢印キーを押した時左フリッパーを動かす
        if (Input.GetKeyDown(KeyCode.LeftArrow) && tag == "LeftFripperTag")
        {
            SetAngle(this.flickAngle);
        }
        //右矢印キーを押した時右フリッパーを動かす
        if (Input.GetKeyDown(KeyCode.RightArrow) && tag == "RightFripperTag")
        {
            SetAngle(this.flickAngle);
        }

        //矢印キー離された時フリッパーを元に戻す
        if (Input.GetKeyUp(KeyCode.LeftArrow) && tag == "LeftFripperTag")
        {
            SetAngle(this.defaultAngle);
        }
        if (Input.GetKeyUp(KeyCode.RightArrow) && tag == "RightFripperTag")
        {
            SetAngle(this.defaultAngle);
        }

        lefttouch = false;
        righttouch = false;

        // タッチされていることの判定
        if (Input.touchCount > 0)
        {
            // 複数のタッチを配列に格納
            Touch[] touches = Input.touches;

            // 複数タッチ分繰り返す
            for (int i = 0; i < Input.touchCount; i++)
            {
                // タッチした2次元座標を取得
                Vector2 tauchePos = new Vector2(touches[i].position.x, touches[i].position.y);

                //画面の中心から左を押した時左フリッパーを動かす
                if (touches[i].phase == TouchPhase.Began && tag == "LeftFripperTag" && tauchePos.x <= Screen.width / 2)
                {
                    SetAngle(this.flickAngle);
                }

                //画面の中心から右を押した時右フリッパーを動かす
                if (touches[i].phase == TouchPhase.Began && tag == "RightFripperTag" && tauchePos.x > Screen.width / 2)
                {
                    SetAngle(this.flickAngle);
                }

                //画面の中心から左にタッチされているかの判定
                if (tauchePos.x <= Screen.width / 2)
                {
                    lefttouch = true;
                }

                //画面の中心から右にタッチされているかの判定
                if (tauchePos.x > Screen.width / 2)
                {
                    righttouch = true;
                }
            }
        }
        Debug.Log(tag + "   左" + lefttouch + "   右" + righttouch);
        if (lefttouch == false && tag == "LeftFripperTag")
        {
            SetAngle(this.defaultAngle);
            lefttouch = false;
        }

        if (righttouch == false && tag == "RightFripperTag")
        {
            SetAngle(this.defaultAngle);
            righttouch = false;
        }
    }

    //フリッパーの傾きを設定
    public void SetAngle(float angle)
    {
        JointSpring jointSpr = this.myHingeJoint.spring;
        jointSpr.targetPosition = angle;
        this.myHingeJoint.spring = jointSpr;
    }
}