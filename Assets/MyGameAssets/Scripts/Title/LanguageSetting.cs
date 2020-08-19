using UnityEngine;
using I2.Loc;
using TMPro;

/// <summary>
/// 言語設定
/// </summary>
public class LanguageSetting : MonoBehaviour
{
    /// <summary>
    /// 設定言語が変更された時に呼ばれる
    /// </summary>
    public void OnChangeLanguage(TMP_Dropdown change)
    {
        if(change.value == 0)
        {
            LocalizationManager.CurrentLanguage = "Japanese";
        }
        else if (change.value == 1)
        {
            LocalizationManager.CurrentLanguage = "English";
        }
    }
}
