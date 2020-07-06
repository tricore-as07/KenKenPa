using UnityEngine;

/// <summary>
/// 当たりのオブジェクトがいくつあるか把握する
/// </summary>
public class HitObjectsCounter : MonoBehaviour
{
    int hitObjectsNum;      //当たりのオブジェクトの数
    /// <summary>
    /// 当たりのオブジェクトが二つの時などに同じ場所を2回押しても成功になるのを防ぐためのものです。
    /// </summary>
    bool rightHit;          //右が当たりの時に右に対応する入力をした際にtrueになる
    bool centerHit;         //中央が当たりの時に中央に対応する入力をした際にtrueになる
    bool leftHit;           //左が当たりの時に左に対応する入力をした際にtrueになる

    /// <summary>
    /// 最初に行う処理
    /// </summary>
    void Start()
    {
        CountHitObjectsNum();
    }

    /// <summary>
    /// 当たりのオブジェクトがいくつあるか数える
    /// </summary>
    void CountHitObjectsNum()
    {
        //当たりのオブジェクトの数をリセット
        hitObjectsNum = 0;
        if (transform.GetChild(StageConstants.rightNum).tag == "HitObject")
        {
            hitObjectsNum++;
        }
        if (transform.GetChild(StageConstants.centerNum).tag == "HitObject")
        {
            hitObjectsNum++;
        }
        if (transform.GetChild(StageConstants.leftNum).tag == "HitObject")
        {
            hitObjectsNum++;
        }
        rightHit = false;
        centerHit = false;
        leftHit = false;
    }

    /// <summary>
    /// 右が当たりで選んだ時に呼ばれる
    /// </summary>
    public void RightHit()
    {
        if(rightHit)
        {
            return;
        }
        rightHit = true;
        hitObjectsNum--;
    }

    /// <summary>
    /// 中央が当たりで選んだ時に呼ばれる
    /// </summary>
    public void CenterHit()
    {
        if (centerHit)
        {
            return;
        }
        centerHit = true;
        hitObjectsNum--;
    }

    /// <summary>
    /// 左が当たりで選んだ時に呼ばれる
    /// </summary>
    public void LeftHit()
    {
        if (leftHit)
        {
            return;
        }
        leftHit = true;
        hitObjectsNum--;
    }

    /// <summary>
    /// 間違ったものを選んだ時に呼ばれる
    /// </summary>
    public void MissSelected()
    {
        CountHitObjectsNum();
    }

    /// <summary>
    /// 当たりを全て選んだか
    /// </summary>
    /// <returns>Yes : true , No , false</returns>
    public bool IsAllHit()
    {
        return (hitObjectsNum == 0);
    }

}
