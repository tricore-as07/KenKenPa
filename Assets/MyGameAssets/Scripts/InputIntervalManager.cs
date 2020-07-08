using UnityEngine;

/// <summary>
/// 入力から次の入力を受け付けるまでの時間を管理する
/// </summary>
public class InputIntervalManager : MonoBehaviour
{
    [SerializeField] InputIntervalSettingData inputIntervalSettingData = null;  //入力間の受付時間をコンボ数で管理するための設定データ
    bool canInput;                                                              //入力可能かどうか
    float inputIntervalCounter;                                                 //入力間の時間を数えるカウンター
    float intervalTime = 0f;                                                    //入力から次の入力を受け付けるまでの時間
    ComboCounter comboCounter;                                                  //コンボをカウントするクラス

    /// <summary>
    /// 最初に行う処理
    /// </summary>
    void Start()
    {
        comboCounter = GameObject.FindGameObjectWithTag("ComboCounter").GetComponent<ComboCounter>();
    }

    /// <summary>
    /// 毎フレーム行う処理
    /// </summary>
    void Update()
    {
        //入力を受け付けてない時
        if (!canInput)
        {
            //入力が出来るまでのカウンターを進める
            inputIntervalCounter += Time.deltaTime;
            if (inputIntervalCounter > intervalTime)
            {
                //入力を可能にする
                canInput = true;
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
        foreach (var inputintervalSetting in inputIntervalSettingData.inputIntervalSettings)
        {
            //現在のコンボ数が設定にあるコンボ数より小さい時
            if (inputintervalSetting.ComboNum > comboCounter.comboCount)
            {
                intervalTime = inputintervalSetting.IntervalTime;
                break;
            }
        }
    }

    /// <summary>
    /// 入力できるかどうか
    /// </summary>
    /// <returns>入力可 : true,入力不可 : false</returns>
    public bool CanInput()
    {
        return canInput;
    }

    /// <summary>
    /// 入力した時に呼ぶ
    /// </summary>
    public void Inputed()
    {
        canInput = false;
        inputIntervalCounter = 0f;
    }
}
