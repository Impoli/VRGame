using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HighScore : IComparable<HighScore>
{
    public string playerName { get; set; }
    public int playerScore { get; set; }


    public HighScore(string name, int score)
    {
        playerName = name;
        playerScore = score;
    }

    //Default comparer for HighScore type
    public int CompareTo(HighScore compareScore)
    {
        if (compareScore == null)
            return 1;
        else
            return this.playerScore.CompareTo(compareScore.playerScore);
    }
}
