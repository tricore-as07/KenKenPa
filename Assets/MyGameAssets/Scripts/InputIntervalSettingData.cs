using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 入力間の受付可能になるまでの時間をコンボ数毎に設定する
/// </summary>
[CreateAssetMenu]
public class InputIntervalSettingData : ScriptableObject
{
    public List<InputIntervalSetting> inputIntervalSettings = new List<InputIntervalSetting>(); ///入力間の受付可能になるまでの時間の設定のリスト

    /// <summary>
    /// スクリプト開始時に行う処理
    /// </summary>
    private void Awake()
    {
        //設定されているリストをコンボ数を基準に昇順ソート
        //inputIntervalSettings.Sort((a,b) => (a.ComboNum - b.ComboNum));
    }
}

/// <summary>
/// 入力間の受付可能になるまでの時間をコンボ毎に設定する
/// </summary>
/// NOTE : orimoto ここで設定されているコンボ数以下の時にintervalTimeの時間分のインターバルを設ける
[System.Serializable]
public class InputIntervalSetting
{
    [SerializeField] int comboNum = 0;                          //制限を加えるコンボ数
    public int ComboNum { get{ return comboNum; } }             //上記のアクセス用の変数
    [SerializeField] float intervalTime = 0.0f;                 //入力可能になるまでの時間
    public float IntervalTime { get { return intervalTime; } }  //上記のアクセス用の変数
}
