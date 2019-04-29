using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;

public class TrackableEventHandlerPage1 : DefaultTrackableEventHandler
{


    protected override void Start() {
        base.Start();
    }

    protected override void OnDestroy() {
        base.OnDestroy();
    }

 

    protected override void OnTrackingFound() {
     

        // ToDo do more stuff
        print("yay");
        
    }

    protected override void OnTrackingLost() {

        // ToDo do more stuff
        Debug.Log("man");
        
    }
}
