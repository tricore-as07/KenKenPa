using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

/// <summary>
/// 制限時間のタイマー
/// </summary>
public class Timer : MonoBehaviour
{
    [SerializeField] float limitTimeSetting = 0f;           //制限時間の設定時間
    float limitTime;                                        //カウントダウンする制限時間
    public float LimitTime => limitTime;                    //外部に公開するためのプロパティ
    [SerializeField] UnityEvent onTimeLimitEvent = default; //制限時間がなくなった時に呼ばれるイベント
    bool isCallTimeLimitEvent;                              //制限時間がきてイベントが呼ばれたかどうか
    [SerializeField] Text timeText;                         //タイマーを表示するテキスト
    bool isCountDown;                                       //カウントダウンをするかどうか

    /// <summary>
    /// オブジェクトがアクティブになった時によばれる
    /// </summary>
    void OnEnable()
    {
        limitTime = limitTimeSetting;
        isCallTimeLimitEvent = false;
        isCountDown = false;
    }

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
        }
        else
        {
            limitTime -= Time.deltaTime;
            timeText.text = limitTime.ToString("F2");
        }
    }
}
