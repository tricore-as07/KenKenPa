using UnityEngine;

/// <summary>
/// PlayerPrefsでデータを取得、保存する時のヘルパークラス
/// </summary>
public static class SaveDataHelper
{
    /// <summary>
    /// boolの値を取得する
    /// </summary>
    /// <param name="key">値と紐づけられている文字列</param>
    /// <param name="defalutValue">保存されていなかった場合に返ってくる値</param>
    /// <returns>取得した値</returns>
    public static bool GetBool(string key, bool defalutValue)
    {
        var value = PlayerPrefs.GetInt(key, defalutValue ? 1 : 0);
        return value == 1;
    }

    /// <summary>
    /// boolを保存する
    /// </summary>
    /// <param name="key">値と紐づけられている文字列</param>
    /// <param name="value">保存する値</param>
    public static void SetBool(string key, bool value)
    {
        PlayerPrefs.SetInt(key, value ? 1 : 0);
    }
}