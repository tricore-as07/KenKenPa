using UnityEngine;

/// <summary>
/// 丸のUIを生成する
/// </summary>
public class CreateCircleUI : MonoBehaviour
{
    //丸の種類
    enum CircleType
    {
        SingleCircleNum,
        DoubleCircleNum,
        Max
    }
    [SerializeField] GameObject[] circleObjects = new GameObject[(int)CircleType.Max];      //丸のオブジェクトの配列
    [SerializeField] int createCircleNum = default;                                         //作成する個数
    [SerializeField] int AllowContinuityNum = default;                                      //連続を許す数
    GameObject tempCircle = default;                                                        //一時的に生成したオブジェクトを保存する                                                       
    CircleType createdType = CircleType.Max;                                                //生成したオブジェクトの種類
    int continuityCreateNum = 0;                                                            //連続作成した数

    /// <summary>
    /// 最初に行う処理
    /// </summary>
    void Start()
    {
        float halfScreenHeight = Screen.height / 2;
        //画面の上から画面の縦幅の半分上から生成を開始する
        Vector3 pos = halfScreenHeight * Vector3.up;
        //画面からはみ出ている部分も合わせてスクリーン２枚分作成
        for (int i = 0; i < createCircleNum * 2; i++)
        {
            //連続して同じオブジェクトが生成された回数が許容回数を超えたら
            if(continuityCreateNum >= AllowContinuityNum)
            {
                if(createdType == CircleType.SingleCircleNum)
                {
                    //連続して生成されたものと違うものを生成
                    CreateCircleObject(CircleType.DoubleCircleNum);
                }
                else if(createdType == CircleType.DoubleCircleNum)
                {
                    //連続して生成されたものと違うものを生成
                    CreateCircleObject(CircleType.SingleCircleNum);
                }
            }
            //連続して同じオブジェクトが生成された回数が許容回数以内のとき
            else
            {
                int value = Random.Range(0, (int)CircleType.Max);
                CircleType type = (CircleType)value;
                CreateCircleObject(type);
            }
            //生成したオブジェクトのポジションの設定
            tempCircle.transform.position = pos;
            tempCircle.transform.position += Vector3.right * Screen.width / 2;
            //次に生成するオブジェクトの位置を設定
            pos += (Screen.height / createCircleNum) * Vector3.down;
        }
    }

    /// <summary>
    /// 丸のオブジェクトを生成する
    /// </summary>
    /// <param name="type"></param>
    void CreateCircleObject(CircleType type)
    {
        tempCircle = Instantiate(circleObjects[(int)type], transform);
        //今作成したオブジェクトの種類と一つ前に作成したオブジェクトの種類が同じ時
        if (createdType == type)
        {
            continuityCreateNum++;
        }
        else
        {
            continuityCreateNum = 0;
        }
        createdType = type;
    }
}
