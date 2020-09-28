using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 長方形のオブジェクトを作成する
/// </summary>
public class CreateRectUI : MonoBehaviour
{
    [SerializeField] List<GameObject> rectObject = default;           //長方形のオブジェクトのリスト
    [SerializeField] List<GameObject> rectObjectParent = default;     //長方形のオブジェクトの親に設定するオブジェクトのリスト
    [SerializeField] int createRectNum = 0;                           //作成する個数

    /// <summary>
    /// 最初に行う処理
    /// </summary>
    void Start()
    {
        float halfScreenWidth = Screen.width / 2;
        //画面の左から画面の横幅の半分左から生成を開始する
        Vector3 pos = halfScreenWidth * Vector3.left;
        //一時的に生成したオブジェクトを保存する  
        for (int i = 0; i < createRectNum * 2; i++)
        {
            //オブジェクトの要素数
            int objNum = 0;
            foreach (var obj in rectObject)
            {
                var tempRect = Instantiate(obj, rectObjectParent[objNum].transform);
                //生成したオブジェクトのポジションの設定
                tempRect.transform.position = pos;
                tempRect.transform.position += Vector3.up * Screen.height / 2;
                objNum++;
            }
            //次に生成するオブジェクトの位置を設定
            pos += Vector3.right * (Screen.width / createRectNum);
        }
    }
}
