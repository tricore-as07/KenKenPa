using UnityEngine;

/// <summary>
/// プレイヤーに関するエフェクトを生成する
/// </summary>
public class PlayerEffectCreater : MonoBehaviour
{
    [SerializeField] Transform rightObj = default;      //右入力の位置（エフェクトの生成に使用）
    [SerializeField] Transform centerObj = default;     //中央入力の位置（エフェクトの生成に使用）
    [SerializeField] Transform leftObj = default;       //左入力の位置（エフェクトの生成に使用）
    [SerializeField] GameObject correctEffect = default;//正解を選んだ時のエフェクト

    /// <summary>
    /// 正解のエフェクトを生成する
    /// </summary>
    /// <param name="correctNum">選んだ正解の要素数</param>
    public void CreateCorrectEffect(int correctNum)
    {
        //if (correctNum == StageConstants.rightNum)
        //{
        //    Instantiate(correctEffect,rightObj);
        //}
        //else if (correctNum == StageConstants.centerNum)
        //{
        //    Instantiate(correctEffect, centerObj);
        //}
        //else if (correctNum == StageConstants.leftNum)
        //{
        //    Instantiate(correctEffect, leftObj);
        //}
    }
}
