using UnityEngine.UI;
using I2.Loc;

/// <summary>
/// コンボをカウントするクラス
/// </summary>
public static class ComboCounter
{
    public static int ComboCount { get; private set; }     //コンボをカウントする
    static Text comboText;                                 //コンボを表示するText

    /// <summary>
    /// 初期化処理
    /// </summary>
    public static void Initialize()
    {
        ComboCount = 0;
        comboText.text = "";
    }

    /// <summary>
    /// コンボを成功させた時に呼ぶ
    /// </summary>
    public static void OnSuccessCombo()
    {
        ComboCount++;
        if(LocalizationManager.CurrentLanguage == "Japanese")
        {
            comboText.text = ComboCount.ToString() + "コンボ!!";

        }
        else if(LocalizationManager.CurrentLanguage == "English")
        {
            comboText.text = ComboCount.ToString() + "Combo!!";
        }
    }

    /// <summary>
    /// コンボを失敗した時に呼ぶ
    /// </summary>
    public static void OnMissCombo()
    {
        ComboCount = 0;
        if (LocalizationManager.CurrentLanguage == "Japanese")
        {
            comboText.text = "ミス!";

        }
        else if (LocalizationManager.CurrentLanguage == "English")
        {
            comboText.text = "Miss!";
        }
    }

    /// <summary>
    /// コンボを表示するTextをセットする
    /// </summary>
    /// <param name="text">表示するText</param>
    public static void SetComboText(Text text)
    {
        comboText = text;
    }
}
