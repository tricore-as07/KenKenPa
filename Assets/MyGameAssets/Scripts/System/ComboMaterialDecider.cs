using UnityEngine;
using TMPro;
using System.Collections.Generic;
using I2.Loc;

/// <summary>
/// コンボのマテリアルを決定する
/// </summary>
public class ComboMaterialDecider : MonoBehaviour
{
    bool isNeedChangeMaterial;                                              //マテリアルを変更したかどうが
    public bool IsNeedChangeMaterial => isNeedChangeMaterial;               //外部に公開するためのプロパティ
    Material nextMaterial;                                                  //変更するマテリアル
    [SerializeField] TextMeshProUGUI text;                                  //コンボを表示するテキスト
    string comboBackText;                                                   //コンボの後ろに表示する文字列
    [SerializeField] List<ComboMaterialUiSetting> comboMaterialSettings     //コンボ数によってマテリアルを設定するリスト
        = new List<ComboMaterialUiSetting>();

    /// <summary>
    /// オブジェクトがアクティブになった時に呼ばれる
    /// </summary>
    void OnEnable()
    {
        comboBackText = LocalizationManager.GetTranslation("Combo_Back");
        text.text = "";
    }

    /// <summary>
    /// コンボが追加された時に呼ばれる
    /// </summary>
    public void OnAddCombo()
    {
        isNeedChangeMaterial = false;
        //設定されているコンボ数より今のコンボ数が多かったらマテリアルを指定されているものに変更する
        foreach (var comboMaterialSetting in comboMaterialSettings)
        {
            if (comboMaterialSetting.ComboNum <= ComboCounter.ComboCount)
            {
                if (comboMaterialSetting.ComboNum == ComboCounter.ComboCount)
                {
                    nextMaterial = comboMaterialSetting.Mat;
                    isNeedChangeMaterial = true;
                    break;
                }
                continue;
            }
        }
        //マテリアルを変更する必要がなかったら
        if(!isNeedChangeMaterial)
        {
            text.text = ComboCounter.ComboCount.ToString() + comboBackText;
        }
    }

    /// <summary>
    /// コンボを失敗した時に呼ぶ
    /// </summary>
    public void OnMissCombo()
    {
        text.text = "";
    }


    /// <summary>
    /// マテリアルを変更する
    /// </summary>
    public void ChangeMaterial()
    {
        isNeedChangeMaterial = false;
        text.fontMaterial = nextMaterial;
        text.text = ComboCounter.ComboCount.ToString() + comboBackText;
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