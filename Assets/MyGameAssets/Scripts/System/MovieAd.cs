using UnityEngine;
using UnityEngine.Advertisements;

/// <summary>
/// 動画広告
/// </summary>
public class MovieAd : MonoBehaviour
{
    [SerializeField] string placementID　= default;            //動画広告のID

    /// <summary>
    /// オブジェクトがアクティブになった時に呼ばれる
    /// </summary>
    void OnEnable()
    {
        Show();
    }

    /// <summary>
    /// 動画広告を表示する
    /// </summary>
    public void Show()
    {
        //指定されたIDの準備が出来ているか確認する
        if (Advertisement.IsReady(placementID))
        {
            Advertisement.Show(placementID);
        }
    }
}