using UnityEngine;
using VMUnityLib;

/// <summary>
/// ユーザーの広告に関する情報
/// </summary>
public sealed class UserAdData : SingletonMonoBehaviour<UserAdData>
{
    public bool useAdMobBanner { get; private set; }            //バナー広告にAdMobを使うかどうか
    const string useAdMobBannerKey = "UseAdMobBanner";          //バナー広告にAdMobを使うかどうかを取得するためのキー
    int showdBannerCount;                                       //バナーを何回表示したかのカウント（切り替えに使うもの）
    const string showdBannerCountKey = "ShowdBannerCount";      //バナーを何回表示したかのカウントを取得するためのキー
    [SerializeField] int switchingAdNum = default;              //広告を切り替える回数

    /// <summary>
    /// スクリプトのインスタンスがロードされたときに呼ばれる
    /// </summary>
    void Awake()
    {
        useAdMobBanner = SaveDataHelper.GetBool(useAdMobBannerKey, true);
        showdBannerCount = PlayerPrefs.GetInt(showdBannerCountKey, 0);
    }

    /// <summary>
    /// バナーの広告を表示した時に呼ばれる
    /// </summary>
    public void OnShowAdBanner()
    {
        showdBannerCount++;
        if(showdBannerCount >= switchingAdNum)
        {
            useAdMobBanner = !useAdMobBanner;
        }
    }

    /// <summary>
    /// アプリケーションが終了する前に呼ばれる
    /// </summary>
    void OnApplicationQuit()
    {
        SaveDataHelper.SetBool(useAdMobBannerKey, useAdMobBanner);
        PlayerPrefs.SetInt(showdBannerCountKey, showdBannerCount);
    }
}
