using UnityEngine;

/// <summary>
/// ランキングボタンに関するボタン
/// </summary>
public class RankingButton : MonoBehaviour
{
    /// <summary>
    /// ランキングボタンが押された時
    /// </summary>
    public void OnClickRankingButton()
    {
        GameServiceUtil.ShowLeaderboardUI();
    }
}
