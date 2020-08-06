using UnityEngine;
using VMUnityLib;

/// <summary>
/// 下のバナーを表示するクラス
/// </summary>
public class BottomBanner : MonoBehaviour
{
    AdMobManager adMobManager;
    NendAdController nendAdController;
    UserAdData userAdData;

    /// <summary>
    /// スクリプトのインスタンスがロードされたときに呼ばれる
    /// </summary>
    void Awake()
    {
        adMobManager = AdMobManager.Inst;
        nendAdController = NendAdController.Inst;
        userAdData = UserAdData.Inst;
    }

    /// <summary>
    /// オブジェクトがアクティブになった時によばれる
    /// </summary>
    void OnEnable()
    {
        if (userAdData.useAdMobBanner)
        {
            adMobManager.ShowBanner(AdMobManager.BANNER.BOTTOM,true);
        }
        else
        {
            nendAdController.ShowBottomBanner(true);
        }
        userAdData.OnShowAdBanner();
    }

    /// <summary>
    /// オブジェクトが非アクティブになった時によばれる
    /// </summary>
    void OnDisable()
    {
        adMobManager.ShowBanner(AdMobManager.BANNER.BOTTOM,false);
        nendAdController.ShowBottomBanner(false);
    }
}

