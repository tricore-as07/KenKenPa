using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using I2.Loc;

/// <summary>
/// 制限時間のタイマー
/// </summary>
public class Timer : MonoBehaviour
{
    [SerializeField] float limitTimeSetting = 0f;               //制限時間の設定時間
    float limitTime;                                            //カウントダウンする制限時間
    public float LimitTime => limitTime;                        //外部に公開するためのプロパティ
    [SerializeField] UnityEvent onTimeLimitEvent = default;     //制限時間がなくなった時に呼ばれるイベント
    bool isCallTimeLimitEvent;                                  //制限時間がきてイベントが呼ばれたかどうか
    [SerializeField] Text timeText;                             //タイマーを表示するテキスト
    [SerializeField] GameObject EndCountDownObject = default;   //ゲーム終了時のカウントダウンを表示するオブジェクト
    bool isCountDown;                                           //カウントダウンをするかどうか
    string timeFrontText;                                       //制限時間の前に表示するテキストの文字列
    string timeBackText;                                        //制限時間の後ろに表示するテキストの文字列
    bool isAddTimeBonus;                                        //タイムボーナスを追加したかどうか
    [SerializeField] int timeBonusCoefficient = default;        //タイムボーナスを追加する際のコンボ数にかかる係数
    [SerializeField] float timeBonusByCombo = default;          //コンボによるタイムボーナス

    /// <summary>
    /// オブジェクトがアクティブになった時によばれる
    /// </summary>
    void OnEnable()
    {
        limitTime = limitTimeSetting;
        isCallTimeLimitEvent = false;
        isCountDown = false;
        timeFrontText = LocalizationManager.GetTranslation("Time_Front");
        timeBackText = LocalizationManager.GetTranslation("Time_Back");
        timeText.text = timeFrontText + limitTime.ToString("0") + timeBackText;
        EndCountDownObject.SetActive(false);
        isAddTimeBonus = false;
    }

    /// <summary>
    /// カウントダウンを開始する
    /// </summary>
    public void StartCountDown()
    {
        isCountDown = true;
    }

    /// <summary>
    /// 毎フレーム行う処理
    /// </summary>
    void Update()
    {
        if(!isCountDown)
        {
            return;
        }
        if (isCallTimeLimitEvent)
        {
            return;
        }
        //制限時間がなくなったら
        if (limitTime <= 0)
        {
            onTimeLimitEvent.Invoke();
            isCallTimeLimitEvent = true;
            limitTime = 0;
            timeText.text = timeFrontText + limitTime.ToString("0") + timeBackText;
        }
        else
        {
            limitTime -= Time.deltaTime;
            timeText.text = timeFrontText + limitTime.ToString("0") + timeBackText;
            //制限時間が１０秒以下になって、終了カウントダウンがアクティブになっていない時
            if(limitTime <= 11.0 && !isAddTimeBonus)
            {
                isAddTimeBonus = true;
                limitTime += ComboCounter.MaxComboCount / timeBonusCoefficient;
            }
            if(limitTime <= 10.5 && !EndCountDownObject.activeSelf)
            {
                EndCountDownObject.SetActive(true);
            }
        }
    }

    /// <summary>
    /// コンボによるタイムボーナスの追加
    /// </summary>
    public void AddTimeBonusByCombo()
    {
        limitTime += timeBonusByCombo;
    }
}