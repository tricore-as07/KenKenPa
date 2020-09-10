using UnityEngine;
using System.Collections.Generic;

/// <summary>
/// ステージの生成をするクラス
/// </summary>
public class StageCreater : MonoBehaviour
{
    [SerializeField] StageSettingData stageSettingData = default;                   //ステージの設定データ
    [SerializeField] GameObject objectsGroupPrefab = default;                       //ObjectsGroupのプレハブ
    [SerializeField] GameObject objectsPrefab = default;                            //１歩分のオブジェクトのプレハブ
    [SerializeField] GameObject stagePrefab = default;                              //ステージのプレハブ
    [SerializeField] GameObject backgroundGroupPrefab = default;                    //背景オブジェクトをまとめるオブジェクトのプレハブ
    [SerializeField]List<GameObject> backgroundPrefabs = new List<GameObject>();    //背景のプレハブのリスト
    [SerializeField] List<GameObject> hitObjectPrefabs = new List<GameObject>();    //当たりのオブジェクトのプレハブ
    [SerializeField] List<GameObject> notHitObjectPrefabs = new List<GameObject>(); //当たりで入力できない時のオブジェクトのプレハブ
    [SerializeField] int backgroundOnjectNum = default;                             //背景オブジェクトの数
    GameObject stage = default;                                                     //ステージ関連のオブジェクトの親に設定するためのもの
    GameObject backGround = default;                                                //背景オブジェクトをまとめるオブジェクト
    Vector3 DepthPosition;                                                          //ステージ生成時の奥行きの位置
    Vector3 backgroundPutPos;                                                       //背景を設置するポジション
    const int objectRotateNum = 12;                                                 //回転角度の違いを１２分にする

    /// <summary>
    /// オブジェクトがアクティブになった時によばれる
    /// </summary>
    void OnEnable()
    {
        DepthPosition = Vector3.zero;    //奥行きをリセット
        if(stage == null)
        {
            //自分と同じ親を設定してプレハブを作成
            stage = Instantiate(stagePrefab,transform.parent);
        }
        if (backGround == null)
        {
            //自分と同じ親を設定してプレハブを作成
            backGround = Instantiate(backgroundGroupPrefab, transform.parent);
        }
        //オブジェクトを作った回数
        int createObjectsCount = 0;
        var startObjectsGroupData = stageSettingData.StartObjectsGroupDatas.GetEnumerator();
        startObjectsGroupData.Reset();
        while (startObjectsGroupData.MoveNext())
        {
            createObjectsCount++;
            CreateObjectsGroup(startObjectsGroupData.Current);
        }
        //ループする回数
        int loopNum = stageSettingData.GenerateObjectsGroupNum - createObjectsCount;
        for (var i = 0; i < loopNum; i++)
        {
            var objectsGroupData = RandomWithWeight.Lottery<ObjectsGroupData>(stageSettingData.ObjectsGroupDatas);
            CreateObjectsGroup(objectsGroupData);
        }
        //背景オブジェクトの生成
        backgroundPutPos = new Vector3(0,0,0);
        for(var i = 0; i < backgroundOnjectNum; i++)
        {
            CreateBackground();
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
        //オブジェクトデータのEnumeratorを取得
        var objectData = objectsGroupData.ObjectsDatas.GetEnumerator();
        objectData.Reset();
        while(objectData.MoveNext())
        {
            CreateObjects(objectData.Current, objectsGroup, depth);
            depth += new Vector3(0f, 0f, stageSettingData.ObjectDistance);
            
        }
        DepthPosition += new Vector3(0f, 0f, stageSettingData.ObjectDistance * objectsGroupData.ObjectsNum);
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
        CreateObjectOfObjectType(objectsData.RightObjectType, objects.transform.GetChild(StageConstants.rightNum));
        CreateObjectOfObjectType(objectsData.CenterObjectType, objects.transform.GetChild(StageConstants.centerNum));
        CreateObjectOfObjectType(objectsData.LeftObjectType, objects.transform.GetChild(StageConstants.leftNum));
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
                    //オブジェクトを回転させるローテーションを作成
                    Vector3 rot = new Vector3(0f,Random.Range(0, objectRotateNum) * 360 / objectRotateNum, 0f);
                    var randomNum = Random.Range(0, hitObjectPrefabs.Count + objectRotateNum);
                    //ランダムで生成した数が設定されているプレハブの数の範囲内だったら
                    if(randomNum < hitObjectPrefabs.Count)
                    {
                        var obj = Instantiate(hitObjectPrefabs[randomNum], parent);
                        obj.SetActive(false);
                        obj = Instantiate(notHitObjectPrefabs[randomNum], parent);
                    }
                    //範囲外の場合は正円じゃないプレハブを回転させる
                    else
                    {
                        var obj = Instantiate(hitObjectPrefabs[hitObjectPrefabs.Count - 1], parent);
                        obj.SetActive(false);
                        obj.transform.eulerAngles = rot;
                        obj = Instantiate(notHitObjectPrefabs[hitObjectPrefabs.Count - 1], parent);
                        obj.transform.eulerAngles = rot;
                    }

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

    /// <summary>
    /// 背景を作成する
    /// </summary>
    public void CreateBackground()
    {
        var backgroundObj = GetRandomBackgroundPrefab();
        backgroundObj = Instantiate(backgroundObj, backGround.transform);
        backgroundObj.transform.position = backgroundPutPos;
        const int backgroundDist = 30;  //背景オブジェクトの間隔
        backgroundPutPos += new Vector3(0, 0, backgroundDist);
    }

    /// <summary>
    /// 背景のプレハブをランダムに取得する
    /// </summary>
    /// <returns>ランダムに抽出された背景用プレハブ</returns>
    GameObject GetRandomBackgroundPrefab()
    {
        return backgroundPrefabs[UnityEngine.Random.Range(0, backgroundPrefabs.Count)];
    }
}
