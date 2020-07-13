using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 指定歩数分のオブジェクトグループのデータ
/// </summary>
[CreateAssetMenu]
public class ObjectsGroupData : ScriptableObject, IWeight
{
    [SerializeField] int weight = default;                                              //生成される確率の重み
    public int Weight => weight;                                                        //外部に公開するためのプロパティ
    [SerializeField] List<ObjectsData> objectsDatas = new List<ObjectsData>();          //ステージのデータのリスト
    public IEnumerable<ObjectsData> ObjectsDatas => objectsDatas;                       //リストを外部に公開するためのプロパティ
    public int ObjectsNum => objectsDatas.Count;                                        //外部に公開するためのプロパティ
}

/// <summary>
/// オブジェクトの種類
/// </summary>
public enum ObjectType
{
    HitObject,
    OutObject
}

/// <summary>
/// １歩分のオブジェクトのデータ
/// </summary>
[System.Serializable]
public class ObjectsData
{
    [SerializeField] ObjectType rightObjectType = default;
    public ObjectType RightObjectType => rightObjectType;
    [SerializeField] ObjectType centerObjectType = default;
    public ObjectType CenterObjectType => centerObjectType;
    [SerializeField] ObjectType leftObjectType = default;
    public ObjectType LeftObjectType => leftObjectType;
}