using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;

public class TrackableEventHandlerPage1Camel : TrackableEventHandlerParent
{
    public GameObject imageThingy;

    protected override void Start() {
        base.Start();
    }

    protected override void OnDestroy() {
        base.OnDestroy();
    }

    IEnumerator Wait(float time) {

        yield return new WaitForSeconds(time);
        imageThingy.SetActive(false);
        GetComponent<AudioSource>().Play();

    }

    protected override void OnTrackingFound() {
        base.OnTrackingFound();
        GetComponentInChildren<Animator>().enabled = true;
        StartCoroutine(Wait(3));
        

        // ToDo do more stuff

        
    }

    protected override void OnTrackingLost() {
        base.OnTrackingLost();

        GetComponent<AudioSource>().Stop();
        GetComponentInChildren<Animator>().enabled = false;
        // ToDo do more stuff
        
    }
}
