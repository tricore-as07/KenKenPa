using UnityEngine;
using I2.Loc;
using TMPro;
using System.Collections.Generic;

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
    [SerializeField] TMP_Dropdown dropdown = default;
    public static readonly Dictionary<LanguageType, string> Language = new Dictionary<LanguageType, string>
    {
        { LanguageType.Japanese,"Japanese" },
        { LanguageType.English,"English" }
    };

    /// <summary>
    /// スクリプトのインスタンスがロードされた時に呼ばれる
    /// </summary>
    void Awake()
    {
        if(LocalizationManager.CurrentLanguage == Language[LanguageType.Japanese])
        {
            dropdown.value = 0;
        }
        else if(LocalizationManager.CurrentLanguage == Language[LanguageType.English])
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
            LocalizationManager.CurrentLanguage = Language[LanguageType.Japanese];
        }
        else if (change.value == (int)LanguageType.English)
        { 
            LocalizationManager.CurrentLanguage = Language[LanguageType.English];
        }
    }
}
