using UnityEngine;
using UnityEditor;
using System;

[CustomEditor(typeof(GameParameters))]
public class GameParametersEditor : Editor
{
    [MenuItem("Game Design/Game Parameters")]
    public static void GameParameters()
    {
        GameParameters gp = null;

        //  If we can't load the asset, create a new one
        if (gp == null)
        {
            gp = new GameParameters();
            AssetDatabase.CreateAsset(gp, "Assets/Assets/GameParameters.asset");
        }


        AssetDatabase.SaveAssets();
        EditorUtility.FocusProjectWindow();
        Selection.activeObject = gp;
    }

    public override void OnInspectorGUI()
    {
        GameParameters gp = (GameParameters)target;

        //  Weapons
        GUILayout.Label("Weapons:");
        {
            //  Railgun
            GUILayout.Label("Railgun:");
            {
                gp.RailgunDamage = EditorGUILayout.FloatField("Damage", gp.RailgunDamage);
                gp.RailgunFireRate = EditorGUILayout.FloatField("Fire Rate", gp.RailgunFireRate);
            }
        }
    }
}
