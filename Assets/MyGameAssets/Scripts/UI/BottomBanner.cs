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
#if USE_NEND
        if (userAdData.useAdMobBanner)
        {
            //AdMobの広告がテスト広告しか表示されないため、Nendのみに
            //adMobManager.ShowBanner(AdMobManager.BANNER.BOTTOM,true);
            nendAdController.ShowBottomBanner(true);
        }
        else
        {
            nendAdController.ShowBottomBanner(true);
        }
#endif
        userAdData.OnShowAdBanner();
    }

    /// <summary>
    /// オブジェクトが非アクティブになった時によばれる
    /// </summary>
    void OnDisable()
    {
#if USE_NEND
        adMobManager.ShowBanner(AdMobManager.BANNER.BOTTOM,false);
        nendAdController.ShowBottomBanner(false);
#endif

    }
}

