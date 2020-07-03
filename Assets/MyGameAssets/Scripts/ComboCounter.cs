using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// コンボをカウントするクラス
/// </summary>
public class ComboCounter : MonoBehaviour
{
    int comboCount;


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
