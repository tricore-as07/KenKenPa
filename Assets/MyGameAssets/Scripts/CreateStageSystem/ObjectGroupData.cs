using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// ステージのデータ
/// </summary>
[System.Serializable]
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
/// オブジェクトのまとまりのデータ
/// </summary>
[System.Serializable]
public class ObjectsData
{
    public ObjectType rightObjectType;
    public ObjectType centerObjectType;
    public ObjectType leftObjectType;
}