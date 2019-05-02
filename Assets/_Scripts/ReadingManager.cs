using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using UnityEngine;

public class ReadingManager : MonoBehaviour
{
    public FileStorer[] AudioFilesToRead;

    private AudioSource audioSource;

    public int lastFoundPage = 0;

    public string langForPublic;

    private int readyAudioPages = 5;

    // 0 = german; 1 = english; oshiwambo = 2
    public static int chosenLanguageNumber = 1;
    public static string chosenLanguage = "english"; // Let's use english as default
    public static bool languageWasChanged;

    // Start is called before the first frame update
    void Start() {
        audioSource = GetComponent<AudioSource>();

        TrackableEventHandlerParent.markerFound += AssignAndPlayAudio;
    }



    public void AssignAndPlayAudio(string stuff) {
        langForPublic = chosenLanguage;
        if (stuff == "lost") {
            audioSource.Pause();
            print("paused and lost");
            return;
        }

        string resultString = Regex.Match(stuff, @"\d+").Value;

        if (resultString.Any(char.IsDigit) && Int32.Parse(resultString) <= readyAudioPages && chosenLanguage != "") {
            int newFoundPage = Int32.Parse(resultString);
            print(newFoundPage);
            if (newFoundPage != lastFoundPage || languageWasChanged) {
                languageWasChanged = false;
                print("new page");
                FileStorer currentFiles = AudioFilesToRead[newFoundPage];
                AudioClip clipToPlay = null;

                switch (chosenLanguage) {
                    case "german":
                        clipToPlay = currentFiles.german;
                        chosenLanguageNumber = 0;
                        break;
                    case "english":
                        clipToPlay = currentFiles.english;
                        chosenLanguageNumber = 1;
                        break;
                    case "oshiwambo":
                        clipToPlay = currentFiles.oshiwambo;
                        chosenLanguageNumber = 2;
                        break;
                }
                lastFoundPage = newFoundPage;
                if (clipToPlay != null) {
                    audioSource.clip = clipToPlay;
                    audioSource.Play();
                }
            } else {
                audioSource.UnPause();
            }
            
        }

    }


}

[System.Serializable]
public class FileStorer
{
    public AudioClip german;
    public AudioClip english;
    public AudioClip oshiwambo;
}
