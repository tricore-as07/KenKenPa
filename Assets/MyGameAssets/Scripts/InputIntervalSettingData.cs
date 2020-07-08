using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 入力間の受付時間をコンボ数で管理するための設定データ
/// </summary>
[CreateAssetMenu]
public class InputIntervalSettingData : ScriptableObject
{
    public List<InputIntervalSetting> inputIntervalSettings = new List<InputIntervalSetting>(); ///入力間の受付可能になるまでの時間の設定のリスト
}

/// <summary>
/// 入力間の受付可能になるまでの時間をコンボ毎に設定する
/// </summary>
/// NOTE : orimoto ここで設定されているコンボ数以下の時にintervalTimeの時間分のインターバルを設ける
[System.Serializable]
public class InputIntervalSetting
{
    [SerializeField]int comboNum = 0;                               //制限を加えるコンボ数
    public int ComboNum => comboNum;                                //外部に公開するためのプロパティ
    [SerializeField]float intervalTime = 0.0f;                      //入力可能になるまでの時間
    public float IntervalTime => intervalTime;                      //外部に公開するためのプロパティ
}
