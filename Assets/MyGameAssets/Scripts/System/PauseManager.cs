using UnityEngine;

/// <summary>
/// ポーズ関連の処理を管理する
/// </summary>
public class PauseManager : MonoBehaviour
{
    [SerializeField] PlayerInput input = default;           //プレイヤーのオブジェクト
    [SerializeField] GameObject pauseImage = default;       //ポーズする時に表示するオブジェクト
    [SerializeField] Timer timer = default;                 //タイマークラス
    [SerializeField] Animator animator = default;           //カウントダウンのアニメーター
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
            //カウントダウンしている時だけポーズする
            if(timer.IsCountDown)
            {
                isPause = true;
                timer.StopCountDown();
                pauseImage.SetActive(true);
                input.enabled = false;
                animator.speed = 0;
            }
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
                input.enabled = true;
                animator.speed = 1;
            }
        }
    }
}
