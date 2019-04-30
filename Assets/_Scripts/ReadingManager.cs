using System;
using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using UnityEngine;

public class ReadingManager : MonoBehaviour
{
    public FileStorer[] AudioFilesToRead;

    private AudioSource audioSource;

    // 1 = german; 2 = english; oshiwambo = 3
    public static string chosenLanguage;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();

        TrackableEventHandlerParent.markerFound += doStuff;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void doStuff(string stuff) {
        string resultString = Regex.Match(stuff, @"\d+").Value;
        
        print(resultString);

        FileStorer currentFiles = AudioFilesToRead[Int32.Parse(resultString)];
        AudioClip clipToPlay = null;
        switch (chosenLanguage) {
            case "german":
                clipToPlay = currentFiles.german;
                break;
            case "english":
                clipToPlay = currentFiles.english;
                break;
            case "oshiwambo":
                clipToPlay = currentFiles.oshiwambo;
                break;
            default:
                print("There was no language selected yet");
                break;
        }

        if(clipToPlay != null)
        audioSource.clip = clipToPlay;
        audioSource.Play();
    }


}

[System.Serializable]
public class FileStorer
{
    public AudioClip german;
    public AudioClip english;
    public AudioClip oshiwambo;
}
