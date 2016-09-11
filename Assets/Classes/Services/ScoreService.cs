using UnityEngine;
using System.Collections;
using SpaceGame.Interfaces;
using System;
using SpaceGame.Events;

public class ScoreService : MonoBehaviour, IScoreService
{
    // current score representation
    private int score;


    // IScoreService
    //

    public event ScoreUpdatedEvent ScoreUpdated;

    public int currentScore
    {
        get { return currentScore; }
    }

    public void AddToScore(int points)
    {
        score += points;
        OnScoreUpdated();
    }

    // Private
    //

    /// <summary>
    /// Call the scoreUpdated event if there are any subscribers.
    /// </summary>
    private void OnScoreUpdated()
    {
        if (ScoreUpdated != null) {
            ScoreUpdated(score);
        }
    }
}
