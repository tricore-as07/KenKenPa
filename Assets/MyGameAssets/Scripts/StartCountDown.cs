using UnityEngine;

/// <summary>
/// ゲームをスタートする際のカウントダウン
/// </summary>
public class StartCountDown : MonoBehaviour
{
    [SerializeField] GamePlayManager gamePlayManager = default; //ゲームプレイシーンの管理をするクラス

    /// <summary>
    /// カウントダウンが終わった時
    /// </summary>
    public void OnCountDownEnd()
    {
        gamePlayManager.StartGamePlay();
    }
}
