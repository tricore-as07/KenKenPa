using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// ステージの設定データ
/// </summary>
[CreateAssetMenu]
public class StageSettingData : ScriptableObject
{
    public int objectDistance = 0;
    public GameObject hitObjectPrefab = null;           //当たりのオブジェクトのプレハブ
    public GameObject outObjectPrefab = null;           //外れのオブジェクトのプレハブ
    public List<ObjectGroupData> objectsGroupDatas = new List<ObjectGroupData>();  //オブジェクトグループのデータのリスト
}