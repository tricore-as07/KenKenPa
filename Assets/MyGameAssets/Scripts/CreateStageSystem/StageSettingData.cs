using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// ステージの設定データ
/// </summary>
[CreateAssetMenu]
public class StageSettingData : ScriptableObject
{
    [SerializeField] int objectDistance = 0;                      //オブジェクト間の距離
    public int ObjectDistance => objectDistance;                      //オブジェクト間の距離
    [SerializeField] int generateObjectsGroupNum = 0;             //生成するオブジェクトグループの数
    public int GenerateObjectsGroupNum => generateObjectsGroupNum;             //生成するオブジェクトグループの数
    [SerializeField] GameObject hitObjectPrefab = null;           //当たりのオブジェクトのプレハブ
    public GameObject HitObjectPrefab => hitObjectPrefab;           //当たりのオブジェクトのプレハブ
    [SerializeField] GameObject outObjectPrefab = null;           //外れのオブジェクトのプレハブ
    public GameObject OutObjectPrefab => outObjectPrefab;           //外れのオブジェクトのプレハブ
    [SerializeField] List<ObjectsGroupData> objectsGroupDatas = new List<ObjectsGroupData>();  //オブジェクトグループのデータのリスト
    public List<ObjectsGroupData> ObjectsGroupDatas => objectsGroupDatas;  //オブジェクトグループのデータのリスト
}