using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "GameSettings", menuName = "ScriptableObjects/GameSettings", order = 1)]
public class GameSettings : ScriptableObject
{
    //each settings object handles its own settings
    public GameplaySettings gameplaySettings;
    public ControlSettings controlSettings;
    public VisualSettings visualSettings;
}
