using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(GameBoard))]
public class GameBoardGUIEditor : Editor
{
    GameBoard gameboard;
    
    public override void OnInspectorGUI()
    {   
        base.OnInspectorGUI();

        if (GUILayout.Button("Generate Board"))
        {
            gameboard.ClearChildren();
            gameboard.GenerateBoard();
        }
        
    }

    private void OnEnable()
    {
        gameboard = (GameBoard)target;
    }
}
