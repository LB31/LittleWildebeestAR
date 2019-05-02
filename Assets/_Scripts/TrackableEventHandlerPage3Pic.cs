using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;

public class TrackableEventHandlerPage3Pic : TrackableEventHandlerParent
{
    public GameObject[] InfoCards;

    private int LastFoundCard = -1;

    protected override void Start() {
        base.Start();
    }

    protected override void OnDestroy() {
        base.OnDestroy();
    }

 

    protected override void OnTrackingFound() {
        base.OnTrackingFound();


    }

    protected override void OnTrackingLost() {
        base.OnTrackingLost();

        foreach (GameObject item in InfoCards) {
            item.GetComponentInChildren<Animator>().Play("InformationStandUp", -1, 0f); // Reset the animation
            item.SetActive(false);
        }

    }

    public void ActivateCard(int cardNumber) {
        if(LastFoundCard != -1) {
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
}
