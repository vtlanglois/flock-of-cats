using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Settings : MonoBehaviour
{
    public GameSettings gameSettings;
    public TextMeshProUGUI paletteName;
    public Toggle toggle;
    // Start is called before the first frame update
    void Start()
    {
        paletteName.text = gameSettings.visualSettings.currentPalette.name;
        toggle.isOn = gameSettings.controlSettings.isClickAndHoldEnabled;
    }

    public void ChangePaletteName()
    {
        Debug.Log("name change");
        paletteName.text = gameSettings.visualSettings.currentPalette.name;
    }

    public void ChangeClickAndHold()
    {
        Debug.Log("settigns change");
        gameSettings.controlSettings.isClickAndHoldEnabled = !gameSettings.controlSettings.isClickAndHoldEnabled;
    }
}
