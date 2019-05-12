using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;

public class TrackableEventHandlerPage6Pic : TrackableEventHandlerParent
{
    public GameObject Maze;

    private AudioSource audio;

    protected override void Start() {
        base.Start();
    }

    protected override void OnDestroy() {
        base.OnDestroy();
    }

    private void Awake() {
        audio = GetComponent<AudioSource>();
    }

    protected override void OnTrackingFound() {
        base.OnTrackingFound();
        Maze.SetActive(true);

        audio.Play();

    }

    protected override void OnTrackingLost() {
        base.OnTrackingLost();
        Maze.SetActive(false);

        audio.Stop();
    }
}
