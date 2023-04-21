using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "GameplaySettings", menuName = "ScriptableObjects/GameplaySettings", order = 2)]
public class GameplaySettings : ScriptableObject
{
    
    public float conveyerBeltSpeed;
    public float itemTimeDuration;
    public float gameSpeed;
    public float minSpawnTimeModifier;
    public float maxSpawnTimeModifier;
    public float currentTimeScale;



    public void onGameSpeedChange(Slider slider)
    {
       
        gameSpeed = slider.value;
        currentTimeScale = gameSpeed;
        Debug.Log("speed" + gameSpeed.ToString());
    }

}
