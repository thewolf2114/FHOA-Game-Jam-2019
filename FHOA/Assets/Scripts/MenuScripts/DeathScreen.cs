using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathScreen : MonoBehaviour
{
    public void OnPlayButtonClick()
    {
        // reset the time scale
        Time.timeScale = 1;

        // turn off the death screen
        gameObject.SetActive(false);

        // restart the game
        SceneManager.LoadScene("Gameplay");
    }

    public void OnQuitButtonClick()
    {
        // reset time scale
        Time.timeScale = 1;

        // turn off the death screen
        gameObject.SetActive(false);

        // go to the main menu
        SceneManager.LoadScene("MainMenu");
    }
}
