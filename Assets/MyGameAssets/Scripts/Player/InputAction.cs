using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 入力があった際の動作をするクラス
/// </summary>
public class InputAction : MonoBehaviour
{
    bool canInput;                                                  //入力が出来るか
    float inputIntervalCounter;                                     //次の入力が出来るようになるまでのカウンター
    HitCheck hitCheck;                                              //入力された場所が当たりか外れかを判定するクラス
    List<GameObject> ObjectsGroupList = new List<GameObject>();     //オブジェクトグループのリスト
    ProgressDistanceCounter progressDistanceCounter;                //進んだ距離をカウントするクラス
    ComboCounter comboCounter;                                      //コンボをカウントするクラス

    /// <summary>
    /// 最初に行う処理
    /// </summary>
    void Start()
    {
        //ObjectGroupタグのゲームオブジェクトをリストに追加
        ObjectsGroupList.AddRange(GameObject.FindGameObjectsWithTag("ObjectsGroup"));
        // オブジェクトグループを近い順にソート
        ObjectsGroupList.Sort((a,b) => (int)(
            (Vector3.Distance(a.transform.position,transform.position)) -
            (Vector3.Distance(a.transform.position, transform.position))
            ) );
        //一番近いオブジェクトグループのHitCheckクラスを代入
        hitCheck = ObjectsGroupList[0].GetComponent<HitCheck>();
        //入力を可能にする
        canInput = true;
        //カウンターのリセット
        inputIntervalCounter = 0.0f;
        
        progressDistanceCounter = GameObject.FindGameObjectWithTag("ProgressDistanceCounter").GetComponent<ProgressDistanceCounter>();
        comboCounter = GameObject.FindGameObjectWithTag("ComboCounter").GetComponent<ComboCounter>();
    }

    /// <summary>
    /// 毎フレーム行う処理
    /// </summary>
    void Update()
    {
        //入力を受け付けてない時
        if(!canInput)
        {
            //入力が出来るまでのカウンターを進める
            inputIntervalCounter += Time.deltaTime;
            if(inputIntervalCounter > 0.5)
            {
                //入力を可能にする
                canInput = true;
            }
        }
    }

    /// <summary>
    /// 右が入力された時
    /// </summary>
    public void IsRightInputted()
    {
        if(canInput)
        {
            if(hitCheck.IsRightHit())
            {
                HitProcess();
            }
            else
            {
                comboCounter.MissCombo();
            }
        }
    }

    /// <summary>
    /// 中央が入力された時
    /// </summary>
    public void IsCenterInputted()
    {
        if (canInput)
        {
            if (hitCheck.IsCenterHit())
            {
                HitProcess();
            }
            else
            {
                comboCounter.MissCombo();
            }
        }
    }

    /// <summary>
    /// 左が入力された時
    /// </summary>
    public void IsLeftInputted()
    {
        if (canInput)
        {
            if (hitCheck.IsLeftHit())
            {
                HitProcess();
            }
            else
            {
                comboCounter.MissCombo();
            }
        }
    }

    /// <summary>
    /// 当たりを選んだ時の処理
    /// </summary>
    void HitProcess()
    {
        //判定するオブジェクトが次に進んだかどうか
        if (hitCheck.IsChangedCheckObject())
        {
            AllHitPlayerAction();
        }
        if (hitCheck.NeedsNextObjectsGroup())
        {
            ObjectsGroupList.RemoveAt(0);
            hitCheck = ObjectsGroupList[0].GetComponent<HitCheck>();
        }
    }

    /// <summary>
    /// 当たりを全て選んだ時にプレイヤーがやる処理
    /// </summary>
    /// FIXME orimoto モック版作成時のためマジックナンバー使用（本実装時に修正予定）
    void AllHitPlayerAction()
    {
        transform.position += new Vector3(0.0f, 0.0f, 3.0f);
        progressDistanceCounter.ProgressPlayer(3.0f);
        canInput = false;
        inputIntervalCounter = 0.0f;
        comboCounter.SuccessCombo();
    }
}
