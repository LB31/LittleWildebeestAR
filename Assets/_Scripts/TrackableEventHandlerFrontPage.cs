using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;

public class TrackableEventHandlerFrontPage : TrackableEventHandlerParent
{


    protected override void Start() {
        base.Start();
    }

    protected override void OnDestroy() {
        base.OnDestroy();
    }

 

    protected override void OnTrackingFound() {
        base.OnTrackingFound();

        
    }

    protected override void OnTrackingLost() {
        base.OnTrackingLost();

        
    }
}
