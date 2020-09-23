using UnityEngine;
using I2.Loc;
using TMPro;
using System.Collections.Generic;
using System.Collections;

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
        animator.Play(animationName,0,0f);
        timeBack = LocalizationManager.GetTranslation("Time_Back");
        canvas.alpha = 1;
        StartCoroutine(FadeOutCanvas(showTime - fadeOutTime, fadeOutTime, canvas));
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
        //アルファが０になって表示する必要がなかったらオブジェクトを非アクティブにする
        gameObject.SetActive(false);
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