using UnityEngine;
using UnityEngine.Events;
using TMPro;
using I2.Loc;

/// <summary>
/// 制限時間のタイマー
/// </summary>
public class Timer : MonoBehaviour
{
    [SerializeField] float limitTimeSetting = 0f;               //制限時間の設定時間
    [SerializeField] TextMeshProUGUI timeText = default;        //タイマーを表示するテキスト
    [SerializeField] GameObject EndCountDownObject = default;   //ゲーム終了時のカウントダウンを表示するオブジェクト
    [SerializeField] Animator animator = default;               //カウントダウンのアニメーター
    [SerializeField] UnityEvent onTimeLimitEvent = default;     //制限時間がなくなった時に呼ばれるイベント
    [SerializeField] int timeBonusCoefficient = default;        //タイムボーナスを追加する際のコンボ数にかかる係数
    [SerializeField] float timeBonusByCombo = default;          //コンボによるタイムボーナス
    [SerializeField] GameObject comboBonus = default;           //コンボボーナスのUIオブジェクト
    [SerializeField] ShowComboBonusUI showComboBonusUI;         //コンボボーナスのUIを表示するためのクラス
    [SerializeField] int timeBonusComboNum = 20;                //タイムボーナスを追加するコンボ数
    float limitTime;                                            //カウントダウンする制限時間
    public float LimitTime => limitTime;                        //外部に公開するためのプロパティ
    bool isCallTimeLimitEvent;                                  //制限時間がきてイベントが呼ばれたかどうか
    bool isCountDown;                                           //カウントダウンをするかどうか
    public bool IsCountDown => isCountDown;                     //外部に公開するためのプロパティ
    string timeFrontText;                                       //制限時間の前に表示するテキストの文字列
    string timeBackText;                                        //制限時間の後ろに表示するテキストの文字列
    bool isAddTimeBonus;                                        //タイムボーナスを追加したかどうか
    const float countDownAnimationTime = 11f;                   //アニメーションの時間
    const float startEndCountDownTime = 10f;                  //終了のカウントダウンが始まる時間

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
        showComboBonusUI = comboBonus.GetComponent<ShowComboBonusUI>();
        ComboCounter.onSuccessComboEvent += OnSuccessCombo;
    }

    /// <summary>
    /// オブジェクトがアクティブになった時によばれる
    /// </summary>
    void OnDisable()
    {
        ComboCounter.onSuccessComboEvent -= OnSuccessCombo;
    }

    /// <summary>
    /// カウントダウンを開始する
    /// </summary>
    public void StartCountDown()
    {
        isCountDown = true;
    }

    /// <summary>
    /// カウントダウンを停止する
    /// </summary>
    public void StopCountDown()
    {
        isCountDown = false;
    }

    /// <summary>
    /// 毎フレーム行う処理
    /// </summary>
    void Update()
    {
        //カウントダウンをしていないかカウントダウンが終了していたら早期リターン
        if (!isCountDown || isCallTimeLimitEvent)
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
        //制限時間が残っている時の処理
        else
        {
            limitTime -= Time.deltaTime;
            timeText.text = timeFrontText + Mathf.Ceil(limitTime).ToString("0") + timeBackText;
            //カウントダウンアニメーションが始まる時間より小さく、１ゲーム1回のタイムボーナスを追加していなかったら
            if(limitTime <= countDownAnimationTime && !isAddTimeBonus)
            {
                //１ゲームで1回だけタイムボーナスを追加する
                isAddTimeBonus = true;
                var bonusTime = ComboCounter.MaxComboCount / timeBonusCoefficient;
                showComboBonusUI.gameObject.SetActive(true);
                showComboBonusUI.SetBonusTime((int)bonusTime);
                limitTime += bonusTime;
            }
            //制限時間が１０秒以下になって、終了カウントダウンがアクティブになっていない時
            if (limitTime <= startEndCountDownTime && !EndCountDownObject.activeSelf)
            {
                EndCountDownObject.SetActive(true);
            }
        }
    }

    /// <summary>
    /// コンボを成功させた時に呼ぶ
    /// </summary>
    void OnSuccessCombo()
    {
        //タイムボーナスがもらえるコンボ数なら
        if (ComboCounter.ComboCount % timeBonusComboNum == 0)
        {
            AddTimeBonusByCombo();
        }
    }

    /// <summary>
    /// コンボによるタイムボーナスの追加
    /// </summary>
    void AddTimeBonusByCombo()
    {
        limitTime += timeBonusByCombo;      //タイムの追加
        comboBonus.SetActive(true);         //タイムボーナスのUIをアクティブに
        showComboBonusUI.SetBonusTime((int)timeBonusByCombo);
        //終了時のカウントダウンがアクティブの時
        if (EndCountDownObject.activeSelf)
        {
            //カウントダウンを始める時間より現在の時間が大きくなったら
            if(limitTime > startEndCountDownTime)
            {
                //カウントダウンを非アクティブにして早期リターン
                EndCountDownObject.SetActive(false);
                return;
            }
            //増えた時間に応じてアニメーションを巻き戻す
            float nowTime = animator.GetCurrentAnimatorStateInfo(0).normalizedTime;
            nowTime -= (float)(timeBonusByCombo / countDownAnimationTime);
            animator.CrossFade("EndCountDown",0.0f,0, nowTime);
        }
    }
}