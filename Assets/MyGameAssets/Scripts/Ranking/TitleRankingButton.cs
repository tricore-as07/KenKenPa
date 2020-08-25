using UnityEngine;

/// <summary>
/// タイトルのランキングボタンに関するボタン
/// </summary>
public class TitleRankingButton : MonoBehaviour
{
    /// <summary>
    /// オブジェクトが生成された直後に呼ばれる
    /// </summary>
    void Awake()
    {
        GameServiceUtil.Auth();
    }

    /// <summary>
    /// ランキングボタンが押された時
    /// </summary>
    public void OnClickRankingButton()
    {
        GameServiceUtil.ShowLeaderboardUI();
    }
}
