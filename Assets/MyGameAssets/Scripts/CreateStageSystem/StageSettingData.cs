using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// ステージの設定データ
/// </summary>
[CreateAssetMenu]
public class StageSettingData : ScriptableObject
{
    public int objectDistance = 0;                      //オブジェクト間の距離
    public int GenerateObjectsGroupNum = 0;             //生成するオブジェクトグループの数
    public GameObject hitObjectPrefab = null;           //当たりのオブジェクトのプレハブ
    public GameObject outObjectPrefab = null;           //外れのオブジェクトのプレハブ
    public List<ObjectsGroupData> objectsGroupDatas = new List<ObjectsGroupData>();  //オブジェクトグループのデータのリスト
}