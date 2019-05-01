using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

[Serializable]
public class DatabaseController : MonoBehaviour
{
    public List<AnimalData> AllAnimals;

    private string json;

    private string dataPath = "/StreamingAssets/data.json";

    private string filePath;

    // Start is called before the first frame update
    void Start()
    {
        SerializeData();
        print(json);
        filePath = Application.dataPath + dataPath;
    }

    public void SerializeData() {
        json = JsonUtility.ToJson(this);
        
        File.WriteAllText(filePath, json);
    } 

    public void ReadData() {
        JsonUtility.FromJsonOverwrite(filePath, this);
        print("done");
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
