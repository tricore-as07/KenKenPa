using UnityEngine;
using I2.Loc;
using TMPro;
using System.Collections.Generic;
using System.Collections;
using System;

/// <summary>
/// コンボボーナスのUIを表示する
/// </summary>
public class ShowComboBonusUI : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI meshPro = default;             //コンボボーナスを表示するText
    [SerializeField] float showTime = default;                      //コンボボーナスを表示する時間
    [SerializeField] CanvasGroup canvas = default;                  //コンボボーナスのキャンバスグループ
    [SerializeField] float fadeOutTime = default;                   //フェードアウト
    [SerializeField] Animator animator = default;                   //アニメーター
    const string animationName = "ComboBonusAnimation";             //アニメーションの名前
    string timeBack;                                                //時間の後ろの文字
    [SerializeField] List<ComboBonusUiSetting> comboBonusSettings;  //コンボボーナスのオブジェクトを設定するリスト     
        
    /// <summary>
    /// ボーナスタイムをセット
    /// </summary>
    /// <param name="time">セットする時間</param>
    public void SetBonusTime(int time)
    {
        meshPro.text = "+" + time.ToString() + timeBack;
    }

    /// <summary>
    /// オブジェクトがアクティブになった時に呼ばれる
    /// </summary>
    void OnEnable()
    {
        SelectPraiseComboBonusUI();
        animator.Play(animationName,0,0f);
        //showTimeの時間後にコンボボーナスオブジェクトを非アクティブにする
        StartCoroutine(DelayMethod(showTime, () =>
        {
            gameObject.SetActive(false);
        }));
        timeBack = LocalizationManager.GetTranslation("Time_Back");
        canvas.alpha = 1;
        StartCoroutine(FadeOutCanvas(showTime - fadeOutTime, fadeOutTime, canvas));
    }

    /// <summary>
    /// コンボボーナスで褒めるUIを選択する
    /// </summary>
    void SelectPraiseComboBonusUI()
    {
        GameObject ui = null;
        //設定されているコンボ数より今のコンボ数が多かったら後にアクティブにするオブジェクトに代入する
        foreach(var comboBonusSetting in comboBonusSettings)
        {
            if(comboBonusSetting.ComboNum < ComboCounter.ComboCount)
            {
                ui = comboBonusSetting.ShowUi;
                comboBonusSetting.ShowUi.SetActive(false);
            }
        }
        //有効にするUIがあったときはアクティブにする
        if(ui != null)
        {
            ui.SetActive(true);
        }
    }

    /// <summary>
    /// 渡された処理を指定時間後に実行する
    /// </summary>
    /// <param name="waitTime">遅延時間</param>
    /// <param name="action">実行したい処理</param>
    IEnumerator DelayMethod(float waitTime, Action action)
    {
        yield return new WaitForSeconds(waitTime);
        action();
    }

    /// <summary>
    /// 指定された時間後にキャンバスをフェードアウトさせる
    /// </summary>
    /// <param name="waitTime">遅らせる時間</param>
    /// <param name="runTime">実行にかける時間</param>
    /// <param name="fadeOutCanvas">フェードアウトさせるキャンバス</param>
    IEnumerator FadeOutCanvas(float waitTime, float runTime, CanvasGroup fadeOutCanvas)
    {
        yield return new WaitForSeconds(waitTime);
        while (runTime >= 0)
        {
            fadeOutCanvas.alpha -= Time.deltaTime / runTime;
            runTime -= Time.deltaTime;
            yield return null;
        }
    }
}

/// <summary>
/// コンボ数によって表示するUIを別々に設定する
/// </summary>
/// NOTE : orimoto ここで設定されているコンボ数以上で設定されているオブジェクトをアクティブにする
[System.Serializable]
public class ComboBonusUiSetting
{
    [SerializeField] int comboNum = default;                        //コンボ数
    public int ComboNum => comboNum;                                //外部に公開するためのプロパティ
    [SerializeField] GameObject showUi = default;                   //表示するUI
    public GameObject ShowUi => showUi;                       //外部に公開するためのプロパティ
}