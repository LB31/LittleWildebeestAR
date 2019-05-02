using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using Vuforia;

public class TrackableEventHandlerFrontPage : TrackableEventHandlerParent
{
    public VideoPlayer vid;

    protected override void Start() {
        base.Start();

        
    }

    protected override void OnDestroy() {
        base.OnDestroy();
    }

 

    protected override void OnTrackingFound() {
        base.OnTrackingFound();

        vid.Play();
    }

    protected override void OnTrackingLost() {
        base.OnTrackingLost();

        vid.Pause();
    }



}
