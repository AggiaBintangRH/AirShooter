using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu : MonoBehaviour
{
    public GameObject _panelPauseMenu;
    public GameObject _panelMainMenu;
    public void QuitGame()
    {
        Time.timeScale = 1;
        Application.Quit();
        
    }

    public void ResumeGame()
    {
        Time.timeScale = 1;
        _panelPauseMenu.SetActive(false);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Time.timeScale = 0;
            _panelPauseMenu.SetActive(true);
        }
    }
}
