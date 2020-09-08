using UnityEngine;
using I2.Loc;
using TMPro;

//言語の種類
public enum LanguageType
{
    Japanese = 0,
    English  = 1 
}

/// <summary>
/// 言語設定
/// </summary>
public class LanguageSetting : MonoBehaviour
{
    [SerializeField] TMP_Dropdown dropdown;

    /// <summary>
    /// スクリプトのインスタンスがロードされた時に呼ばれる
    /// </summary>
    void Awake()
    {
        if(LocalizationManager.CurrentLanguage == LanguageType.Japanese.ToString())
        {
            dropdown.value = 0;
        }
        else if(LocalizationManager.CurrentLanguage == LanguageType.English.ToString())
        {
            dropdown.value = 1;
        }
    }

    /// <summary>
    /// 設定言語が変更された時に呼ばれる
    /// </summary>
    public void OnChangeLanguage(TMP_Dropdown change)
    {
        if(change.value == (int)LanguageType.Japanese)
        {
            LocalizationManager.CurrentLanguage = LanguageType.Japanese.ToString();
        }
        else if (change.value == (int)LanguageType.English)
        { 
            LocalizationManager.CurrentLanguage = LanguageType.English.ToString();
        }
    }
}
