using UnityEngine.Advertisements;
using UnityEngine;

/// <summary>
/// UnityAdsの初期化処理をする
/// </summary>
public class UnityAdsInitizer : MonoBehaviour
{
    [SerializeField] string gameId = default;         //UnityAdsのGameID

    /// <summary>
    /// スクリプトのインスタンスがロードされたときに呼ばれる
    /// </summary>
    void Awake()
    {
        Advertisement.Initialize(gameId);
    }
}
