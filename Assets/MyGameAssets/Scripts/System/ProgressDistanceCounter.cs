using I2.Loc;
using TMPro;

/// <summary>
/// 前進した距離をカウントしておくクラス
/// </summary>
public static class ProgressDistanceCounter
{
    static float distanceCounter;                                           //進んだ距離をカウントする
    public static float DistanceCounter => distanceCounter;                 //進んだ距離を取得するためのプロパティ
    static TextMeshProUGUI distText;                                                   //進んだ距離を表示するText
    static string distFrontText;                                            //進んだ距離の前に表示するテキストの文字列

    /// <summary>
    /// 初期化処理
    /// </summary>
    public static void Initialize()
    {
        distanceCounter = 0;
        distFrontText = LocalizationManager.GetTranslation("Dist_Front");
        distText.text = distFrontText + ProgressDistanceCounter.DistanceCounter.ToString() + "m";
    }

    /// <summary>
    /// プレイヤーが前進した時に呼ばれる
    /// </summary>
    /// <param name="progressDistance">前進した距離</param>
    public static void OnProgressPlayer(float progressDistance)
    {
        distanceCounter += progressDistance;
        distText.text = distFrontText + ProgressDistanceCounter.DistanceCounter.ToString() + "m";
    }

    /// <summary>
    /// 進んだ距離を表示するText
    /// </summary>
    /// <param name="text">表示するText</param>
    public static void SetDistText(TextMeshProUGUI text)
    {
        distText = text;
    }
}