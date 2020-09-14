using UnityEngine;
using TMPro;
using I2.Loc;

/// <summary>
/// コンボのUIに関する処理をする
/// </summary>
public class ComboUI : MonoBehaviour
{
    TextMeshProUGUI comboText;                          //コンボを表示するText
    string comboBackText;                               //コンボの後ろに表示する文字列
    Animator addAnimator;                               //コンボのアニメーター
    Animator missAnimator;                              //コンボのアニメーター
    const string addStateName = "AddComboAnimation";    //コンボを追加した時のアニメーション
    const string missStateName = "MissComboAnimation";  //コンボをミスした時のアニメーション
    int sccessObjNum = 0;                               //成功した時に表示するオブジェクトの要素数番号
    int missObjNum = 1;                                 //失敗した時に表示するオブジェクトの要素数番号
    GameObject sccessObj;                               //成功した時に表示するオブジェクト
    GameObject missObj;                                 //失敗した時に表示するオブジェクト
    ComboMaterialDecider decider;                       //コンボ数でマテリアルを変更するクラス

    /// <summary>
    /// オブジェクトがアクティブになった時に呼ばれる
    /// </summary>
    void OnEnable()
    {
        ComboCounter.onSuccessComboEvent += OnSuccessCombo;
        ComboCounter.onMissComboEvent += OnMissCombo;
        sccessObj = transform.GetChild(sccessObjNum).gameObject;
        missObj = transform.GetChild(missObjNum).gameObject;
        //よくアクセスするコンポーネントをキャッシュしておく
        comboText = sccessObj.GetComponent<TextMeshProUGUI>();
        addAnimator = sccessObj.GetComponent<Animator>();
        missAnimator = missObj.GetComponent<Animator>();
        decider = sccessObj.GetComponent<ComboMaterialDecider>();
        comboBackText = LocalizationManager.GetTranslation("Combo_Back");
        comboText.text = "";

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
        //コンボ数を文字列にしてテキストを書き換える
        comboText.text = ComboCounter.ComboCount.ToString() + comboBackText;
        //アニメーションを最初から再生
        addAnimator.Play(addStateName, 0, 0f);
    }

    /// <summary>
    /// コンボを失敗した時に呼ぶ
    /// </summary>
    void OnMissCombo()
    {
        sccessObj.SetActive(false);
        missObj.SetActive(true);
        missAnimator.Play(missStateName, 0, 0f);
    }
}
