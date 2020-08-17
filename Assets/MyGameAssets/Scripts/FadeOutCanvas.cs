using UnityEngine;

/// <summary>
/// キャンバスをフェードアウトさせる
/// </summary>
public class FadeOutCanvas : MonoBehaviour
{
    [SerializeField] CanvasGroup canvasGroup = default;     //キャンバスグループのコンポーネント
    [SerializeField] float fadeOutTime = 1.0f;              //フェードアウトにかける時間
    public float FadeOutTime => fadeOutTime;                //外部に公開するためのプロパティ
    [SerializeField] GamePlayManager gamePlayManager;       //ゲームプレイシーンを管理するクラス
    bool isStartFadeOut;                                    //フェードアウトを開始したかどうか
    [SerializeField] GameObject banner;
    [SerializeField] GameObject nendNative;

    /// <summary>
    /// オブジェクトがアクティブになった時によばれる
    /// </summary>
    void OnEnable()
    {
        isStartFadeOut = false;
        canvasGroup.alpha = 1;
        banner.SetActive(true);
        nendNative.SetActive(true);
    }

    /// <summary>
    /// フェードアウトを開始する
    /// </summary>
    public void StartFadeOut()
    {
        isStartFadeOut = true;
        gamePlayManager.SetActiveGamePlayObject();
        banner.SetActive(false);
        nendNative.SetActive(false);
    }

    /// <summary>
    /// 毎フレーム行う処理
    /// </summary>
    void Update()
    {
       if(isStartFadeOut)
        {
            canvasGroup.alpha -= Time.deltaTime / fadeOutTime;
            //フェードアウト終了した時（アルファが０より小さくなった時）
            if(canvasGroup.alpha <= 0)
            {
                isStartFadeOut = false;
                gamePlayManager.PlayGameStart();
            }
        }
    }
}
