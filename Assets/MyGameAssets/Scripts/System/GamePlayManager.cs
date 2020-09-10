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
    bool endFakeLoad = false;                                   //フェイクロードが終了したかどうか
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
        endFakeLoad = false;
    }

    /// <summary>
    /// 毎フレーム行う処理
    /// </summary>
    void Update()
    {
        //ゲーム終了フラグが立っていて、画面をタップされたら
        if (gameEnd && Input.touchCount > 0)
        {
            OnTapAfterTimeLimit();
        }
        UpdateFakeLoad();
    }

    /// <summary>
    /// フェイクロードのアップデート処理
    /// </summary>
    void UpdateFakeLoad()
    {
        //フェイクロードが終了していたら
        if (endFakeLoad)
        {
            return;
        }
        fakeLoadTimeCount += Time.deltaTime;
        if (fakeLoadTimeCount >= fakeLoadTime)
        {
            //フェイクロードの表示終了処理
            endFakeLoad = true;
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
