using System.Collections.Generic;
using System.Linq;
using Random = UnityEngine.Random;

/// <summary>
/// 重み付き抽選行うための重みのGetterの実装を強制するためのインターフェース
/// </summary>
public interface IWeight
{
    int Weight { get; }
}

/// <summary>
/// 重み付き抽選を行う
/// </summary>
public static class RandomWithWeight
{
    /// <summary>
    /// 重み付き抽選を行う
    /// </summary>
    /// <typeparam name="T">IWeightを継承したクラス</typeparam>
    /// <param name="weightPairs">抽選をしたいもののリスト</param>
    /// <returns>抽選で選ばれたもの</returns>
    public static T Lottery<T>(IEnumerable<T> weightPairs) where T : IWeight
    {
        //Weightで降順ソート
        var sortedPairs = weightPairs.OrderByDescending(x => x.Weight).ToArray();
        //Weightの合計を求める
        var total = sortedPairs.Select(x => x.Weight).Sum();
        //0からWeightの合計値まで乱数を取得する
        var randomPoint = Random.Range(0, total);
        //randomPointの位置に該当するキーを返す
        foreach (var elem in sortedPairs)
        {
            if (randomPoint < elem.Weight)
            {
                return elem;
            }
            randomPoint -= elem.Weight;
        }
        return sortedPairs[sortedPairs.Length - 1];
    }
}