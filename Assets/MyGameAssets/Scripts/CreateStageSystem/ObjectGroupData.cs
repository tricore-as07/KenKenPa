using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 指定歩数分のオブジェクトグループのデータ
/// </summary>
[CreateAssetMenu]
public class ObjectGroupData : ScriptableObject
{
    [SerializeField] int generatingFrequency = 0;           //このステージデータの生成頻度
    public int GeneratingFrequency => generatingFrequency;  //外部に公開するためのプロパティ
    public List<ObjectsData> objectsDatas = new List<ObjectsData>();  //ステージのデータのリスト

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