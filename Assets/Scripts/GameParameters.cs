using UnityEngine;
using UnityEditor;
using System;

[System.Serializable]
public class GameParameters : ScriptableObject {

    //  Singleton
    static protected GameParameters instance = null;
    static public GameParameters Instance { get { if (instance == null) instance = new GameParameters(); return instance; } }

    //  Weapons
    //  Chaingun
    public float ChaingunDamage;
    public float ChaingunFireRate;
    //  Railgun
    public float RailgunDamage;
    public float RailgunFireRate;

}
