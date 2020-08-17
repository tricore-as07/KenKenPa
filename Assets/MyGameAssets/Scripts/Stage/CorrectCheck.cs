using UnityEngine;

/// <summary>
/// 入力された場所が当たりか外れかの判定
/// </summary>
public class CorrectCheck : MonoBehaviour
{
    int checkNum = 0;                       //判定するオブジェクトの番号（要素数）
    HitObjectsCounter hitObjectsCounter;    //当たりがいくつありか確認するためのクラス
    bool changedCheckObject;                //判定するオブジェクトを変更したかどうか

    /// <summary>
    /// 入力された場所が当たりか外れかの判定が非アクティブになった時
    /// </summary>
    public void OnDisableCorrentCheck()
    {
        //入力可能かどうかで見た目を変える機能を無効にする
        hitObjectsCounter.transform.GetChild(StageConstants.rightNum).GetComponent<InputtableIsByObjectLookChange>().OnDisableCorrentCheck();
        hitObjectsCounter.transform.GetChild(StageConstants.centerNum).GetComponent<InputtableIsByObjectLookChange>().OnDisableCorrentCheck();
        hitObjectsCounter.transform.GetChild(StageConstants.leftNum).GetComponent<InputtableIsByObjectLookChange>().OnDisableCorrentCheck();
    }

    /// <summary>
    /// 判定をするオブジェクトのデータを更新する
    /// </summary>
    void CheckObjectUpdate()
    {
        //判定するオブジェクトの要素数が子オブジェクトに登録されている数より少なければ
        if(transform.childCount > checkNum)
        {
            //判定につかうスクリプトの更新
            hitObjectsCounter = transform.GetChild(checkNum).GetComponent<HitObjectsCounter>();
            //入力可能かどうかで見た目を変える機能を有効にする
            hitObjectsCounter.transform.GetChild(StageConstants.rightNum).GetComponent<InputtableIsByObjectLookChange>().OnEnableCorrentCheck();
            hitObjectsCounter.transform.GetChild(StageConstants.centerNum).GetComponent<InputtableIsByObjectLookChange>().OnEnableCorrentCheck();
            hitObjectsCounter.transform.GetChild(StageConstants.leftNum).GetComponent<InputtableIsByObjectLookChange>().OnEnableCorrentCheck();
        }
    }

    /// <summary>
    /// 当たりを全て選んだときにやる処理
    /// </summary>
    void OnAllCorrectProcess()
    {
        //入力可能かどうかで見た目を変える機能を無効にする
        hitObjectsCounter.transform.GetChild(StageConstants.rightNum).GetComponent<InputtableIsByObjectLookChange>().OnDisableCorrentCheck();
        hitObjectsCounter.transform.GetChild(StageConstants.centerNum).GetComponent<InputtableIsByObjectLookChange>().OnDisableCorrentCheck();
        hitObjectsCounter.transform.GetChild(StageConstants.leftNum).GetComponent<InputtableIsByObjectLookChange>().OnDisableCorrentCheck();
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
        if(hitObjectsCounter.isRightHit)
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
        if (hitObjectsCounter.isCenterHit)
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
        if (hitObjectsCounter.isLeftHit)
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

    /// <summary>
    /// アタッチされているオブジェクトグループのチェックが必要なくなった(全てクリアした)時に呼ぶ
    /// </summary>
    public void OnNecessaryCorrectCheck()
    {
        Destroy(gameObject);
    }

    /// <summary>
    /// 現在のオブジェクトグループの判定が有効になった時
    /// </summary>
    public void OnEnableCorrentCheck()
    {
        hitObjectsCounter = transform.GetChild(checkNum).GetComponent<HitObjectsCounter>();
        //入力可能かどうかで見た目を変える機能を有効にする
        hitObjectsCounter.transform.GetChild(StageConstants.rightNum).GetComponent<InputtableIsByObjectLookChange>().OnEnableCorrentCheck();
        hitObjectsCounter.transform.GetChild(StageConstants.centerNum).GetComponent<InputtableIsByObjectLookChange>().OnEnableCorrentCheck();
        hitObjectsCounter.transform.GetChild(StageConstants.leftNum).GetComponent<InputtableIsByObjectLookChange>().OnEnableCorrentCheck();
    }
}
