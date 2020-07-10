/// <summary>
/// コンボをカウントするクラス
/// </summary>
public static class ComboCounter
{
    public static int ComboCount { get; private set; }     //コンボをカウントする

    /// <summary>
    /// 初期化処理
    /// </summary>
    public static void Initialize()
    {
        ComboCount = 0;
    }

    /// <summary>
    /// コンボを成功させた時に呼ぶ
    /// </summary>
    public static void OnSuccessCombo()
    {
        ComboCount++;
    }

    /// <summary>
    /// コンボを失敗した時に呼ぶ
    /// </summary>
    public static void OnMissCombo()
    {
        ComboCount = 0;
    }
}
