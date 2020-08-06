using UnityEngine;

/// <summary>
/// ゲームプレイシーンの管理をするクラス
/// </summary>
public class GamePlayManager : MonoBehaviour
{
    [SerializeField] GameObject gamePlayObject = default;       //ゲームをプレイする際のオブジェクト
    [SerializeField] GameObject fakeLoadObject = default;       //フェイクロードのオブジェクト
    [SerializeField] float fakeLoadTime = default;              //フェイクロードを表示しておく時間
    float fakeLoadTimeCount;                                    //フェークロードを表示している時間をカウントする


    void OnEnable()
    {
        GamePlayStop();
        fakeLoadTimeCount = 0;
    }

    void Update()
    {
        fakeLoadTimeCount += Time.deltaTime;
        if(fakeLoadTimeCount > fakeLoadTime)
        {
            GamePlayStart();
        }
    }

    /// <summary>
    /// ゲームをスタートする時に呼ぶ
    /// </summary>
    void GamePlayStart()
    {
        gamePlayObject.SetActive(true);
        fakeLoadObject.SetActive(false);
    }

    /// <summary>
    /// ゲームをストップさせる時に呼ぶ
    /// </summary>
    void GamePlayStop()
    {
        gamePlayObject.SetActive(false);
        fakeLoadObject.SetActive(true);
    }
}
