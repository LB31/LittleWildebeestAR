using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;

public class TrackableEventHandlerPage13Pic : TrackableEventHandlerParent
{
    public AudioSource bgMusic;
    public Transform water;

    public Material originalGras;
    public Material newGras;

    public GameObject[] Gras;

    public int speedIndicator = 80; // The bigger the slowlier

    protected override void Start() {
        base.Start();

        newGras.CopyPropertiesFromMaterial(originalGras);
        foreach (GameObject item in Gras) {
            item.GetComponent<Renderer>().material = newGras;
        }
    }

    protected override void OnDestroy() {
        base.OnDestroy();
    }

 

    protected override void OnTrackingFound() {
        base.OnTrackingFound();
        bgMusic.Play();

    }

    protected override void OnTrackingLost() {
        base.OnTrackingLost();
        bgMusic.Stop();
    }

    private void Update() {
        if(water.position.y < 0)
        water.Translate(new Vector3(0, Time.deltaTime / speedIndicator, 0));


        foreach (GameObject item in Gras) {
            Material oldMat = item.GetComponent<Renderer>().material;
            Color oldColor = oldMat.color;
            oldMat.color = new Color(oldColor.r - Time.deltaTime / speedIndicator, oldColor.g, oldColor.b);
        }

    }
}
