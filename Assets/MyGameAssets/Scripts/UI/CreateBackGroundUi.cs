using UnityEngine;

/// <summary>
/// 動く背景UIを作成する
/// </summary>
public class CreateBackGroundUi : MonoBehaviour
{
    [SerializeField] GameObject createUi = default;         //作成するUI
    [SerializeField] float moveTime = default;              //移動にかける時間
    [SerializeField] float createInterval = default;        //生成する間隔

}
