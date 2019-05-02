using UnityEngine;
using System.Collections;
using UnityEditor;


    [CustomEditor(typeof(DatabaseController))]
    public class JsonEditorButton : Editor {
        public override void OnInspectorGUI() {
            DrawDefaultInspector();

            DatabaseController dc = (DatabaseController)target;
            if (GUILayout.Button("Save data")) {
                dc.SerializeData();
            }

            if (GUILayout.Button("Load data")) {
                dc.ReadData();
            }
        }
    }
