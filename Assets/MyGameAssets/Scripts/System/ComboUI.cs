using UnityEngine;

/// <summary>
/// コンボのUIに関する処理をする
/// </summary>
public class ComboUI : MonoBehaviour
{
    Animator addAnimator;                                       //コンボのアニメーター
    Animator missAnimator;                                      //コンボのアニメーター
    const string addStateName = "AddComboAnimation";            //コンボを追加した時のアニメーション
    const string changeStateName = "ChangeMaterialAnimation";   //マテリアルを変更する時のアニメーション
    const string missStateName = "MissComboAnimation";          //コンボをミスした時のアニメーション
    [SerializeField] GameObject sccessObj = default;            //成功した時に表示するオブジェクト
    [SerializeField] GameObject missObj = default;              //失敗した時に表示するオブジェクト
    ComboMaterialDecider decider;                               //コンボ数でマテリアルを変更するクラス

    /// <summary>
    /// オブジェクトがアクティブになった時に呼ばれる
    /// </summary>
    void OnEnable()
    {
        ComboCounter.onSuccessComboEvent += OnSuccessCombo;
        ComboCounter.onMissComboEvent += OnMissCombo;
        //よくアクセスするコンポーネントをキャッシュしておく
        addAnimator = sccessObj.GetComponent<Animator>();
        decider = sccessObj.GetComponent<ComboMaterialDecider>();
        missAnimator = missObj.GetComponent<Animator>();
    }

    /// <summary>
    /// オブジェクトがアクティブになった時に呼ばれる
    /// </summary>
    void OnDisable()
    {
        ComboCounter.onSuccessComboEvent -= OnSuccessCombo;
        ComboCounter.onMissComboEvent -= OnMissCombo;
    }

    /// <summary>
    /// コンボを成功させた時に呼ぶ
    /// </summary>
    void OnSuccessCombo()
    {
        sccessObj.SetActive(true);
        decider.OnAddCombo();
        //マテリアルを変更する必要があるとき
        if(decider.IsNeedChangeMaterial)
        {
            //アニメーションを最初から再生
            addAnimator.Play(changeStateName, 0, 0f);
        }
        else
        {
            //アニメーションを最初から再生
            addAnimator.Play(addStateName, 0, 0f);
        }
    }

    /// <summary>
    /// コンボを失敗した時に呼ぶ
    /// </summary>
    void OnMissCombo()
    {
        sccessObj.SetActive(false);
        missObj.SetActive(true);
        missAnimator.Play(missStateName, 0, 0f);
        decider.OnMissCombo();
    }

    /// <summary>
    /// マテリアルを変更する
    /// </summary>
    public void ChangeMaterial()
    {
        //コンボ数を文字列にしてテキストを書き換える
        decider.ChangeMaterial();
    }
}
