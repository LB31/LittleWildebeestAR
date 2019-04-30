using System;
using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using UnityEngine;

public class ReadingManager : MonoBehaviour
{
    public FileStorer[] AudioFilesToRead;

    // Start is called before the first frame update
    void Start()
    {
        TrackableEventHandlerParent.markerFound += doStuff;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void doStuff(string stuff) {
        string resultString = Regex.Match(stuff, @"\d+").Value;
        Int32.Parse(resultString);
        print(resultString);
    }


}

[System.Serializable]
public class FileStorer
{
    public AudioClip german;
    public AudioClip english;
    public AudioClip oschiwambo;
}
