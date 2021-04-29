using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Diagnostics;

public class Timer : MonoBehaviour
{
    public float time;
    Stopwatch topwatch = new Stopwatch();
    /// <summary>
    /// MAIN TIMER FUNCTIONS
    /// </summary>
    public void Begin()
    {
        topwatch.Start();
    }
    public void Pause()
    {
        topwatch.Stop();
    }
    public void Refresh()
    {
        topwatch.Restart();
    }
    public float GetMilliseconds()
    {
        return (float)Math.Round(TimeSpan.FromMilliseconds(topwatch.Elapsed.TotalMilliseconds).TotalSeconds, 2);
    }
    private void Update()
    {
        time = GetMilliseconds();
    }
}
