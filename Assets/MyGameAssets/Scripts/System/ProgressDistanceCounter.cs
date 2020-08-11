/// <summary>
/// 前進した距離をカウントしておくクラス
/// </summary>
public static class ProgressDistanceCounter
{
    static float distanceCounter;                                           //進んだ距離をカウントする
    public static float DistanceCounter => distanceCounter;                 //進んだ距離を取得するためのプロパティ

    /// <summary>
    /// 初期化処理
    /// </summary>
    public static void Initialize()
    {
        distanceCounter = 0;
    }

    /// <summary>
    /// プレイヤーが前進した時に呼ばれる
    /// </summary>
    /// <param name="progressDistance">前進した距離</param>
    public static void OnProgressPlayer(float progressDistance)
    {
        distanceCounter += progressDistance;
    }
}
