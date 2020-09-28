using UnityEngine;

/// <summary>
/// 丸を動かす
/// </summary>
public class MoveCircleUI : MonoBehaviour
{
    [SerializeField] float oneTripTime = default;                   //1回の移動時間
    [SerializeField] int oneTripDistanceNum = default;              //1回に移動する画面分割数
    [SerializeField] float InterpolationNum = default;              //補間に使う値
    float nextMoveTime;                                             //次に動くまでの時間
    float halfScreenHeight = default;                               //画面の半分の大きさ
    float oneTripDistance;                                          //1回に移動する距離
    Vector3 targetPos;

    /// <summary>
    /// 最初に行う処理
    /// </summary>
    void Start()
    {
        halfScreenHeight = Screen.height / 2;
        oneTripDistance = Screen.height / oneTripDistanceNum;
        nextMoveTime = 0;
        targetPos = transform.position + new Vector3(0f, -oneTripDistance, 0f);
    }

    /// <summary>
    /// 毎フレーム行う処理
    /// </summary>
    void Update()
    {
        //下に自分を動かす
        nextMoveTime += Time.deltaTime;
        transform.position = Vector3.Lerp(transform.position, targetPos, InterpolationNum);
        if (nextMoveTime >= oneTripTime)
        {
            targetPos = transform.position + new Vector3(0f, -oneTripDistance, 0f);
            nextMoveTime = 0;
        }


        //画面から画面の半分以上下にあるなら
        if (transform.position.y < -halfScreenHeight)
        {
            //画面右端から画面の半分右に動かす
            transform.position += Vector3.up * (Screen.height * 2);
            targetPos += Vector3.up * (Screen.height * 2);
        }
    }
}
