using UnityEngine;
using TMPro;
using System.Collections.Generic;

/// <summary>
/// コンボのマテリアルを決定する
/// </summary>
public class ComboMaterialDecider : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI text;                                  //コンボを表示するテキスト
    [SerializeField] List<ComboMaterialUiSetting> comboMaterialSettings     //コンボ数によってマテリアルを設定するリスト
        = new List<ComboMaterialUiSetting>();

    /// <summary>
    /// コンボが追加された時に呼ばれる
    /// </summary>
    public void OnAddCombo()
    {
        //設定されているコンボ数より今のコンボ数が多かったらマテリアルを指定されているものに変更する
        foreach (var comboMaterialSetting in comboMaterialSettings)
        {
            if (comboMaterialSetting.ComboNum <= ComboCounter.ComboCount)
            {
                text.fontMaterial = comboMaterialSetting.Mat;
            }
            else
            {
                break;
            }
        }
    }
}

/// <summary>
/// コンボ数によってマテリアルを別々に設定する
/// </summary>
/// NOTE : orimoto ここで設定されているコンボ数以上で設定されているマテリアルを設定する
[System.Serializable]
public class ComboMaterialUiSetting
{
    [SerializeField] int comboNum = default;                        //コンボ数
    public int ComboNum => comboNum;                                //外部に公開するためのプロパティ
    [SerializeField] Material mat = default;                        //設定するマテリアル
    public Material Mat => mat;                                     //外部に公開するためのプロパティ
}