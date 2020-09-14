/// <summary>
/// コンボをカウントするクラス
/// </summary>
public static class ComboCounter
{
    public static int ComboCount { get; private set; }              //コンボをカウントする
    public static int MaxComboCount { get; private set; }           //最大コンボのカウント
    public delegate void OnSuccessComboEvent();                     //コンボを成功させた時に呼ぶ関数のデリゲート
    public static event OnSuccessComboEvent onSuccessComboEvent;    //コンボを成功させた時に呼ぶイベント
    public delegate void OnMissComboEvent();                        //コンボを失敗させた時に呼ぶ関数のデリゲート
    public static event OnMissComboEvent onMissComboEvent;          //コンボを失敗させた時に呼ぶイベント

    /// <summary>
    /// 初期化処理
    /// </summary>
    public static void Initialize()
    {
        ComboCount = 0;
        MaxComboCount = 0;
    }

    /// <summary>
    /// コンボを成功させた時に呼ぶ
    /// </summary>
    public static void OnSuccessCombo()
    {
        ComboCount++;
        //コンボの最大数のカウント
        if (MaxComboCount < ComboCount)
        {
            MaxComboCount = ComboCount;
        }
        onSuccessComboEvent?.Invoke();
    }

    /// <summary>
    /// コンボを失敗した時に呼ぶ
    /// </summary>
    public static void OnMissCombo()
    {
        ComboCount = 0;
        onMissComboEvent?.Invoke();
    }
}
