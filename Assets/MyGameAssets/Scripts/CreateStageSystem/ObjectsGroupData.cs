using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 指定歩数分のオブジェクトグループのデータ
/// </summary>
[CreateAssetMenu]
public class ObjectsGroupData : ScriptableObject, IWeight
{
    [SerializeField] int weight = 0;                                        //生成される確率の重み
    public int Weight => weight;
    public List<ObjectsData> objectsDatas = new List<ObjectsData>();        //ステージのデータのリスト
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
    public ObjectType rightObjectType;
    public ObjectType centerObjectType;
    public ObjectType leftObjectType;
}