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

    public GameObject[] GrasObjects;

    public GameObject rainySavanna;

    private bool startAction;
    private Vector3 originalWaterPos;

    public int speedIndicator = 80; // The bigger the slowlier

    protected override void Start() {
        base.Start();

        
    }

    protected override void OnDestroy() {
        base.OnDestroy();
    }

    private void Awake() {
        originalWaterPos = water.localPosition;
    }

    protected override void OnTrackingFound() {
        base.OnTrackingFound();
        rainySavanna.SetActive(true);

        newGras.CopyPropertiesFromMaterial(originalGras);
        foreach (GameObject item in GrasObjects) {
            item.GetComponent<Renderer>().material = newGras;
        }


        bgMusic.Play();

        startAction = true;
        
    }

    protected override void OnTrackingLost() {
        base.OnTrackingLost();
        


        water.localPosition = originalWaterPos;


        bgMusic.Stop();

        startAction = false;

        rainySavanna.SetActive(false);
    }

    private void Update() {
        if (startAction) {
            if (water.position.y < 0)
                water.Translate(new Vector3(0, Time.deltaTime / speedIndicator, 0));


            foreach (GameObject item in GrasObjects) {
                Material oldMat = item.GetComponent<Renderer>().material;
                Color oldColor = oldMat.color;
                oldMat.color = new Color(oldColor.r - Time.deltaTime / speedIndicator, oldColor.g, oldColor.b);
            }
        }
    }

}
