﻿using UnityEngine;

/// <summary>
/// 入力があった際の動作をするクラス
/// </summary>
public class InputAction : MonoBehaviour
{
    [SerializeField] AudioSource audioSource = default;                 //オーディオソースコンポーネント
    [SerializeField] AudioClip correctSE = default;                     //正解時のSE
    [SerializeField] AudioClip incorrectSE = default;                   //不正解時のSE
    [SerializeField] PlayerInput playerInput = default;                 //ゲーム中のプレイヤーの入力に関するクラス
    [SerializeField] GameObject playerTarget = default;                 //プレイヤーの目標位置のためのオブジェクト
    [SerializeField, Range(0f, 1f)] float InterpolationNum = default;   //補間に使う値 
    CorrectCheck correctCheck;                                          //入力された場所が当たりか外れかを判定するクラス
    GameObject stage;                                                   //ステージのオブジェクト
    InputIntervalManager inputIntervalManager;                          //入力から次の入力を受け付けるまでの時間を管理するクラス
    StageCreater stageCreater;                                          //ステージを生成するクラス

    /// <summary>
    /// オブジェクトがアクティブになった時によばれる
    /// </summary>
    void OnEnable()
    {
        stage = GameObject.FindGameObjectWithTag("Stage");
        //最初のオブジェクトグループのHitCheckクラスを代入
        correctCheck = stage.transform.GetChild(0).GetComponent<CorrectCheck>();
        correctCheck.OnEnableCorrentCheck();
        playerTarget.transform.position = Vector3.zero;
    }

    /// <summary>
    /// オブジェクトが非アクティブになった時によばれる
    /// </summary>
    void OnDisable()
    {
        correctCheck.OnDisableCorrectCheck();
    }

    /// <summary>
    /// 最初に行う処理
    /// </summary>
    void Start()
    {
        //管理系のクラス
        inputIntervalManager = GameObject.FindGameObjectWithTag("InputIntervalManager").GetComponent<InputIntervalManager>();
        stageCreater = GameObject.FindGameObjectWithTag("StageCreater").GetComponent<StageCreater>();
    }

    /// <summary>
    /// 毎フレーム行う処理
    /// </summary>
    void Update()
    {
        //ターゲットとの距離を
        transform.position = Vector3.Lerp(transform.position,playerTarget.transform.position, InterpolationNum);
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
                inputIntervalManager.MissInput();
                audioSource.PlayOneShot(incorrectSE);
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
                StartCoroutine(playerInput.WaitSideInput());
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
                inputIntervalManager.MissInput();
                audioSource.PlayOneShot(incorrectSE);
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
            correctCheck.OnNecessaryCorrectCheck();
            //追加でオブジェクトグループを作成
            stageCreater.AddObjectsGroup();
            //チェックする対象を次のオブジェクトグループに変更
            const int next = 1;
            correctCheck = stage.transform.GetChild(next).GetComponent<CorrectCheck>();
            correctCheck.OnEnableCorrentCheck();
        }
    }

    /// <summary>
    /// 当たりを全て選んだ時にプレイヤーがやる処理
    /// </summary>
    void OnAllCorrectSelectPlayerAction()
    {
        const float ObjectDistance = 3f;              //オブジェクトの間の距離（ランダム生成システム作成時にScriptableObjectで設定できるように変更予定）
        playerTarget.transform.position += new Vector3(0.0f, 0.0f, ObjectDistance);
        ProgressDistanceCounter.OnProgressPlayer(ObjectDistance);
        ComboCounter.OnSuccessCombo();
        inputIntervalManager.OnInput();
        audioSource.PlayOneShot(correctSE, audioSource.volume);
    }

    /// <summary>
    /// 中央入力でミスだった時に呼ばれる
    /// </summary>
    public void OnCenterInputMiss()
    {
        ComboCounter.OnMissCombo();
        inputIntervalManager.MissInput();
        audioSource.PlayOneShot(incorrectSE);
    }
}
