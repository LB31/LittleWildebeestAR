using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;

public class TrackableEventHandlerPage1 : TrackableEventHandlerParent
{
    public GameObject UI;
    public GameObject Brush;
    public Transform Drawing;

    protected override void Start() {
        base.Start();
    }

    protected override void OnDestroy() {
        base.OnDestroy();
    }

 

    protected override void OnTrackingFound() {


        Brush.SetActive(true);
        Brush.GetComponentInChildren<SpriteRenderer>().enabled = true;
        GetComponentInChildren<SwipeTrail>().enabled = true;

        if (UI != null)
            UI.SetActive(true);

        foreach(Transform line in Drawing) {
            if (line.GetComponent<LineRenderer>()) {
                line.GetComponent<LineRenderer>().enabled = true;
            }
        }


    }

    protected override void OnTrackingLost() {


        GetComponentInChildren<SwipeTrail>().enabled = false;
        Brush.SetActive(false);
        

        if (UI != null)
            UI.SetActive(false);

        foreach (Transform line in Drawing) {
            if (line.GetComponent<LineRenderer>()) {
                line.GetComponent<LineRenderer>().enabled = false;
            }
        }

    }
}
