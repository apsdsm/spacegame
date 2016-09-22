using UnityEngine;
using System.Collections;
using SpaceGame.Interfaces;
using System;
using SpaceGame.Events;

public class TimeService : MonoBehaviour, ITimeService {
    // true if the countdown is playing
    private bool isActive = false;

    // actual countdown
    private float time;

    // countdown as whole seconds
    private int lastWholeSecond;

    // broadcast whe the countdown updates (once per second)
    public event TimeUpdatedEvent TimeUpdated;

    // broadcast when the countdown finishes
    public event CountdownFinishedEvent CountdownFinished;

    private float addTime = 0.0f;

    /// <summary>
    /// Return the current time in whole seconds.
    /// </summary>
    public int currentTime {
        get { return lastWholeSecond; }
    }

    /// <summary>
    /// Set the countdown to a specific time.
    /// </summary>
    /// <param name="seconds"></param>
    public void SetCountdown(int seconds) {
        time = (float)seconds;
        lastWholeSecond = Mathf.CeilToInt(time);
        OnTimeUpdated();
    }

    /// <summary>
    /// Add seconds to the countdown.
    /// </summary>
    /// <param name="seconds"></param>
    public void AddSeconds(int seconds) {
        addTime += (float)seconds;
        lastWholeSecond = Mathf.CeilToInt(time);
        OnTimeUpdated();
    }

    /// <summary>
    /// Pauses the countdown.
    /// </summary>
    public void PauseCountdown() {
        isActive = false;
    }

    /// <summary>
    /// Starts the countdown playing.
    /// </summary>
    public void StartCountdown() {
        isActive = true;
    }

    /// <summary>
    /// Update the countdown and broadcast events.
    /// </summary>
    void Update() {
        if (isActive) {

            if (addTime > 0.0f) {
                time += addTime;
                addTime = 0.0f;
                lastWholeSecond = Mathf.CeilToInt(time);
                OnTimeUpdated();
            }

            time -= Time.deltaTime;

            int ceilTime = Mathf.CeilToInt(time);
                        
            if (time <= 0) {
                isActive = false;
                time = 0;
                lastWholeSecond = 0;

                OnTimeUpdated();
                OnCountdownFinished();

            } else if (ceilTime < lastWholeSecond) {
                lastWholeSecond = ceilTime;
                OnTimeUpdated();
            }
        }
    }

    /// <summary>
    /// Call the TimeUpdated event if there are any subscribers.
    /// </summary>
    void OnTimeUpdated() {
        if (TimeUpdated != null) {
            TimeUpdated(lastWholeSecond);
        }
    }

    /// <summary>
    /// Call the CountdownFinished event if there are any subscribers.
    /// </summary>
    void OnCountdownFinished() {
        if (CountdownFinished != null) {
            CountdownFinished();
        }
    }
}
