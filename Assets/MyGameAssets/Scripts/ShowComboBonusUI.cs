using UnityEngine;
using I2.Loc;
using TMPro;

/// <summary>
/// コンボボーナスのUIを表示する
/// </summary>
public class ShowComboBonusUI : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI meshPro;
    [SerializeField] float showTime;
    string timeBack;

    /// <summary>
    /// ボーナスタイムをセット
    /// </summary>
    /// <param name="time">セットする時間</param>
    public void SetBonusTime(int time)
    {
        meshPro.text = "+" + time.ToString() + timeBack;
    }

    /// <summary>
    /// オブジェクトがアクティブになった時に呼ばれる
    /// </summary>
    void OnEnable()
    {
        Invoke("ShowStop", showTime);
        timeBack = LocalizationManager.GetTranslation("Time_Back");
    }

    void ShowStop()
    {
        gameObject.SetActive(false);
    }
}
