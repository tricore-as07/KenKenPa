using UnityEngine;
using VMUnityLib;
using System.Collections;

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
    [SerializeField] SceneChanger changer = default;            //シーンを変更するためのクラス
    [SerializeField] PlayerInput playerInput = default;         //プレイヤーの入力を管理するクラス
    bool gameEnd;                                               //ゲーム終了したかどうか
    [SerializeField] float endInputInterval = default;          //終了時の入力インターバル

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
    /// オブジェクトがアクティブになった時によばれる
    /// </summary>
    void OnEnable()
    {
        SetActiveGamePlayObject();
    }

    /// <summary>
    /// 毎フレーム行う処理
    /// </summary>
    void Update()
    {
        //ゲーム終了フラグが立っていて、画面をタップされたら
        if (gameEnd && (Input.touchCount > 0 || Input.anyKey))
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
        gamePlayObject.SetActive(true);
        fakeLoadObject.SetActive(true);
    }

    /// <summary>
    /// タイムリミットがきた時に呼ばれる
    /// </summary>
    public void OnTimeLimit()
    {
        playerInput.enabled = false;
        StartCoroutine(OnGameEnd());
    }

    /// <summary>
    /// ゲーム終了時に呼ばれる
    /// </summary>
    IEnumerator OnGameEnd()
    {
        yield return new WaitForSeconds(endInputInterval);
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
