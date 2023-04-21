using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Text.RegularExpressions;

public class CustomPalette : MonoBehaviour
{
    public TMP_InputField input1;
    public TMP_InputField input2;
    public TMP_InputField input3;
    public TMP_InputField input4;
    public TMP_InputField input5;
    public GameSettings gameSettings;

    // Start is called before the first frame update
    void Start()
    {
        gameSettings.visualSettings.SetPaletteToCustom();
        Debug.Log("Yes?");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ApplyNewColors()
    {
        gameSettings.visualSettings.currentPalette.catColor1 = SetCustomPaletteColor(input1.text);
        gameSettings.visualSettings.currentPalette.catColor2 = SetCustomPaletteColor(input2.text);
        gameSettings.visualSettings.currentPalette.catColor3 = SetCustomPaletteColor(input3.text);
        gameSettings.visualSettings.currentPalette.specialCatColor1 = SetCustomPaletteColor(input4.text);
        gameSettings.visualSettings.currentPalette.specialCatColor2 = SetCustomPaletteColor(input5.text);
        gameSettings.visualSettings.SetPaletteToCustom();
        Debug.Log("applied!" + input1.text);
    }
    private Color32 SetCustomPaletteColor( string hex)
    {
        if(!Regex.IsMatch(hex, "^[0-9a-fA-F]+$", RegexOptions.IgnoreCase)) {
            return Color.black;
        }
        hex = hex.Replace("0x", "");//in case the string is formatted 0xFFFFFF
        hex = hex.Replace("#", "");//in case the string is formatted #FFFFFF
        byte a = 255;//assume fully visible unless specified in hex
        byte r = byte.Parse(hex.Substring(0, 2), System.Globalization.NumberStyles.HexNumber);
        byte g = byte.Parse(hex.Substring(2, 2), System.Globalization.NumberStyles.HexNumber);
        byte b = byte.Parse(hex.Substring(4, 2), System.Globalization.NumberStyles.HexNumber);
        //Only use alpha if the string has enough characters
        return new Color32(r, g, b, a);
    }



}
