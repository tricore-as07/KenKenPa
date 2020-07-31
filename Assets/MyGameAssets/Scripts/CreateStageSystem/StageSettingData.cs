using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// ステージの設定データ
/// </summary>
[CreateAssetMenu]
public class StageSettingData : ScriptableObject
{
    [SerializeField] int objectDistance = default;                                                  //オブジェクト間の距離
    public int ObjectDistance => objectDistance;                                                    //外部に公開するためのプロパティ
    [SerializeField] int generateObjectsGroupNum = default;                                         //生成するオブジェクトグループの数
    public int GenerateObjectsGroupNum => generateObjectsGroupNum;                                  //外部に公開するためのプロパティ
    [SerializeField] GameObject hitObjectPrefab = default;                                          //当たりのオブジェクトのプレハブ
    public GameObject HitObjectPrefab => hitObjectPrefab;                                           //外部に公開するためのプロパティ
    [SerializeField] GameObject outObjectPrefab = default;                                          //外れのオブジェクトのプレハブ
    public GameObject OutObjectPrefab => outObjectPrefab;                                           //外部に公開するためのプロパティ
    [SerializeField] List<ObjectsGroupData> startObjectsGroupDatas = new List<ObjectsGroupData>();  //ゲーム開始時のオブジェクトグループのデータのリスト
    public IEnumerable<ObjectsGroupData> StartObjectsGroupDatas => startObjectsGroupDatas;          //リストを外部に公開するためのプロパティ
    [SerializeField] List<ObjectsGroupData> objectsGroupDatas = new List<ObjectsGroupData>();       //オブジェクトグループのデータのリスト
    public IEnumerable<ObjectsGroupData> ObjectsGroupDatas => objectsGroupDatas;                    //リストを外部に公開するためのプロパティ
}