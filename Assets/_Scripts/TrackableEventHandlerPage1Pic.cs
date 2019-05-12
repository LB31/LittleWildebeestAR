using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using Vuforia;

public class TrackableEventHandlerPage1Pic : TrackableEventHandlerParent
{
    public GameObject UI;
    public GameObject Brush;
    public Transform Drawing;
    public Transform ElephantMessage;
    public TextMeshProUGUI textStuff;

    protected override void Start() {
        base.Start();
    }

    protected override void OnDestroy() {
        base.OnDestroy();
    }

 

    protected override void OnTrackingFound() {


        Brush.SetActive(true);
        Brush.GetComponentInChildren<SpriteRenderer>().enabled = true;
        //GetComponentInChildren<SwipeTrail>().enabled = true;

        if (UI != null)
            UI.SetActive(true);

        foreach(Transform line in Drawing) {
            if (line.GetComponent<LineRenderer>()) {
                line.GetComponent<LineRenderer>().enabled = true;
            }
        }

        // To show the elephant and the speech bubble
        if (ElephantMessage != null)
            foreach (Transform item in ElephantMessage) {
            if (item.GetComponent<Renderer>()) {
                item.GetComponent<Renderer>().enabled = true;
            }

        }

        if(textStuff != null)
        textStuff.enabled = true;


    }

    protected override void OnTrackingLost() {


        //GetComponentInChildren<SwipeTrail>().enabled = false;
        Brush.SetActive(false);
        

        if (UI != null)
            UI.SetActive(false);

        foreach (Transform line in Drawing) {
            if (line.GetComponent<LineRenderer>()) {
                line.GetComponent<LineRenderer>().enabled = false;
            }

        }

        if(ElephantMessage != null)
        foreach (Transform item in ElephantMessage) {
            if (item.GetComponent<Renderer>()) {
                item.GetComponent<Renderer>().enabled = false;
            }
        }

        if (textStuff != null)
            textStuff.enabled = false;

    }
}
