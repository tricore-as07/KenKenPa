using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 入力間の受付時間をコンボ数で管理するための設定データ
/// </summary>
[CreateAssetMenu]
public class InputIntervalSettingData : ScriptableObject
{
    [SerializeField] List<InputIntervalSetting> inputIntervalSettings = new List<InputIntervalSetting>();           ///入力間の受付可能になるまでの時間の設定のリスト
    public IEnumerable<InputIntervalSetting> InputIntervalSettings => inputIntervalSettings;                        //外部に公開するためのプロパティ
    [SerializeField] List<InputIntervalSetting> startInputIntervalSettings = new List<InputIntervalSetting>();      ///ゲーム開始時の入力間の受付可能になるまでの時間の設定のリスト
    public IEnumerable<InputIntervalSetting> StartInputIntervalSettings => startInputIntervalSettings;              //外部に公開するためのプロパティ
}

/// <summary>
/// 入力間の受付可能になるまでの時間をコンボ毎に設定する
/// </summary>
/// NOTE : orimoto ここで設定されているコンボ数以下の時にintervalTimeの時間分のインターバルを設ける
[System.Serializable]
public class InputIntervalSetting
{
    [SerializeField]int comboNum = default;                         //制限を加えるコンボ数
    public int ComboNum => comboNum;                                //外部に公開するためのプロパティ
    [SerializeField]float intervalTime = default;                   //入力可能になるまでの時間
    public float IntervalTime => intervalTime;                      //外部に公開するためのプロパティ
}
