using UnityEngine;

/// <summary>
/// コンボをカウントするクラス
/// </summary>
/// FIXME : orimoto MonoBehaviourを継承しない形に修正予定
public class ComboCounter : MonoBehaviour
{
    public int ComboCount { get; private set; }     //コンボをカウントする

    /// <summary>
    /// 最初に行う処理
    /// </summary>
    void Start()
    {
        ComboCount = 0;
    }

    /// <summary>
    /// コンボを成功させた時に呼ぶ
    /// </summary>
    public void OnSuccessCombo()
    {
        ComboCount++;
    }

    /// <summary>
    /// コンボを失敗した時に呼ぶ
    /// </summary>
    public void OnMissCombo()
    {
        ComboCount = 0;
    }
}
