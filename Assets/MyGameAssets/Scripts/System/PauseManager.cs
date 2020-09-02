using UnityEngine;

/// <summary>
/// ポーズ関連の処理を管理する
/// </summary>
public class PauseManager : MonoBehaviour
{
    [SerializeField] GameObject player = default;           //プレイヤーのオブジェクト
    [SerializeField] GameObject pauseImage = default;       //ポーズする時に表示するオブジェクト
    [SerializeField] Timer timer = default;                 //タイマークラス
    bool isPause;                                           //ポーズしているかどうか

    /// <summary>
    /// オブジェクトがアクティブになった時によばれる
    /// </summary>
    void OnEnable()
    {
        pauseImage.SetActive(false);
    }

    /// <summary>
    /// アプリケーションが閉じられたとき
    /// </summary>
    void OnApplicationPause(bool pauseStatus)
    {
        if(pauseStatus)
        {
            isPause = true;
            timer.StopCountDown();
            pauseImage.SetActive(true);
            player.GetComponent<PlayerInput>().enabled = false;
        }
    }

    /// <summary>
    /// 毎フレーム行う処理
    /// </summary>
    void Update()
    {
        if (isPause)
        {
            //タップ入力されたとき
            if(Input.touchCount > 0)
            {
                isPause = false;
                timer.StartCountDown();
                pauseImage.SetActive(false);
                player.GetComponent<PlayerInput>().enabled = true;
            }
        }
    }
}
