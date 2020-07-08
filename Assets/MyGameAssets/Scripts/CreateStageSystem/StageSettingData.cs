using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// ステージの設定データ
/// </summary>
[CreateAssetMenu]
public class StageSettingData : ScriptableObject
{
    public List<ObjectGroupData> objectsGroupDatas = new List<ObjectGroupData>();  //オブジェクトグループのデータのリスト
}