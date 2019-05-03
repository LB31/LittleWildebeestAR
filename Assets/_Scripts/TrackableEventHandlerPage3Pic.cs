using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using Vuforia;

public class TrackableEventHandlerPage3Pic : TrackableEventHandlerParent
{
    public GameObject[] InfoCards;
    public GameObject InfoUI;

    private string[] infoTexts = new string[] {"Berühre eines der Tiere", "Touch one of the animals" };
    private int LastFoundCard = -1;

    protected override void Start() {
        base.Start();
    }

    protected override void OnDestroy() {
        base.OnDestroy();
    }

 

    protected override void OnTrackingFound() {
        base.OnTrackingFound();

        InfoUI.SetActive(true);

        SetInfoText();
        SetArrowColor();
    }

    protected override void OnTrackingLost() {
        base.OnTrackingLost();

        foreach (GameObject item in InfoCards) {
            item.GetComponentInChildren<Animator>().Play("InformationStandUp", -1, 0f); // Reset the animation
            item.SetActive(false);
        }

    }

    public void ActivateCard(int cardNumber) {

        

        if (cardNumber == LastFoundCard) // To avoid selection of the same card
            return;
        if (ReadingManager.chosenLanguageNumber == -1)
            return;

        InfoUI.SetActive(false);

        if (LastFoundCard != -1) {
            GameObject lastCard = InfoCards[LastFoundCard];
            lastCard.GetComponentInChildren<Animator>().Play("InformationStandUp", -1, 0f); // Reset the animation
            lastCard.SetActive(false);
        }


        LastFoundCard = cardNumber;
        InfoCards[cardNumber].SetActive(true);
        string animal = "";
        switch (cardNumber) {
            case 0:
                animal = "Kudu";
                break;
            case 1:
                animal = "Crocodile";
                break;
            case 2:
                animal = "Elephant";
                break;
        }
        if (animal != "") // To update the language
            InfoCards[cardNumber].GetComponent<DatabaseController>().ActivateInformation(animal);
    }

    public void SetLanguage(string language) {
        if (ReadingManager.chosenLanguage != language) {
            ReadingManager.chosenLanguage = language;
            ReadingManager.languageWasChanged = true;
            TrackableEventHandlerParent.markerFound(SwipeTrail.LastMarkerName); // To play the audio of the first page immediately

            SetInfoText();
            SetArrowColor();
        }
    }

    private void SetInfoText() {
        int langNumb = ReadingManager.chosenLanguageNumber;
        langNumb = langNumb == 2 ? 1 : langNumb;
        InfoUI.GetComponentInChildren<TextMeshProUGUI>().text = infoTexts[langNumb];
    }

    private void SetArrowColor() {
        if(ReadingManager.chosenLanguageNumber != -1) {
            Color arrowColor = Color.white;
            switch (ReadingManager.chosenLanguageNumber) {
                case 0:
                    arrowColor = Color.red;
                    break;
                case 1:
                    arrowColor = Color.blue;
                    break;
                case 2:
                    arrowColor = Color.green;
                    break;
            }
            foreach (Transform item in InfoUI.transform) {
                if (item.GetComponent<UnityEngine.UI.Image>()) {
                    item.GetComponent<UnityEngine.UI.Image>().color = arrowColor;
                }
            }
        }
    }

}
