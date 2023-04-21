using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ControlSettings", menuName = "ScriptableObjects/ControlSettings", order = 3)]
public class ControlSettings : ScriptableObject
{
    public bool isClickAndHoldEnabled;

    public void OnEnable()
    {
        isClickAndHoldEnabled = true;
    }
}
