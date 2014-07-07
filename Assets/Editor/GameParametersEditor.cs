using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(GameParameters))]
public class GameParametersEditor : Editor
{
	GameParameters gp = null;

	enum WEAPONS
	{
		Chaingun,
		Railgun,
	}
	WEAPONS WEAPON_STATE;

	public override void OnInspectorGUI()
    {
        gp = (GameParameters)target;

		EditWeapons();
    }

	void EditWeapons()
	{
		WEAPON_STATE = (WEAPONS)EditorGUILayout.EnumPopup("Weapon:", WEAPON_STATE);
		switch (WEAPON_STATE)
		{
			case (WEAPONS.Chaingun):
			{
				//  Chaingun
				gp.ChaingunDamage = EditorGUILayout.FloatField("Damage:", gp.ChaingunDamage);
				gp.ChaingunFireRate = EditorGUILayout.FloatField("Fire Rate:", gp.ChaingunFireRate);
				break;
			}
			case (WEAPONS.Railgun):
			{
				//  Railgun
				gp.RailgunDamage = EditorGUILayout.FloatField("Damage:", gp.RailgunDamage);
				gp.RailgunFireRate = EditorGUILayout.FloatField("Fire Rate:", gp.RailgunFireRate);
				break;
			}
		}
	}

	//	Creation of the Asset
	[MenuItem("Assets/Create/Game Parameters")]
	public static void CreateAsset()
	{
		ScriptableObjectUtility.CreateAsset<GameParameters>();
	}
	//	Selecting the Asset
	[MenuItem("Game Design/Game Parameters")]
	public static void SelectAsset()
	{
		Selection.activeObject = Resources.LoadAssetAtPath("Assets/Resources/GameParameters.asset", typeof(ScriptableObject));
	}
}
