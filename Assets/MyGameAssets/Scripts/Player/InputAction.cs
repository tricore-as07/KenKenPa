using UnityEngine;

/// <summary>
/// 入力があった際の動作をするクラス
/// </summary>
public class InputAction : MonoBehaviour
{
    CorrectCheck correctCheck;                                      //入力された場所が当たりか外れかを判定するクラス
    GameObject stage;                                               //ステージのオブジェクト
    InputIntervalManager inputIntervalManager;                      //入力から次の入力を受け付けるまでの時間を管理するクラス
    StageCreater stageCreater;                                      //ステージを生成するクラス

    /// <summary>
    /// 最初に行う処理
    /// </summary>
    void Start()
    {
        stage = GameObject.FindGameObjectWithTag("Stage");
        //最初のオブジェクトグループのHitCheckクラスを代入
        correctCheck = stage.transform.GetChild(0).GetComponent<CorrectCheck>();
        //管理系のクラス
        inputIntervalManager = GameObject.FindGameObjectWithTag("InputIntervalManager").GetComponent<InputIntervalManager>();
        stageCreater = GameObject.FindGameObjectWithTag("StageCreater").GetComponent<StageCreater>();
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
                ComboCounter.OnMissCombo();
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
                ComboCounter.OnMissCombo();
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
                ComboCounter.OnMissCombo();
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
        //チェックする対象を次のオブジェクトグループに移す必要があるか
        if (correctCheck.NeedsNextObjectsGroup())
        {
            correctCheck.OnNecessaryCorrentCheck();
            //追加でオブジェクトグループを作成
            stageCreater.AddObjectsGroup();
            //チェックする対象を次のオブジェクトグループに変更
            const int next = 1;
            correctCheck = stage.transform.GetChild(next).GetComponent<CorrectCheck>();
        }
    }

    /// <summary>
    /// 当たりを全て選んだ時にプレイヤーがやる処理
    /// </summary>
    /// FIXME orimoto モック版作成時のためマジックナンバー使用（本実装時に修正予定）
    void OnAllCorrectSelectPlayerAction()
    {
        const float ObjectDistance = 3f;              //オブジェクトの間の距離（ランダム生成システム作成時にScriptableObjectで設定できるように変更予定）
        transform.position += new Vector3(0.0f, 0.0f, ObjectDistance);
        ProgressDistanceCounter.OnProgressPlayer(ObjectDistance);
        inputIntervalManager.OnInput();
        ComboCounter.OnSuccessCombo();
    }
}
