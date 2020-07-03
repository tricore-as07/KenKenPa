using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 当たりのオブジェクトがいくつあるか把握する
/// </summary>
public class HitObjectsCounter : MonoBehaviour
{
    
    int hitObjectsNum;

    bool rightHit;
    bool centerHit;
    bool leftHit;

    // Start is called before the first frame update
    void Start()
    {
        CountHitObjectsNum();
    }

    /// <summary>
    /// 当たりのオブジェクトがいくつあるか数える
    /// </summary>
    void CountHitObjectsNum()
    {
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
    /// 当たりを全て選んだか
    /// </summary>
    /// <returns>Yes : true , No , false</returns>
    public bool IsAllHit()
    {
        return (hitObjectsNum == 0);
    }

}
