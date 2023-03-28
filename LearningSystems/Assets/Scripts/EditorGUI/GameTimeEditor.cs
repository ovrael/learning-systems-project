using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(GameTime))]
public class ObjectBuilderEditor : Editor
{
    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();

        GameTime myScript = (GameTime)target;
        if (GUILayout.Button("Add 16 minutes"))
        {
            myScript.AddTime(16, 0, 0);
        }

        if (GUILayout.Button("Add 5 hours"))
        {
            myScript.AddTime(0, 5, 0);
        }

        if (GUILayout.Button("Add 7h 25min"))
        {
            myScript.AddTime(25, 7, 0);
        }
    }
}
