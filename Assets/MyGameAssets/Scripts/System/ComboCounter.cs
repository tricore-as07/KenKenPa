using I2.Loc;
using TMPro;

/// <summary>
/// コンボをカウントするクラス
/// </summary>
public static class ComboCounter
{
    public static int ComboCount { get; private set; }     //コンボをカウントする
    public static int MaxComboCount { get; private set; }  //最大コンボのカウント
    static TextMeshProUGUI comboText;                                 //コンボを表示するText
    static string comboMissText;
    static string comboBackText;
    static Timer timer;
    const int timeBonusComboNum = 10;

    /// <summary>
    /// 初期化処理
    /// </summary>
    public static void Initialize()
    {
        ComboCount = 0;
        MaxComboCount = 0;
        comboText.text = "";
        comboMissText = LocalizationManager.GetTranslation("ComboMiss");
        comboBackText = LocalizationManager.GetTranslation("Combo_Back");
    }

    /// <summary>
    /// コンボを成功させた時に呼ぶ
    /// </summary>
    public static void OnSuccessCombo()
    {
        ComboCount++;
        comboText.text = ComboCount.ToString() + comboBackText;
        if(MaxComboCount < ComboCount)
        {
            MaxComboCount = ComboCount;
        }
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
        ComboCount = 0;
        comboText.text = comboMissText;
    }

    /// <summary>
    /// コンボを表示するTextをセットする
    /// </summary>
    /// <param name="text">表示するText</param>
    public static void SetComboText(TextMeshProUGUI text)
    {
        comboText = text;
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
