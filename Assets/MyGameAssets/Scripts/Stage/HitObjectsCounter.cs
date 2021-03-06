﻿using UnityEngine;

/// <summary>
/// 当たりのオブジェクトがいくつあるか把握する
/// </summary>
public class HitObjectsCounter : MonoBehaviour
{
    int hitObjectsNum;                                              //当たりのオブジェクトの数
    public bool isRightHit { get; private set; }                    //右が当たりかどうか
    public bool isCenterHit { get; private set; }                   //中央が当たりかどうか
    public bool isLeftHit { get; private set; }                     //左があたりかどうか

    /// <summary>
    /// 当たりのオブジェクトが二つの時などに同じ場所を2回押しても成功になるのを防ぐためのものです。
    /// </summary>
    bool isRightCorrect;                                            //右が当たりの時に右に対応する入力をした際にtrueになる
    bool isCenterCorrect;                                           //中央が当たりの時に中央に対応する入力をした際にtrueになる
    bool isLeftCorrect;                                             //左が当たりの時に左に対応する入力をした際にtrueになる
    [SerializeField] Transform rightObjectTransform = default;      //右のオブジェクトのTransform
    [SerializeField] Transform centerObjectTransform = default;     //中央のオブジェクトのTransform
    [SerializeField] Transform leftObjectTransform = default;       //左のオブジェクトのTransform
    static PlayerEffectCreater playerEffectCreater = null;

    /// <summary>
    /// 最初に行う処理
    /// </summary>
    void Start()
    {
        if(playerEffectCreater == null)
        {
            playerEffectCreater = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerEffectCreater>();
        }
        CountHitObjectsNum();
    }

    /// <summary>
    /// 当たりのオブジェクトがいくつあるか数える
    /// </summary>
    void CountHitObjectsNum()
    {
        isRightHit = rightObjectTransform.GetChild(0).tag == "HitObject";
        isCenterHit = centerObjectTransform.GetChild(0).tag == "HitObject";
        isLeftHit = leftObjectTransform.GetChild(0).tag == "HitObject";
        //当たりのオブジェクトの数をリセット
        hitObjectsNum = 0;
        if (isRightHit)
        {
            hitObjectsNum++;
        }
        if (isCenterHit)
        {
            hitObjectsNum++;
        }
        if (isLeftHit)
        {
            hitObjectsNum++;
        }
        isRightCorrect = false;
        isCenterCorrect = false;
        isLeftCorrect = false;
    }

    /// <summary>
    /// 右が当たりで選んだ時に呼ばれる
    /// </summary>
    public void OnCorrectSelectRight()
    {
        //右が当たりで2回目押された時は何の処理もしないで早期リターン
        if(isRightCorrect)
        {
            return;
        }
        isRightCorrect = true;
        hitObjectsNum--;
        playerEffectCreater.CreateCorrectEffect(StageConstants.rightNum);
    }

    /// <summary>
    /// 中央が当たりで選んだ時に呼ばれる
    /// </summary>
    public void OnCorrectSelectCenter()
    {
        //中央が当たりで2回目押された時は何の処理もしないで早期リターン
        if (isCenterCorrect)
        {
            return;
        }
        isCenterCorrect = true;
        hitObjectsNum--;
        playerEffectCreater.CreateCorrectEffect(StageConstants.centerNum);
    }

    /// <summary>
    /// 左が当たりで選んだ時に呼ばれる
    /// </summary>
    public void OnCorrectSelectLeft()
    {
        //左が当たりで2回目押された時は何の処理もしないで早期リターン
        if (isLeftCorrect)
        {
            return;
        }
        isLeftCorrect = true;
        hitObjectsNum--;
        playerEffectCreater.CreateCorrectEffect(StageConstants.leftNum);
    }

    /// <summary>
    /// 間違ったものを選んだ時に呼ばれる
    /// </summary>
    /// <param name="selectNum">選んだ場所の要素数</param>
    public void OnMistakeSelect(int selectNum)
    {
        CountHitObjectsNum();
    }

    /// <summary>
    /// 当たりを全て選んだか
    /// </summary>
    /// <returns>Yes : true , No , false</returns>
    public bool IsAllCorrectSelect()
    {
        return (hitObjectsNum == 0);
    }

}
