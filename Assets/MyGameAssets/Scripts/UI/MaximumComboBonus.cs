using System.Collections.Generic;
using UnityEngine;
using TMPro;

/// <summary>
/// 最大コンボボーナスの処理
/// </summary>
public class MaximumComboBonus : MonoBehaviour
{
    [SerializeField] List<ComboMaterialUiSetting> comboMaterialSettings = default;          //コンボ数によってマテリアルを設定するリスト
    [SerializeField ] TextMeshProUGUI text;                                                 //テキスト
    [SerializeField ] TextMeshProUGUI timeText;                                             //追加する時間のテキスト

    /// <summary>
    /// オブジェクトがアクティブになった時に呼ばれる
    /// </summary>
    void OnEnable()
    {
        foreach (var comboMaterialSetting in comboMaterialSettings)
        {
            //最大コンボ数が設定にあるコンボ数より多ければマテリアルを変更
            if (comboMaterialSetting.ComboNum <= ComboCounter.MaxComboCount)
            {
                text.fontMaterial = comboMaterialSetting.Mat;
                timeText.fontMaterial = comboMaterialSetting.Mat;
            }
            //最大コンボ数が設定にあるコンボ数より小さければ設定するマテリアルを探すのを終了
            else
            {
                break;
            }
        }
    }
}
