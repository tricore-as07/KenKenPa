using UnityEngine;

/// <summary>
/// 入力された場所が当たりか外れかの判定
/// </summary>
public class CorrectCheck : MonoBehaviour
{
    int checkNum = 0;                       //判定するオブジェクトの番号（要素数）
    GameObject rightObject;                 //右側のオブジェクト
    GameObject centerObject;                //中央のオブジェクト
    GameObject leftObject;                  //左側のオブジェクト
    HitObjectsCounter hitObjectsCounter;    //当たりがいくつありか確認するためのクラス
    bool changedCheckObject;                //判定するオブジェクトを変更したかどうか

    /// <summary>
    /// 最初に行う処理
    /// </summary>
    void Start()
    {
        CheckObjectUpdate();
    }

    /// <summary>
    /// 判定をするオブジェクトのデータを更新する
    /// </summary>
    void CheckObjectUpdate()
    {
        //判定するオブジェクトの要素数が子オブジェクトに登録されている数より少なければ
        if(transform.childCount > checkNum)
        {
            //判定するオブジェクトの更新
            rightObject = transform.GetChild(checkNum).GetChild(StageConstants.rightNum).GetChild(0).gameObject;
            centerObject = transform.GetChild(checkNum).GetChild(StageConstants.centerNum).GetChild(0).gameObject;
            leftObject = transform.GetChild(checkNum).GetChild(StageConstants.leftNum).GetChild(0).gameObject;
            hitObjectsCounter = transform.GetChild(checkNum).GetComponent<HitObjectsCounter>();
        }
    }

    /// <summary>
    /// 当たりを全て選んだときにやる処理
    /// </summary>
    void OnAllCorrectProcess()
    {
        //判定が終わったオブジェクトを非アクティブにする
        transform.GetChild(checkNum).gameObject.SetActive(false);
        //判定するオブジェクトを次のオブジェクトにする
        checkNum++;
        changedCheckObject = true;
        CheckObjectUpdate();
    }

    /// <summary>
    /// 右が当たりかどうか
    /// </summary>
    /// <returns>当たり : true , 外れ : false</returns>
    public bool IsRightHit()
    {
        if(rightObject.tag == "HitObject")
        {
            hitObjectsCounter.OnCorrectSelectRight();
            if(hitObjectsCounter.IsAllCorrectSelect())
            {
                OnAllCorrectProcess();
            }
            return true;
        }
        hitObjectsCounter.OnMistakeSelect();
        return false;
    }

    /// <summary>
    /// 中央が当たりかどうか
    /// </summary>
    /// <returns>当たり : true , 外れ : false</returns>
    public bool IsCenterHit()
    {
        if (centerObject.transform.tag == "HitObject")
        {
            hitObjectsCounter.OnCorrectSelectCenter();
            if (hitObjectsCounter.IsAllCorrectSelect())
            {
                OnAllCorrectProcess();
            }
            return true;
        }
        hitObjectsCounter.OnMistakeSelect();
        return false;
    }

    /// <summary>
    /// 左が当たりかどうか
    /// </summary>
    /// <returns>当たり : true , 外れ : false</returns>
    public bool IsLeftHit()
    {
        if (leftObject.tag == "HitObject")
        {
            hitObjectsCounter.OnCorrectSelectLeft();
            if (hitObjectsCounter.IsAllCorrectSelect())
            {
                OnAllCorrectProcess();
            }
            return true;
        }
        hitObjectsCounter.OnMistakeSelect();
        return false;
    }

    /// <summary>
    /// 判定するオブジェクトグループを次のオブジェクトグループにする必要があるか
    /// </summary>
    /// <returns>必要な時 : true,必要ない時 : false</returns>
    public bool NeedsNextObjectsGroup()
    {
        //子オブジェクトの数より判定するオブジェクトの要素数以上なら
        return (checkNum >= transform.childCount);
    }

    /// <summary>
    /// 判定するオブジェクトを変えたかどうか
    /// </summary>
    /// <returns>変えてた時 : true , 変えてない時 : false</returns>
    public bool IsChangedCheckObject()
    {
        if(changedCheckObject)
        {
            //変更履歴をリセット
            changedCheckObject = false;
            return true;
        }
        return false;
    }
}
