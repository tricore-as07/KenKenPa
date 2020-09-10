using UnityEngine;
using I2.Loc;
using TMPro;
using System.Collections;
using System;

/// <summary>
/// コンボボーナスのUIを表示する
/// </summary>
public class ShowComboBonusUI : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI meshPro = default;         //コンボボーナスを表示するText
    [SerializeField] float showTime = default;                  //コンボボーナスを表示する時間
    [SerializeField] CanvasGroup canvas = default;              //コンボボーナスのキャンバスグループ
    [SerializeField] float fadeOutTime = default;               //フェードアウト
    string timeBack;                                            //時間の後ろの文字

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
