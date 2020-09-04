using UnityEngine;
using I2.Loc;

/// <summary>
/// タイトルの画像を決める
/// </summary>
public class TitleImage : MonoBehaviour
{
    [SerializeField] GameObject titleImageJP = default;
    [SerializeField] GameObject titleImageEN = default;

    /// <summary>
    /// スクリプトのインスタンスがロードされた時に呼ばれる
    /// </summary>
    void Awake()
    {
        if (LocalizationManager.CurrentLanguage == "Japanese")
        {
            titleImageJP.SetActive(true);
            titleImageEN.SetActive(false);
        }
        else if (LocalizationManager.CurrentLanguage == "English")
        {
            titleImageJP.SetActive(false);
            titleImageEN.SetActive(true);
        }
    }

    /// <summary>
    /// 設定言語が変更された時に呼ばれる
    /// </summary>
    public void OnChangeLanguage()
    {
        if (LocalizationManager.CurrentLanguage == "Japanese")
        {
            titleImageJP.SetActive(true);
            titleImageEN.SetActive(false);
        }
        else if (LocalizationManager.CurrentLanguage == "English")
        {
            titleImageJP.SetActive(false);
            titleImageEN.SetActive(true);
        }
    }
}
