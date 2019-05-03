using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class BubbleController : MonoBehaviour
{
    // 0 = german; 1 = english; 2 = oshiwambo
    public string[] BubbleMessages;
    public TextMeshProUGUI text;


    // Start is called before the first frame update
    void Start()
    {
        text = GetComponentInChildren<TextMeshProUGUI>();

        int languageNumb = ReadingManager.chosenLanguageNumber;
        languageNumb = (languageNumb == 2 || languageNumb == - 1) ? 1 : languageNumb;
        text.text = BubbleMessages[languageNumb];
    }

    public void SayStuff() {
        
    }

    private void Update() {
        transform.LookAt(Camera.main.transform);
    }

}
