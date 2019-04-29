using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;
using UnityEngine.EventSystems;


public class SwipeTrail : MonoBehaviour
{
    public LineManager lineManager = new LineManager();
    public string jsonObject;
    public int LineCounter = -1;

    public GameObject PlaneToDrawOn;

    public float lineWidth = 0.2f;

    public Material TrailMaterial;
    public bool TouchedAlready = false;
    private TrailRenderer TrailRenderer;
    public bool AllowRetraceLine; // currently set to true in the inspector
    public int RayPositionCounter = 1;
    public bool FirstTouch = true;

    //public Renderer renderer;
    //public ColorPicker picker;
    //public Image pickerLine;
    //public GameObject pickerHue;

    // For tracking, if the image was filled
    public int PercentToBeFilled;
    private int DestroyedMinesCount;
    private int AmountOfMines;

    //! The start colour
    private Color Color = Color.red;


    void Awake()
    {

        TrailRenderer = GetComponent<TrailRenderer>();
        TrailRenderer.startWidth = lineWidth;
        TrailRenderer.endWidth = lineWidth;

        // Disabled to get rid of the accidental line in the first frame
        TrailRenderer.enabled = false;


        // Color selection; Source: https://github.com/judah4/HSV-Color-Picker-Unity
        //picker.onValueChanged.AddListener(color =>
        //{
        //    renderer.material.color = color;
        //    Color = color;
        //    pickerLine.color = color;
        //});

        //renderer.material.color = picker.CurrentColor;

        //picker.CurrentColor = Color;


        AmountOfMines = GameObject.FindGameObjectsWithTag("Mine").Length;

    }


    void Update()
    {
        // Check, if the screen is touched and if the finger / mouse is moving
        bool fingerOnScreen = (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Moved) || Input.GetMouseButton(0);
        // Check, if user is using the colour bar
        //bool usingColour = EventSystem.current.currentSelectedGameObject != null && EventSystem.current.currentSelectedGameObject.GetComponent<Slider>() != null;
        if (fingerOnScreen) // && !usingColour)
        {
            if (TouchedAlready == false) TouchedAlready = true;
            //Plane objPlane = new Plane(Camera.main.transform.forward * -1, transform.position);
            //Ray mRay = Camera.main.ScreenPointToRay(Input.mousePosition);
            //float rayDistance;
            //if (objPlane.Raycast(mRay, out rayDistance))
            //{
            //    transform.position = mRay.GetPoint(rayDistance);
            //}

            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit)) {
                if(hit.transform.gameObject.name == PlaneToDrawOn.name || hit.transform.CompareTag("Mine")) {
                    transform.position = hit.point;
                    if (hit.transform.CompareTag("Mine")) { // This line is stupid. However, I didn't want to rework the scene structure for a smarter code
                        DestroyedMinesCount++;
                        Destroy(hit.transform.gameObject);

                        if(AmountOfMines * (float)PercentToBeFilled / 100f < DestroyedMinesCount) {
                            print("stuff");
                        }
                    }
                }
                
            }

        }

        // To avoid an additional line
        if (fingerOnScreen && FirstTouch) // && !usingColour)
        {
            FirstTouch = false;
            TrailRenderer.enabled = true;
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
        TouchedAlready = false;
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
        int arrayLength = TrailRenderer.positionCount;
        Color currentColour = TrailRenderer.endColor;
        Vector3[] rayPositions = new Vector3[arrayLength];
        GetComponent<TrailRenderer>().GetPositions(rayPositions);

        lineManager.AllLines.Add(new Line(currentColour, rayPositions));
        

        // Clears the "stage" so you can draw a new line
        TrailRenderer.Clear();
        FirstTouch = true;
        TrailRenderer.enabled = false;
    }

    public string getJsonGraffiti()
    {
        jsonObject = JsonUtility.ToJson(lineManager);
        return jsonObject;
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



}

[System.Serializable]
public class LineManager{
    public string PostType = "Graffiti";
    public List<Line> AllLines = new List<Line>();
}