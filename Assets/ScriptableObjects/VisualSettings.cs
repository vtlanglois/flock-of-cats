using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CreateAssetMenu(fileName = "VisualSettings", menuName = "ScriptableObjects/VisualSettings", order = 3)]
public class VisualSettings : ScriptableObject
{
    public Palette currentPalette;
    public int currentPaletteNumber;
    public Palette[] allPalettes;

    private void Awake()
    {
        currentPalette = allPalettes[currentPaletteNumber];
    }
    public void ChangePalette(bool isIncreasing)
    {
        if (isIncreasing) currentPaletteNumber++;
        else currentPaletteNumber--;
        if (currentPaletteNumber <= -1) currentPaletteNumber = 0;
        else if (currentPaletteNumber >= allPalettes.Length) currentPaletteNumber = allPalettes.Length - 1;
        currentPalette = allPalettes[currentPaletteNumber];
        
    }

    public void SetPaletteToCustom()
    {
        //use when working with the custom palette
        currentPaletteNumber = 9;
        currentPalette = allPalettes[currentPaletteNumber];
    }
}
