using UnityEngine;
using System.Collections;
using SpaceGame.Interfaces;
using System;

public class ScoreService : MonoBehaviour, IScoreService
{
    private int score;

    public void AddToScore (int points)
    {
        score += points;
    }

    public int GetScore ()
    {
        return score;
    }
}
