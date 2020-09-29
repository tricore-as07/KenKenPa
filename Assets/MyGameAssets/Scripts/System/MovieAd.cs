using UnityEngine;
using UnityEngine.Advertisements;

/// <summary>
/// 動画広告
/// </summary>
public class MovieAd : MonoBehaviour, IUnityAdsListener
{
    [SerializeField] string placementID　= default;             //動画広告のID
    [SerializeField] GameObject countDown = default;            //カウントダウンのオブジェクト
    [SerializeField] GameObject bgmObject = default;            //BGMを再生するオブジェクト

    /// <summary>
    /// オブジェクトがアクティブになった時に呼ばれる
    /// </summary>
    void OnEnable()
    {
        bgmObject.SetActive(false);
        Show();
    }

    /// <summary>
    /// 動画広告を表示する
    /// </summary>
    public void Show()
    {
        //自分をリスナーに追加する
        Advertisement.AddListener(this);
        if(Advertisement.IsReady(placementID))
        {
            Advertisement.Show(placementID);
        }
    }

    /// <summary>
    /// UnityAdsの広告が表示可能になった時に呼ばれる
    /// </summary>
    /// <param name="argPlacementId">表示可能になった広告のID</param>
    public void OnUnityAdsReady(string argPlacementId)
    {
        //あらかじめ指定してある広告のIDが表示可能になったら
        if(argPlacementId == placementID)
        {
            Advertisement.Show(argPlacementId);
        }
    }

    /// <summary>
    /// UnityAdsがエラーを出したら呼ばれる
    /// </summary>
    /// <param name="errorMessage">エラーメッセージ</param>
    public void OnUnityAdsDidError(string errorMessage)
    {
        Debug.LogWarning(errorMessage);
        //自分をリスナーから解除
        Advertisement.RemoveListener(this);
    }

    /// <summary>
    /// UnityAdsの広告を再生し始めたら呼ばれる
    /// </summary>
    /// <param name="argPlacementId">再生された広告のID</param>
    public void OnUnityAdsDidStart(string argPlacementId)
    {
        Debug.Log("The ad started playing.");
    }

    /// <summary>
    /// UnityAdsの広告を再生し終えたら呼ばれる
    /// </summary>
    /// <param name="argPlacementId">再生された広告のID</param>
    /// <param name="showResult">どのように広告が終了したか</param>
    public void OnUnityAdsDidFinish(string argPlacementId, ShowResult showResult)
    {
        if(argPlacementId == placementID)
        {
            //カウントダウンを開始
            countDown.SetActive(true);
            //自分をリスナーから解除
            Advertisement.RemoveListener(this);
            //自分を非アクティブに
            gameObject.SetActive(false);
            bgmObject.SetActive(true);
        }
    }
}