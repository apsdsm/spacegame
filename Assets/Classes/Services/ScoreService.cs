using UnityEngine;
using System.Collections;
using SpaceGame.Interfaces;
using System;
using SpaceGame.Events;

public class ScoreService : MonoBehaviour, IScoreService
{
    private int score;

    public int currentScore
    {
        get { return currentScore; }
    }

    public event ScoreUpdatedEvent ScoreUpdated;

    public void AddToScore(int points)
    {
        score += points;

        if (ScoreUpdated != null) {
            ScoreUpdated(score);
        }
    }
}
