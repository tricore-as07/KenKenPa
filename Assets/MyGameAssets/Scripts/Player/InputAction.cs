using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 入力があった際の動作をするクラス
/// </summary>
public class InputAction : MonoBehaviour
{
    CorrectCheck correctCheck;                                      //入力された場所が当たりか外れかを判定するクラス
    List<GameObject> ObjectsGroupList = new List<GameObject>();     //オブジェクトグループのリスト
    ProgressDistanceCounter progressDistanceCounter;                //進んだ距離をカウントするクラス
    ComboCounter comboCounter;                                      //コンボをカウントするクラス
    InputIntervalManager inputIntervalManager;                      //入力から次の入力を受け付けるまでの時間を管理するクラス

    /// <summary>
    /// 最初に行う処理
    /// </summary>
    void Start()
    {
        //ObjectGroupタグのゲームオブジェクトをリストに追加
        ObjectsGroupList.AddRange(GameObject.FindGameObjectsWithTag("ObjectsGroup"));
        // オブジェクトグループを近い順にソート
        ObjectsGroupList.Sort((a,b) => (int)(
            (Vector3.SqrMagnitude(a.transform.position - transform.position)) -
            (Vector3.SqrMagnitude(b.transform.position - transform.position))
            ) );
        //一番近いオブジェクトグループのHitCheckクラスを代入
        correctCheck = ObjectsGroupList[0].GetComponent<CorrectCheck>();
        
        progressDistanceCounter = GameObject.FindGameObjectWithTag("ProgressDistanceCounter").GetComponent<ProgressDistanceCounter>();
        comboCounter = GameObject.FindGameObjectWithTag("ComboCounter").GetComponent<ComboCounter>();
        inputIntervalManager = GameObject.FindGameObjectWithTag("InputIntervalManager").GetComponent<InputIntervalManager>();
    }

    /// <summary>
    /// 右が入力された時
    /// </summary>
    public void OnRightInput()
    {
        if(inputIntervalManager.isAbleInput)
        {
            if(correctCheck.IsRightHit())
            {
                OnCorrectSelectProcess();
            }
            else
            {
                comboCounter.OnMissCombo();
            }
        }
    }

    /// <summary>
    /// 中央が入力された時
    /// </summary>
    public void OnCenterInput()
    {
        if (inputIntervalManager.isAbleInput)
        {
            if (correctCheck.IsCenterHit())
            {
                OnCorrectSelectProcess();
            }
            else
            {
                comboCounter.OnMissCombo();
            }
        }
    }

    /// <summary>
    /// 左が入力された時
    /// </summary>
    public void OnLeftInput()
    {
        if (inputIntervalManager.isAbleInput)
        {
            if (correctCheck.IsLeftHit())
            {
                OnCorrectSelectProcess();
            }
            else
            {
                comboCounter.OnMissCombo();
            }
        }
    }

    /// <summary>
    /// 当たりを選んだ時の処理
    /// </summary>
    void OnCorrectSelectProcess()
    {
        //判定するオブジェクトが次に進んだかどうか
        if (correctCheck.IsChangedCheckObject())
        {
            OnAllCorrectSelectPlayerAction();
        }
        if (correctCheck.NeedsNextObjectsGroup())
        {
            ObjectsGroupList.RemoveAt(0);
            correctCheck = ObjectsGroupList[0].GetComponent<CorrectCheck>();
        }
    }

    /// <summary>
    /// 当たりを全て選んだ時にプレイヤーがやる処理
    /// </summary>
    /// FIXME orimoto モック版作成時のためマジックナンバー使用（本実装時に修正予定）
    void OnAllCorrectSelectPlayerAction()
    {
        float ObjectDistance = 3f;              //オブジェクトの間の距離（ランダム生成システム作成時にScriptableObjectで設定できるように変更予定）
        transform.position += new Vector3(0.0f, 0.0f, ObjectDistance);
        progressDistanceCounter.OnProgressPlayer(ObjectDistance);
        inputIntervalManager.OnInput();
        comboCounter.OnSuccessCombo();
    }
}
