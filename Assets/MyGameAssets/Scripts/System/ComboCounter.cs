using UnityEngine.UI;
using I2.Loc;

/// <summary>
/// コンボをカウントするクラス
/// </summary>
public static class ComboCounter
{
    public static int ComboCount { get; private set; }     //コンボをカウントする
    static Text comboText;                                 //コンボを表示するText
    static string comboMissText;
    static string comboBackText;

    /// <summary>
    /// 初期化処理
    /// </summary>
    public static void Initialize()
    {
        ComboCount = 0;
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
    public static void SetComboText(Text text)
    {
        comboText = text;
    }
}
