using UnityEngine.UI;
using I2.Loc;

/// <summary>
/// 前進した距離をカウントしておくクラス
/// </summary>
public static class ProgressDistanceCounter
{
    static float distanceCounter;                                           //進んだ距離をカウントする
    public static float DistanceCounter => distanceCounter;                 //進んだ距離を取得するためのプロパティ
    static Text distText;                                                   //進んだ距離を表示するText

    /// <summary>
    /// 初期化処理
    /// </summary>
    public static void Initialize()
    {
        distanceCounter = 0;
        distText.text = "進行距離 : " + ProgressDistanceCounter.DistanceCounter.ToString() + "m";
        if (LocalizationManager.CurrentLanguage == "Japanese")
        {
            distText.text = "進行距離 : " + ProgressDistanceCounter.DistanceCounter.ToString() + "m";
        }
        else if (LocalizationManager.CurrentLanguage == "English")
        {
            distText.text = "mileage : " + ProgressDistanceCounter.DistanceCounter.ToString() + "m";
        }
    }

    /// <summary>
    /// プレイヤーが前進した時に呼ばれる
    /// </summary>
    /// <param name="progressDistance">前進した距離</param>
    public static void OnProgressPlayer(float progressDistance)
    {
        distanceCounter += progressDistance;
        distText.text = "進行距離 : " + ProgressDistanceCounter.DistanceCounter.ToString() + "m";
        if (LocalizationManager.CurrentLanguage == "Japanese")
        {
            distText.text = "進行距離 : " + ProgressDistanceCounter.DistanceCounter.ToString() + "m";
        }
        else if (LocalizationManager.CurrentLanguage == "English")
        {
            distText.text = "Mileage : " + ProgressDistanceCounter.DistanceCounter.ToString() + "m";
        }
    }

    /// <summary>
    /// 進んだ距離を表示するText
    /// </summary>
    /// <param name="text">表示するText</param>
    public static void SetDistText(Text text)
    {
        distText = text;
    }
}