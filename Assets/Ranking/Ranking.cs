using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Linq;

[CreateAssetMenu(fileName = "Rank", menuName = "Rank", order = 1)]
public class Ranking : ScriptableObject
{
    public List<Rank> ranks = new();

    public void AddRank(Rank rank)
    {
        ranks.Add(rank);
        ranks = ranks.OrderByDescending((rank) => rank.score).ToList();
        if (ranks.Count > 5)
        {
            ranks.RemoveAt(5);
        }
    }
}

[Serializable]
public class Rank
{
    public string name;
    public int score;
    public int hp;
    public float time;

    public Rank(string name, int score)
    {
        this.name = name;
        this.score = score;
    }
}

