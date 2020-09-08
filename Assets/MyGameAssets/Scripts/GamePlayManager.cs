using UnityEngine;
using VMUnityLib;

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
    float fakeLoadTimeCount;                                    //フェイクロードを表示している時間をカウントする
    bool callFakeLoad = false;                                  //フェイクロードを呼んだかどうか
    [SerializeField] SceneChanger changer;                      //シーンを変更するためのクラス
    [SerializeField] PlayerInput playerInput;                   //プレイヤーの入力を管理するクラス
    bool gameEnd;                                               //ゲーム終了したかどうか

    /// <summary>
    /// オブジェクトが非アクティブになった時によばれる
    /// </summary>
    void OnDisable()
    {
        StopGamePlay();
        fakeLoadTimeCount = 0;
        fakeLoadObject.SetActive(true);
        playerInput.enabled = true;
        callFakeLoad = false;
    }

    /// <summary>
    /// 毎フレーム行う処理
    /// </summary>
    void Update()
    {
        if(gameEnd)
        {
            if(Input.touchCount > 0)
            {
                OnTapAfterTimeLimit();
            }
        }
        if(callFakeLoad)
        {
            return;
        }
        fakeLoadTimeCount += Time.deltaTime;
        if (fakeLoadTimeCount >= fakeLoadTime)
        {
            callFakeLoad = true;
            fadeOutCanvas.StartFadeOut();
            SetActiveGamePlayObject();
        }
    }

    /// <summary>
    /// ゲームプレイをスタートする時に呼ぶ
    /// </summary>
    public void StartGamePlay()
    {
        timer.StartCountDown();
        fakeLoadObject.SetActive(false);
        playerInput.enabled = true;
    }

    /// <summary>
    /// ゲームに必要なオブジェクトをアクティブにする時に呼ぶ
    /// </summary>
    void SetActiveGamePlayObject()
    {
        gamePlayObject.SetActive(true);
        playerInput.enabled = false;
    }

    /// <summary>
    /// ゲームをストップさせる時に呼ぶ
    /// </summary>
    void StopGamePlay()
    {
        gamePlayObject.SetActive(false);
        fakeLoadObject.SetActive(true);
    }

    /// <summary>
    /// タイムリミットがきた時に呼ばれる
    /// </summary>
    public void OnTimeLimit()
    {
        playerInput.enabled = false;
        gameEnd = true;
    }

    /// <summary>
    /// タイムリミット後にタップされた時に呼ばれる
    /// </summary>
    void OnTapAfterTimeLimit()
    {
        changer.ChangeScene();
        gameEnd = false; 
    }
}
