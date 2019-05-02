﻿using System;
using System.Collections.Generic;
using System.IO;
using TMPro;
using UnityEngine;


[Serializable]
public class DatabaseController : MonoBehaviour
{

    
    public List<AnimalData> AllAnimals;

    private string json;
    
    private string dataPath = "/StreamingAssets/data.json";

    private string filePath;


    // Texts
    public TextMeshProUGUI TextName;
    public TextMeshProUGUI TextInformation;
    public TextMeshProUGUI TextPopulation;
    public TextMeshProUGUI TextDiet;

    // Start is called before the first frame update
    void Start()
    {
        SerializeData();
        print(json);

        string objectName = gameObject.name.Replace("InfromationPlane", "");
        ActivateInformation(objectName);


    }

    public void SerializeData() {
        json = JsonUtility.ToJson(this);
        filePath = Application.dataPath + dataPath;
        File.WriteAllText(filePath, json);
    } 

    public void ReadData() {
        JsonUtility.FromJsonOverwrite(filePath, this);
        print("done");
    }


    private void Update() {
        
        transform.LookAt(Camera.main.transform);
    }

    public void ActivateInformation(string animal) {
        AnimalData currentAnimal = null;
        foreach (AnimalData item in AllAnimals) {
            if (item.AnimalName == animal)
                currentAnimal = item;
        }
        if (currentAnimal != null) {
            int languageNumb = 1; //ReadingManager.chosenLanguageNumber;
            TextName.text = "<b>" + currentAnimal.AnimalName + "</b>";
            TextInformation.text = "<b>Information</b>\n" + currentAnimal.Information[languageNumb];
            TextPopulation.text = "<b>Population</b>\n" + currentAnimal.Population[languageNumb];
            TextDiet.text = "<b>Diet</b>\n" + currentAnimal.Diet[languageNumb];
            print(currentAnimal.Information[1]);
        }
    }

}

[Serializable]
public class AnimalData
{
    public string AnimalName;

    // Position 0 = german; Position 1 = english
    public string[] Information;
    public string[] Population;
    public string[] Diet;

    public Sprite AnimalImage;
}
