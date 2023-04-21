using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    public GameObject settingsMenu;
    public GameSettings gameSettings;
    public GameObject gameOver;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P) && settingsMenu.active == false)
        {
            settingsMenu.SetActive(true);
            gameSettings.gameplaySettings.currentTimeScale = Time.timeScale;
            Time.timeScale = 0;

        }
        else if (Input.GetKeyDown(KeyCode.P) && settingsMenu.active)
        {
            settingsMenu.SetActive(false);
            Time.timeScale = gameSettings.gameplaySettings.currentTimeScale;
        }

        if(Time.timeScale <= 0 && settingsMenu.active == false)
        {
            StartGameOver();
        }
    }

    public void StartGameOver()
    {
        Debug.Log("game over");
        gameOver.SetActive(true);
    }
}
