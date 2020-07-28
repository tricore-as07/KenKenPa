using GoogleMobileAds.Api;
using UnityEngine;

/// <summary>
/// AdMobの広告を表示するためのスクリプト
/// </summary>
public class AdMobScript : MonoBehaviour
{
    private static BannerView bannerView;       //バナーの設定を管理するstatic変数
    private AdRequest request;                  //広告のリクエストに必要な変数

    /// <summary>
    /// 最初に行う処理
    /// </summary>
    void Start()
    {
        string appId = "ca-app-pub-4943898464524496~8024849235";
        MobileAds.Initialize(appId);
        RequestBanner();
    }

    /// <summary>
    /// バナー広告を表示する
    /// </summary>
    public void RequestBanner()
    {
        string adUnitId = "ca-app-pub-3940256099942544/2934735716";
        bannerView = new BannerView(adUnitId, AdSize.Banner, AdPosition.Bottom);
        request = new AdRequest
            .Builder()
            .AddTestDevice(AdRequest.TestDeviceSimulator)
            .Build();
        bannerView.LoadAd(request);
    }
}