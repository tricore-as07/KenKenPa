using UnityEngine;
using NendUnityPlugin.AD.Video;

public class VideoObject : MonoBehaviour
{
#if UNITY_IOS
    private string spotId = "802555", apiKey = "ca80ed7018734d16787dbda24c9edd26c84c15b8";
#else
    private string spotId = "802558", apiKey = "a6eb8828d64c70630fd6737bd266756c5c7d48aa";
#endif
    private NendAdRewardedVideo m_RewardedVideoAd;

    // Use this for initialization
    void Start()
    {
        m_RewardedVideoAd =
            NendAdRewardedVideo.NewVideoAd(spotId, apiKey);

        m_RewardedVideoAd.AdLoaded += (instance) => {
            // 広告ロード成功のコールバック
        };
        m_RewardedVideoAd.AdFailedToLoad += (instance, errorCode) => {
            // 広告ロード失敗のコールバック
        };
        m_RewardedVideoAd.AdFailedToPlay += (instance) => {
            // 再生失敗のコールバック
        };
        m_RewardedVideoAd.AdShown += (instance) => {
            // 広告表示のコールバック
        };
        m_RewardedVideoAd.AdStarted += (instance) => {
            // 再生開始のコールバック
        };
        m_RewardedVideoAd.AdStopped += (instance) => {
            // 再生中断のコールバック
        };
        m_RewardedVideoAd.AdCompleted += (instance) => {
            // 再生完了のコールバック
        };
        m_RewardedVideoAd.AdClicked += (instance) => {
            // 広告クリックのコールバック
        };
        m_RewardedVideoAd.InformationClicked += (instance) => {
            // オプトアウトクリックのコールバック
        };
        m_RewardedVideoAd.AdClosed += (instance) => {
            // 広告クローズのコールバック
        };
        m_RewardedVideoAd.Rewarded += (instance, rewardedItem) => {
            // リワード報酬のコールバック
            Debug.Log("CurrencyName = " + rewardedItem.currencyName);
            Debug.Log("CurrencyAmount = " + rewardedItem.currencyAmount);
        };
    }

    void OnDestroy()
    {
        m_RewardedVideoAd.Release();
    }

    public void Load()
    {
        m_RewardedVideoAd.Load();
    }

    public void Show()
    {
        if (m_RewardedVideoAd.IsLoaded())
        {
            m_RewardedVideoAd.Show();
        }
    }
}