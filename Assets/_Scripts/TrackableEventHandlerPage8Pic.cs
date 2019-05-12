using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;

public class TrackableEventHandlerPage8Pic : TrackableEventHandlerParent
{
    public AudioSource soundTarget;
    public AudioClip clipTarget;
    private AudioSource[] allAudioSources;

    public GameObject AnimatedObject;

    protected override void Start() {
        base.Start();
    }

    protected override void OnDestroy() {
        base.OnDestroy();
    }

 

    protected override void OnTrackingFound() {
        base.OnTrackingFound();

        AnimatedObject.SetActive(true);

        if (soundTarget != null) {
            soundTarget.clip = clipTarget;
            soundTarget.loop = false;
            soundTarget.Play();
        }

    }

    protected override void OnTrackingLost() {
        base.OnTrackingLost();

        AnimatedObject.SetActive(false);

        if (soundTarget != null) {
            soundTarget.Stop();
        }

    }
}
