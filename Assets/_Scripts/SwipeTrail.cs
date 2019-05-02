using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;
using UnityEngine.EventSystems;


public class SwipeTrail : MonoBehaviour
{
    public LineManager lineManager = new LineManager();

    public int LineCounter = -1;

    public GameObject PlaneToDrawOn;

    public float lineWidth = 0.75f;

    public Material TrailMaterial;
    public bool TouchedAlready = false;
    private TrailRenderer TrailRenderer;


    public bool FirstTouch = true;



    // For tracking, if the image was filled
    public int PercentToBeFilled;
    private int DestroyedMinesCount;
    private int AmountOfMines;

    //! The start colour
    private Color Color = Color.green;

    public GameObject ButtonsForLanguage;
    private bool languageWasChosen;
    public Transform BrushTip;
    public SpriteRenderer BrushImage;

    public GameObject ApprovalElephant;

    public static String LastMarkerName;

    private Vector3 StandardPosition;


    void Awake()
    {
        StandardPosition = transform.position;

        TrailRenderer = GetComponentInChildren<TrailRenderer>();
        TrailRenderer.startWidth = lineWidth;
        TrailRenderer.endWidth = lineWidth;

        // Disabled to get rid of the accidental line in the first frame
        TrailRenderer.enabled = false;


        AmountOfMines = GameObject.FindGameObjectsWithTag("Mine").Length;

    }

    private void OnTriggerStay(Collider other) {
        if (other.transform.gameObject.name == PlaneToDrawOn.name || other.transform.CompareTag("Mine")) {
            TrailRenderer.enabled = true;

       

            if (other.transform.CompareTag("Mine")) { // This line is stupid. However, I didn't want to rework the scene structure for a smarter code
                DestroyedMinesCount++;
                Destroy(other.transform.gameObject);

          

                if (AmountOfMines * (float)PercentToBeFilled / 100f < DestroyedMinesCount) {
                    ApprovalElephant.SetActive(true); // TODO react to the filled elephant
                }
            }

        }
    }


    private void OnTriggerExit(Collider other) {
        if (other.transform.gameObject.name == PlaneToDrawOn.name) {
            TrailRenderer.enabled = false;
            //StoreRay();
            //CreateLineObject();
            print("exit");
        }

    }


    void Update()
    {
        // Check, if the screen is touched and if the finger / mouse is moving
        bool fingerOnScreen = (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Moved) || Input.GetMouseButton(0);
  

        if (fingerOnScreen && languageWasChosen)
        {
            if (!TouchedAlready) TouchedAlready = true;
     

            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit) && !EventSystem.current.IsPointerOverGameObject()) {
                transform.position = hit.point;
            }
  
  

        }

        // To avoid an additional line
        if (fingerOnScreen && FirstTouch){
            FirstTouch = false; 
            setTrailColour(Color, TrailRenderer);
        }

        if (!fingerOnScreen)
        {
            TrailRenderer.enabled = false;
        }

        // Check, if the user has released the screen to store the last drawn line
        if (!fingerOnScreen && TouchedAlready)
        {
            StoreRay();
            CreateLineObject();

            TouchedAlready = false;
        }



    }



    //! The created object is used for retracing the line
    private void CreateLineObject()
    {
        LineCounter++;
        GameObject newLine = new GameObject();
        newLine.transform.parent = PlaneToDrawOn.transform;
        newLine.name = "Line segment " + LineCounter;
        newLine.AddComponent<LineRenderer>();
        
        RetraceLine(newLine.GetComponent<LineRenderer>(), LineCounter);

    }


    private void RetraceLine(LineRenderer line, int lineNumber)
    {
        Line currentLine = lineManager.AllLines[lineNumber];
        // Set the width of the Line Renderer
        line.SetWidth(lineWidth, lineWidth);
        // Set the number of vertex for the Line Renderer
        line.positionCount = currentLine.Positions.Length;
        line.material = TrailMaterial;
        setTrailColour(Color, null, line);
        line.SetPositions(currentLine.Positions);
        line.useWorldSpace = false;
    }



    private void StoreRay()
    {
        print("store ray");
        int arrayLength = TrailRenderer.positionCount;
        Color currentColour = TrailRenderer.endColor;
        Vector3[] rayPositions = new Vector3[arrayLength];
        GetComponentInChildren<TrailRenderer>().GetPositions(rayPositions);

        lineManager.AllLines.Add(new Line(currentColour, rayPositions));
        

        // Clears the "stage" so you can draw a new line
        TrailRenderer.Clear();
        FirstTouch = true;
        TrailRenderer.enabled = false;
    }





    /// <summary>
    /// Changes the Colour of the passed Renderer component
    /// </summary>
    /// <param name="color"></param>
    /// <param name="tRenderer">Optional. Changes the colour of the passed trail renderer</param>
    /// <param name="lRenderer">Optional. Changes the colour of the passed line renderer</param>
    public void setTrailColour(Color color, TrailRenderer tRenderer = null, LineRenderer lRenderer = null)
    {
        if (tRenderer != null)
        {
            tRenderer.startColor = color;
            tRenderer.endColor = color;
        }
        else if (lRenderer != null)
        {
            lRenderer.startColor = color;
            lRenderer.endColor = color;
        }
    }

    public void SelectColor(String language) {
        languageWasChosen = true;

        //Destroy(ButtonsForLanguage);

        //foreach (Transform child in ButtonsForLanguage.transform) {
        //    child.GetComponent<Image>().enabled = false;
        //}

        switch (language) {
            case "english":
                Color = Color.blue;
                break;
            case "oshiwambo":
                Color = Color.green;
                break;
            case "german":
                Color = Color.red;
                break;
        }

        setTrailColour(Color, TrailRenderer);

        BrushImage.enabled = true;
        BrushImage.color = Color;

        transform.position = StandardPosition;


        if (ReadingManager.chosenLanguage != language) {
            ReadingManager.chosenLanguage = language;
            ReadingManager.languageWasChanged = true;
            TrackableEventHandlerParent.markerFound(LastMarkerName); // To play the audio of the first page immediately
            print(LastMarkerName);
        }
    }

}

[System.Serializable]
public class LineManager{
    public string PostType = "Graffiti";
    public List<Line> AllLines = new List<Line>();
}