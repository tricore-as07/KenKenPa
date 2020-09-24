using UnityEngine;

/// <summary>
/// 動く背景UIを作成する
/// </summary>
/// /// TODO: orimoto 未実装
public class CreateBackGroundUi : MonoBehaviour
{
    [SerializeField] GameObject createUi = default;         //作成するUI
    [SerializeField] float createInterval = default;        //生成する間隔
    float time;

    void OnEnable()
    {
        time = 0;
        Instantiate(createUi, transform);
    }

    /// <summary>
    /// 毎フレーム行う処理
    /// </summary>
    void Update()
    {
        time += Time.deltaTime;
        if(createInterval <= time)
        {
            Instantiate(createUi,transform);
            time = 0;
        }
    }
}
