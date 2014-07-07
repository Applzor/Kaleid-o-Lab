using UnityEngine;
using UnityEditor;
using System;

[System.Serializable]
public class GameParameters : ScriptableObject {

    //  Singleton
	protected static GameParameters instance = null;
	public static GameParameters Instance 
	{ 
		get 
		{ 
			if (instance == null) 
				instance = (GameParameters)Resources.Load("GameParameters", typeof(GameParameters)); 
			return instance; 
		} 
	}

    //  Weapons
    //  Chaingun
    public float ChaingunDamage;
    public float ChaingunFireRate;
    //  Railgun
    public float RailgunDamage;
    public float RailgunFireRate;

}
