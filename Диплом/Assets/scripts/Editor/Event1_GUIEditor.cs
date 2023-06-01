/*using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(Event1))]
public class Event1_GUIEditor : Editor
{
    private Event1 Eventobj;

    private bool JustTrigger;

    private GameObject Player, TriggerForStart, TrrigerForDialog, TrrigerForDialog2, Thoughts;
    private GameObject[] BordersTriggers, objects_forDestroy;
    private string PathToThoughts, PathToDialog1, PathToDialog2;

    private void OnEnable()
    {
        Event1 Eventobj = (Event1)target;
    }

    public override void OnInspectorGUI()
    {
        JustTrigger = EditorGUILayout.Toggle(Eventobj.JustTriggerForEnd, "JustTriggerFor eND");

        if (!JustTrigger)
        {
            Player = EditorGUILayout.ObjectField("Player", Player, typeof(GameObject), false) as GameObject;
            TriggerForStart = EditorGUILayout.ObjectField("TriggerForStart", TriggerForStart, typeof(GameObject), false) as GameObject;
            TrrigerForDialog = EditorGUILayout.ObjectField("TrrigerForDialog", TrrigerForDialog, typeof(GameObject), false) as GameObject;
            TrrigerForDialog2 = EditorGUILayout.ObjectField("TrrigerForDialog2", TrrigerForDialog2, typeof(GameObject), false) as GameObject;
            Thoughts = EditorGUILayout.ObjectField("Thoughts", Thoughts, typeof(GameObject), false) as GameObject;


            PathToThoughts = EditorGUILayout.TextField("", Eventobj.PathToThoughts);
        }
    }
}
*/