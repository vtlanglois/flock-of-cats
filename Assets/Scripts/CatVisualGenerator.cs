using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static ShaderApplier;

public class CatVisualGenerator : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject[] dummyCats; //all the dummy cat visual prefab
    public PaletteItem paletteItem;
    GameObject selectedDummyCat; //the one chosen from the random selection

    public string parentTag;
    void Start()
    {
        parentTag = transform.parent.tag;

        /**
        paletteItem = (PaletteItem) Random.Range(0, 5);
        //using the randomly chosen paletteItem, set the selected dummy cat to one of 5 types
        switch (paletteItem)
        {
            case PaletteItem.Cat1:
                selectedDummyCat = dummyCats[0];
                break;
            case PaletteItem.Cat2:
                selectedDummyCat = dummyCats[1];
                break;
            case PaletteItem.Cat3:
                selectedDummyCat = dummyCats[2];
                break;
            case PaletteItem.SpecialCat1:
                selectedDummyCat = dummyCats[3];
                break;
            case PaletteItem.SpecialCat2:
                selectedDummyCat = dummyCats[4];
                break;
        }
        **/

        switch (parentTag)
        {
            case "mouse":
                selectedDummyCat = dummyCats[2];
                break;
            case "yarn":
                selectedDummyCat = dummyCats[1];
                break;
            case "fish":
                selectedDummyCat = dummyCats[0];
                break;
            case "none":
                selectedDummyCat = dummyCats[4];
                break;
            case "all":
                selectedDummyCat = dummyCats[3];
                break;
        }

        GameObject catChild = Instantiate(selectedDummyCat);
        catChild.transform.parent = gameObject.transform;
    }

}
