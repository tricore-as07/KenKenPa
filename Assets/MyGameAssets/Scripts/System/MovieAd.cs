using UnityEngine;
using NendUnityPlugin.AD.Video;

/// <summary>
/// 動画広告
/// </summary>
public class MovieAd : MonoBehaviour
{
#if UNITY_IOS
    private string spotId = "1014693", apiKey = "0d25c4cb7eda127b29685cfeaa78379f2f3ae8e1";
#else
    private string spotId = "1014693", apiKey = "0d25c4cb7eda127b29685cfeaa78379f2f3ae8e1";
#endif
    private NendAdInterstitialVideo m_InterstitialVideoAd;
    [SerializeField] GameObject countDown = default;
    private bool isAdCompleted;
    private bool IsAdCompleted => isAdCompleted;

    /// <summary>
    /// 最初に行う処理
    /// </summary>
    void Start()
    {
        m_InterstitialVideoAd =
            NendAdInterstitialVideo.NewVideoAd(spotId, apiKey);

        m_InterstitialVideoAd.AdLoaded += (instance) => {
            // 広告ロード成功のコールバック
        };
        m_InterstitialVideoAd.AdFailedToLoad += (instance, errorCode) => {
            // 広告ロード失敗のコールバック
            countDown.SetActive(true);
        };
        m_InterstitialVideoAd.AdFailedToPlay += (instance) => {
            // 再生失敗のコールバック
            countDown.SetActive(true);
        };
        m_InterstitialVideoAd.AdShown += (instance) => {
            // 広告表示のコールバック
        };
        m_InterstitialVideoAd.AdStarted += (instance) => {
            // 再生開始のコールバック
            isAdCompleted = false;
        };
        m_InterstitialVideoAd.AdStopped += (instance) => {
            // 再生中断のコールバック
        };
        m_InterstitialVideoAd.AdCompleted += (instance) => {
            // 再生完了のコールバック
            isAdCompleted = true;
        };
        m_InterstitialVideoAd.AdClicked += (instance) => {
            // 広告クリックのコールバック
        };
        m_InterstitialVideoAd.InformationClicked += (instance) => {
            // オプトアウトクリックのコールバック
        };
        m_InterstitialVideoAd.AdClosed += (instance) => {
            // 広告クローズのコールバック
        };
    }

    /// <summary>
    /// オブジェクトが破棄された時に呼ばれる
    /// </summary>
    void OnDestroy()
    {
        m_InterstitialVideoAd.Release();
    }

    /// <summary>
    /// 動画広告をロードする
    /// </summary>
    public void Load()
    {
        m_InterstitialVideoAd.Load();
    }

    /// <summary>
    /// 動画広告を表示する
    /// </summary>
    public void Show()
    {
        if (m_InterstitialVideoAd.IsLoaded())
        {
            m_InterstitialVideoAd.Show();
        }
    }
}