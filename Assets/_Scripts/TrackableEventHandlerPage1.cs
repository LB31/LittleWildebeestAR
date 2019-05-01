using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;

public class TrackableEventHandlerPage1 : TrackableEventHandlerParent
{
    public GameObject UI;
    public GameObject Brush;

    protected override void Start() {
        base.Start();
    }

    protected override void OnDestroy() {
        base.OnDestroy();
    }

 

    protected override void OnTrackingFound() {

        GetComponentInChildren<SwipeTrail>().enabled = true;
        if(UI != null)
            UI.SetActive(true);

        Brush.SetActive(true);

    }

    protected override void OnTrackingLost() {

        GetComponentInChildren<SwipeTrail>().enabled = false;
        if (UI != null)
            UI.SetActive(false);
        
        Brush.SetActive(false);

    }
}
