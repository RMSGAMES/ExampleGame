using UnityEngine.SceneManagement;
using System.Collections.Generic;
using UnityEngine;
using System;

[CreateAssetMenu(fileName = "GameData", menuName = "Game/New GameData")]
public class GameData : ScriptableObject
{
    [Header("Settings")]
    public string menuScene;
    public string gameScene;

    [Header("Reference")]
    public List<PlanetInfo> planets = new List<PlanetInfo>();

    public PlanetInfo GetCurrentPlanet()
    {
        return planets[GameState.currentPlanetID];
    }

    private static bool isCaching = false;
    private static GameData m_Data;
    public static GameData Instance
    {
        get
        {
            if (m_Data == null && !isCaching)
            {
                m_Data = Resources.Load("GameData", typeof(GameData)) as GameData;
            }
            return m_Data;
        }
    }
}

[Serializable]
public class PlanetInfo
{
    public string name;
    public float gravity;
    public Color color;
}
