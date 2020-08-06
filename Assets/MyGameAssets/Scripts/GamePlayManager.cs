using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// ゲームプレイシーンの管理をするクラス
/// </summary>
public class GamePlayManager : MonoBehaviour
{
    [SerializeField] List<GameObject> manageObject = new List<GameObject>();        //管理するオブジェクト

    /// <summary>
    /// ゲームをスタートする時に呼ばれる
    /// </summary>
    public void GameStart()
    {
        foreach (var obj in manageObject)
        {
            obj.SetActive(true);
        }
    }

    /// <summary>
    /// ゲームをストップさせる時に呼ばれる
    /// </summary>
    public void GameStop()
    {
        foreach (var obj in manageObject)
        {
            obj.SetActive(false);
        }
    }
}
