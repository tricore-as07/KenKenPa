using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 入力された場所が当たりか外れかの判定
/// </summary>
public class HitCheck : MonoBehaviour
{
    int checkNum = 0;
    GameObject rightObject;
    GameObject centerObject;
    GameObject leftObject;
    HitObjectsCounter hitObjectsCounter;
    bool changedCheckObject;

    // Start is called before the first frame update
    void Start()
    {
        CheckObjectUpdate();
    }

    /// <summary>
    /// 判定をするオブジェクトのデータを更新する
    /// </summary>
    void CheckObjectUpdate()
    {
        if(transform.childCount > checkNum)
        {
            rightObject = transform.GetChild(checkNum).GetChild(StageConstants.rightNum).gameObject;
            centerObject = transform.GetChild(checkNum).GetChild(StageConstants.centerNum).gameObject;
            leftObject = transform.GetChild(checkNum).GetChild(StageConstants.leftNum).gameObject;
            hitObjectsCounter = transform.GetChild(checkNum).GetComponent<HitObjectsCounter>();
        }
    }

    /// <summary>
    /// 当たりを全て選んだときにやる処理
    /// </summary>
    void AllHitProcess()
    {
        transform.GetChild(checkNum).gameObject.SetActive(false);
        checkNum++;
        CheckObjectUpdate();
        changedCheckObject = true;
    }

    /// <summary>
    /// 右が当たりかどうか
    /// </summary>
    /// <returns></returns>
    public bool IsRightHit()
    {
        if(rightObject.tag == "HitObject")
        {
            hitObjectsCounter.RightHit();
            if(hitObjectsCounter.IsAllHit())
            {
                AllHitProcess();
            }
            return true;
        }
        return false;
    }

    /// <summary>
    /// 中央が当たりかどうか
    /// </summary>
    /// <returns></returns>
    public bool IsCenterHit()
    {
        if (centerObject.transform.tag == "HitObject")
        {
            hitObjectsCounter.CenterHit();
            if (hitObjectsCounter.IsAllHit())
            {
                AllHitProcess();
            }
            return true;
        }
        return false;
    }

    /// <summary>
    /// 左が当たりかどうか
    /// </summary>
    /// <returns></returns>
    public bool IsLeftHit()
    {
        if (leftObject.tag == "HitObject")
        {
            hitObjectsCounter.LeftHit();
            if (hitObjectsCounter.IsAllHit())
            {
                AllHitProcess();
            }
            return true;
        }
        return false;
    }

    /// <summary>
    /// 判定するオブジェクトグループを次のオブジェクトグループにする必要があるか
    /// </summary>
    /// <returns>必要な時 : true,必要ない時 : false</returns>
    public bool NeedsNextObjectsGroup()
    {
        return (checkNum >= 10);
    }

    /// <summary>
    /// 判定するオブジェクトを変えたかどうか
    /// </summary>
    /// <returns></returns>
    public bool IsChangedCheckObject()
    {
        if(changedCheckObject)
        {
            changedCheckObject = false;
            return true;
        }
        return false;
    }

}
