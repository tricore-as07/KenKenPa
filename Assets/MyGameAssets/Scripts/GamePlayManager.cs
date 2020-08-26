using UnityEngine;

/// <summary>
/// ゲームプレイシーンの管理をするクラス
/// </summary>
public class GamePlayManager : MonoBehaviour
{
    [SerializeField] GameObject gamePlayObject = default;       //ゲームをプレイする際のオブジェクト
    [SerializeField] GameObject fakeLoadObject = default;       //フェイクロードのオブジェクト
    [SerializeField] float fakeLoadTime = default;              //フェイクロードを表示しておく時間
    [SerializeField] Timer timer = default;                     //タイマークラス
    [SerializeField] FadeOutCanvas fadeOutCanvas = default;     //フェードアウトをするキャンバス
    [SerializeField] GameObject inputObject = default;
    float fakeLoadTimeCount;                                    //フェークロードを表示している時間をカウントする

    /// <summary>
    /// オブジェクトが非アクティブになった時によばれる
    /// </summary>
    void OnDisable()
    {
        StopGamePlay();
        fakeLoadTimeCount = 0;
        fakeLoadObject.SetActive(true);
        inputObject.SetActive(false);
    }

    /// <summary>
    /// 毎フレーム行う処理
    /// </summary>
    void Update()
    {
        fakeLoadTimeCount += Time.deltaTime;
        if (fakeLoadTimeCount >= fakeLoadTime)
        {
            fadeOutCanvas.StartFadeOut();
        }
    }

    /// <summary>
    /// ゲームプレイをスタートする時に呼ぶ
    /// </summary>
    public void StartGamePlay()
    {
        timer.StartCountDown();
        fakeLoadObject.SetActive(false);
        inputObject.SetActive(true);
    }

    /// <summary>
    /// ゲームに必要なオブジェクトをアクティブにする時に呼ぶ
    /// </summary>
    public void SetActiveGamePlayObject()
    {
        gamePlayObject.SetActive(true);
    }

    /// <summary>
    /// ゲームをストップさせる時に呼ぶ
    /// </summary>
    void StopGamePlay()
    {
        gamePlayObject.SetActive(false);
        fakeLoadObject.SetActive(true);
    }
}
