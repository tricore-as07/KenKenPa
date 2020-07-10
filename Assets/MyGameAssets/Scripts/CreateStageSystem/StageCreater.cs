using UnityEngine;

/// <summary>
/// ステージの生成をするクラス
/// </summary>
public class StageCreater : MonoBehaviour
{
    [SerializeField] StageSettingData stageSettingData = null;      //ステージの設定データ
    [SerializeField] GameObject objectsGroupPrefab = null;          //ObjectsGroupのプレハブ
    [SerializeField] GameObject objectsPrefab = null;               //１歩分のオブジェクトのプレハブ
    GameObject stage = null;                                        //ステージ関連のオブジェクトの親に設定するためのもの
    Vector3 DepthPosition;                                          //ステージ生成時の奥行きの位置
    
    /// <summary>
    /// 最初に行う処理
    /// </summary>
    void Start()
    {
        stage = GameObject.FindGameObjectWithTag("Stage");
        for (var i = 0; i < stageSettingData.GenerateObjectsGroupNum; i++)
        {
            var objectsGroupData = RandomWithWeight.Lottery<ObjectsGroupData>(stageSettingData.ObjectsGroupDatas);
            CreateObjectsGroup(objectsGroupData);
        }
    }

    /// <summary>
    /// オブジェクトグループを追加で作成する
    /// </summary>
    public void AddObjectsGroup()
    {
        var objectsGroupData = RandomWithWeight.Lottery<ObjectsGroupData>(stageSettingData.ObjectsGroupDatas);
        CreateObjectsGroup(objectsGroupData);
    }

    /// <summary>
    /// 指定歩数分のオブジェクトグループを作成する
    /// </summary>
    /// <param name="objectsGroupData">生成するオブジェクトグループのデータ</param>
    void CreateObjectsGroup(ObjectsGroupData objectsGroupData)
    {
        //オブジェクトグループを１つ作成
        var objectsGroup = Instantiate(objectsGroupPrefab, stage.transform);
        objectsGroup.transform.localPosition += DepthPosition;
        //データの数だけ１歩分のオブジェクトを作成
        var depth = new Vector3(0f,0f,0f);
        foreach (var objectsData in objectsGroupData.ObjectsDatas)
        {
            CreateObjects(objectsData, objectsGroup, depth);
            depth += new Vector3(0f, 0f, stageSettingData.ObjectDistance);
        }
        DepthPosition += new Vector3(0f, 0f, stageSettingData.ObjectDistance * objectsGroupData.ObjectsDatas.Count);
    }

    /// <summary>
    /// １歩分のオブジェクトを作成する
    /// </summary>
    /// <param name="objectsData">１歩分のオブジェクトのデータ</param>
    /// <param name="parent">親に設定するオブジェクト</param>
    void CreateObjects(ObjectsData objectsData,GameObject parent, Vector3 depth)
    {
        var objects = Instantiate(objectsPrefab, parent.transform);
        objects.transform.localPosition += depth;
        CreateObjectOfObjectType(objectsData.rightObjectType, objects.transform.GetChild(StageConstants.rightNum));
        CreateObjectOfObjectType(objectsData.centerObjectType, objects.transform.GetChild(StageConstants.centerNum));
        CreateObjectOfObjectType(objectsData.leftObjectType, objects.transform.GetChild(StageConstants.leftNum));
    }

    /// <summary>
    /// 指定された種類のオブジェクトを作成する
    /// </summary>
    /// <param name="objectType">オブジェクトの種類</param>
    /// <param name="parent">親に設定するオブジェクト</param>
    void CreateObjectOfObjectType(ObjectType objectType,Transform parent)
    {
        switch(objectType)
        {
            //当たりのオブジェクトを生成する
            case ObjectType.HitObject:
                {
                    Instantiate(stageSettingData.HitObjectPrefab, parent);
                    break;
                }
            //外れのオブジェクトを作成する
            case ObjectType.OutObject:
                {
                    Instantiate(stageSettingData.OutObjectPrefab, parent);
                    break;
                }
        }
    }
}
