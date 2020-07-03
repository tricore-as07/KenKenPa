using UnityEngine;

/// <summary>
/// コンボをカウントするクラス
/// </summary>
/// FIXME : orimoto MonoBehaviourを継承しない形に修正予定
public class ComboCounter : MonoBehaviour
{
    int comboCount;     //コンボをカウントする

    /// <summary>
    /// 最初に行う処理
    /// </summary>
    void Start()
    {
        comboCount = 0;
    }

    /// <summary>
    /// コンボを成功させた時に呼ぶ
    /// </summary>
    public void SuccessCombo()
    {
        comboCount++;
    }

    /// <summary>
    /// コンボを失敗した時に呼ぶ
    /// </summary>
    public void MissCombo()
    {
        comboCount = 0;
    }
}
