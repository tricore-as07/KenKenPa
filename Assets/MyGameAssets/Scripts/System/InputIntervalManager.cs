using UnityEngine;

/// <summary>
/// 入力から次の入力を受け付けるまでの時間を管理する
/// </summary>
public class InputIntervalManager : MonoBehaviour
{
    [SerializeField] InputIntervalSettingData inputIntervalSettingData = default;  //入力間の受付時間をコンボ数で管理するための設定データ
    public bool isAbleInput { get; private set; }                                   //入力可能かどうか
    float inputIntervalCounter;                                                     //入力間の時間を数えるカウンター
    float intervalTime = 0f;                                                        //入力から次の入力を受け付けるまでの時間
    bool useStartIntervalData;                                                      //ゲーム開始して1回失敗するまでのデータを使うかどうか

    /// <summary>
    /// オブジェクトがアクティブになった時によばれる
    /// </summary>
    void OnEnable()
    {
        UpdateIntervalTime();
        isAbleInput = true;
        useStartIntervalData = true;
    }

    /// <summary>
    /// 毎フレーム行う処理
    /// </summary>
    void Update()
    {
        //入力を受け付けてない時
        if (!isAbleInput)
        {
            //入力が出来るまでのカウンターを進める
            inputIntervalCounter += Time.deltaTime;
            if (inputIntervalCounter > intervalTime)
            {
                //入力を可能にする
                isAbleInput = true;
                UpdateIntervalTime();
            }
        }
    }

    /// <summary>
    /// 入力から次の入力を受け付けるまでの時間を更新する
    /// </summary>
    void UpdateIntervalTime()
    {
        intervalTime = 0.0f;
        if (useStartIntervalData)
        {
            var inputIntervalSetting = inputIntervalSettingData.StartInputIntervalSettings.GetEnumerator();
            inputIntervalSetting.Reset();
            while (inputIntervalSetting.MoveNext())
            {
                //現在のコンボ数が設定にあるコンボ数より小さい時
                if (inputIntervalSetting.Current.ComboNum > ComboCounter.ComboCount)
                {
                    intervalTime = inputIntervalSetting.Current.IntervalTime;
                    break;
                }
            }
        }
        else
        {
            //設定データのEnumeratorを取得
            var inputIntervalSetting = inputIntervalSettingData.InputIntervalSettings.GetEnumerator();
            inputIntervalSetting.Reset();
            while (inputIntervalSetting.MoveNext())
            {
                //現在のコンボ数が設定にあるコンボ数より小さい時
                if (inputIntervalSetting.Current.ComboNum > ComboCounter.ComboCount)
                {
                    intervalTime = inputIntervalSetting.Current.IntervalTime;
                    break;
                }
            }
        }
    }

    /// <summary>
    /// 入力した時に呼ぶ
    /// </summary>
    public void OnInput()
    {
        isAbleInput = false;
        inputIntervalCounter = 0f;
    }

    /// <summary>
    /// 入力ミスした時に呼ぶ
    /// </summary>
    public void MissInput()
    {
        useStartIntervalData = false;
    }
}
