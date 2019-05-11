using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;

public class TrackableEventHandlerPage6Pic : TrackableEventHandlerParent
{
    public GameObject Maze;

    protected override void Start() {
        base.Start();
    }

    protected override void OnDestroy() {
        base.OnDestroy();
    }

 

    protected override void OnTrackingFound() {
        base.OnTrackingFound();
        Maze.SetActive(true);

    }

    protected override void OnTrackingLost() {
        base.OnTrackingLost();
        Maze.SetActive(false);

    }
}
