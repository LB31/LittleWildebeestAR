using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;

public class TrackableEventHandlerFrontPage : DefaultTrackableEventHandler
{


    protected override void Start() {
        base.Start();
    }

    protected override void OnDestroy() {
        base.OnDestroy();
    }

 

    protected override void OnTrackingFound() {
        base.OnTrackingFound();

        // ToDo do more stuff
        print("yay");
        
    }

    protected override void OnTrackingLost() {
        base.OnTrackingLost();

        // ToDo do more stuff
        Debug.Log("man");
        
    }
}
