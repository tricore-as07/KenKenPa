using I2.Loc;
using TMPro;
using UnityEngine;

/// <summary>
/// コンボをカウントするクラス
/// </summary>
public static class ComboCounter
{
    public static int ComboCount { get; private set; }      //コンボをカウントする
    public static int MaxComboCount { get; private set; }   //最大コンボのカウント
    static TextMeshProUGUI comboText;                       //コンボを表示するText
    static string comboBackText;                            //コンボの後ろに表示する文字列
    static Timer timer;                                     //タイマークラス
    const int timeBonusComboNum = 20;                       //タイムボーナスを追加するコンボ数
    static Animator addAnimator;                            //コンボのアニメーター
    static Animator missAnimator;                           //コンボのアニメーター
    const string addStateName = "AddComboAnimation";        //コンボを追加した時のアニメーション
    const string missStateName = "MissComboAnimation";      //コンボをミスした時のアニメーション
    static int sccessObjNum = 0;                            //成功した時に表示するオブジェクトの要素数番号
    static int missObjNum = 1;                              //失敗した時に表示するオブジェクトの要素数番号
    static GameObject sccessObj;                            //成功した時に表示するオブジェクト
    static GameObject missObj;                              //失敗した時に表示するオブジェクト
    static ComboMaterialDecider decider;                    //コンボ数でマテリアルを変更するクラス

    /// <summary>
    /// 初期化処理
    /// </summary>
    public static void Initialize()
    {
        ComboCount = 0;
        MaxComboCount = 0;
        comboText.text = "";
        comboBackText = LocalizationManager.GetTranslation("Combo_Back");
    }

    /// <summary>
    /// コンボを成功させた時に呼ぶ
    /// </summary>
    public static void OnSuccessCombo()
    {
        sccessObj.SetActive(true);
        missObj.SetActive(false);
        ComboCount++;
        decider.OnAddCombo();
        //コンボ数を文字列にしてテキストを書き換える
        comboText.text = ComboCount.ToString() + comboBackText;
        //アニメーションを最初から再生
        addAnimator.Play(addStateName, 0,0f);
        //コンボの最大数のカウント
        if (MaxComboCount < ComboCount)
        {
            MaxComboCount = ComboCount;
        }
        //タイムボーナスがもらえるコンボ数なら
        if(ComboCount % timeBonusComboNum == 0)
        {
            timer.AddTimeBonusByCombo();
        }
    }

    /// <summary>
    /// コンボを失敗した時に呼ぶ
    /// </summary>
    public static void OnMissCombo()
    {
        sccessObj.SetActive(false);
        missObj.SetActive(true);
        missAnimator.Play(missStateName, 0, 0f);
        ComboCount = 0;
    }

    /// <summary>
    /// コンボ関連のオブジェクトをセットする
    /// </summary>
    /// <param name="obj">示するオブジェクト</param>
    public static void SetComboObject(GameObject obj)
    {
        sccessObj = obj.transform.GetChild(sccessObjNum).gameObject;
        missObj = obj.transform.GetChild(missObjNum).gameObject;
        //よくアクセスするコンポーネントをキャッシュしておく
        comboText = sccessObj.GetComponent<TextMeshProUGUI>();
        addAnimator = sccessObj.GetComponent<Animator>();
        missAnimator = missObj.GetComponent<Animator>();
        decider = sccessObj.GetComponent<ComboMaterialDecider>();
    }

    /// <summary>
    /// 制限時間管理するタイマークラスをセットする
    /// </summary>
    /// <param name="timer">制限時間のタイマー</param>
    public static void SetTimer(Timer argTimer)
    {
        timer = argTimer;
    }
}
