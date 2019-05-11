using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;

public class TrackableEventHandlerPage1Camel : TrackableEventHandlerParent
{

    public Animator anim;

    protected override void Start() {
        base.Start();


        
    }

    private void Awake() {
        anim = GetComponentInChildren<Animator>();
        anim.Play("camelAppears", -1, 0f);
        anim.enabled = false;
    }

    protected override void OnDestroy() {
        base.OnDestroy();
    }

    IEnumerator Wait(float time) {

        yield return new WaitForSeconds(time);

        GetComponent<AudioSource>().Play();

    }

    protected override void OnTrackingFound() {
        base.OnTrackingFound();
        anim.enabled = true;
        StartCoroutine(Wait(2));
        

        
    }

    protected override void OnTrackingLost() {
        base.OnTrackingLost();

        GetComponent<AudioSource>().Stop();
        
        anim.Play("camelAppears", -1, 0f);

        anim.enabled = false;
     
        
    }
}
