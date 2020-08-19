using UnityEngine;

/// <summary>
/// 設定ボタンに関する処理をする
/// </summary>
public class ConfigButton : MonoBehaviour
{
    [SerializeField] CanvasGroup titleCanvas = default;         //タイトルのUIをまとめたキャンバス
    [SerializeField] GameObject configCanvas = default;         //設定画面のUIをまとめたキャンバス

    /// <summary>
    /// 設定ボタンが押された時に呼ばれる
    /// </summary>
    public void OnClickConfigButton()
    {
        titleCanvas.interactable = false;
        configCanvas.SetActive(true);
    }

    /// <summary>
    /// 設定を閉じるボタンが押された時に呼ばれる
    /// </summary>
    public void OnClickConfigCloseButton()
    {
        titleCanvas.interactable = true;
        configCanvas.SetActive(false);
    }
}
