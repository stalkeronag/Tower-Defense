using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GridBuilder;
using UnityEditor;
//[CustomEditor(typeof(GridD))]
public class GridStart : Editor
{
    private GridD grid;
    public override void OnInspectorGUI()
    {
        //grid  = (GridD)target;
        //grid.gridBuild = EditorGUILayout.ObjectField("Script Grid", grid.gridBuild, typeof(IGrid)) as IGrid;
        //if(GUILayout.Button("Start"))
        //{
        //    grid.StartBuildGrid();
        //}
    }
}
