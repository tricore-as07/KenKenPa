using UnityEngine;

/// <summary>
/// フェイクロードシーンを管理する
/// </summary>
public class FakeLoadManager : MonoBehaviour
{
    [SerializeField] GameObject nativeAdObject = default;               //ネイティブ広告のオブジェクト
    [SerializeField] GameObject movieAdObject = default;                //動画広告のオブジェクト
    [SerializeField] int movieAdPlayNum;                                //動画広告を表示するプレイ回数
    const string key = "PlayNum";                                       //ゲームのプレイ回数を保存するためのキー
    int playNum;                                                        //プレイ回数

    /// <summary>
    /// オブジェクトがアクティブになった時に呼ばれる
    /// </summary>
    void OnEnable()
    {
        //プレイ回数を確認する
        playNum = PlayerPrefs.GetInt(key, 0);
        //動画広告を表示するプレイ回数だったら
        if (playNum % movieAdPlayNum == 0)
        {
            //動画広告の表示処理
            nativeAdObject.SetActive(false);
            movieAdObject.SetActive(true);
        }
        else
        {
            //ネイティブ広告の表示処理
            nativeAdObject.SetActive(true);
            movieAdObject.SetActive(false);
        }
    }

    /// <summary>
    /// オブジェクトが非アクティブになった時に呼ばれる
    /// </summary>
    void OnDisable()
    {
        //プレイ回数を一回増やして保存する
        playNum++;
        PlayerPrefs.SetInt(key, playNum);
    }
}
