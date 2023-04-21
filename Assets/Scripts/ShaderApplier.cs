using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShaderApplier : MonoBehaviour
{
    public enum PaletteItem {Cat1, Cat2, Cat3, SpecialCat1, SpecialCat2}; //used to determine which cat is which when applying the shader
    public GameSettings gameSettings;
    public PaletteItem paletteItem;
    Material material;
    string paletteName;
    // Start is called before the first frame update
    void Start()
    {
        material = GetComponent<SpriteRenderer>().material;
        paletteName = gameSettings.visualSettings.currentPalette.name;
        ApplyPalette();

    }

    // Update is called once per frame
    void Update()
    {
        //if the palette changes, update everyone's shader color
        if(paletteName != gameSettings.visualSettings.currentPalette.name)
        {
            ApplyPalette();
            paletteName = gameSettings.visualSettings.currentPalette.name;
            Debug.Log("new pallete");

        }
        
    }


    void ApplyPalette()
    {
        //using an object's palette item, apply the corresponding color
        switch (paletteItem)
        {
            case PaletteItem.Cat1:
                material.SetColor("_CatColor", gameSettings.visualSettings.currentPalette.catColor1);
                break;
            case PaletteItem.Cat2:
                material.SetColor("_CatColor", gameSettings.visualSettings.currentPalette.catColor2);
                break;
            case PaletteItem.Cat3:
                material.SetColor("_CatColor", gameSettings.visualSettings.currentPalette.catColor3);
                break;
            case PaletteItem.SpecialCat1:
                material.SetColor("_CatColor", gameSettings.visualSettings.currentPalette.specialCatColor1);
                break;
            case PaletteItem.SpecialCat2:
                material.SetColor("_CatColor", gameSettings.visualSettings.currentPalette.specialCatColor2);
                break;
        }
    }
}
