using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonSelection : MonoBehaviour
{
    public GameObject mainMenu;             // Holds the MainMenu canvas
    public GameObject helpMenu;             // Holds the HelpMenu canvas
    public GameObject creditsMenu;          // Holds the Credits canvas

    /// <summary>
    /// Used for starting the game
    /// </summary>
    public void StartGame()
    {
        // Loads the Gameplay Scene
        SceneManager.LoadScene("Gameplay");
    }

    /// <summary>
    /// Used to navigate to the Help Menu
    /// </summary>
    public void HelpMenu()
    {
        if (mainMenu.activeSelf == true)
        {
            mainMenu.SetActive(false);
            helpMenu.SetActive(true);
        }
        else if (helpMenu.activeSelf == true)
        {
            mainMenu.SetActive(true);
            helpMenu.SetActive(false);
        }
    }

    public void CreditsMenu()
    {
        if (helpMenu.activeSelf == true)
        {
            creditsMenu.SetActive(true);
            helpMenu.SetActive(false);
        }
        else if (creditsMenu.activeSelf == true)
        {
            helpMenu.SetActive(true);
            creditsMenu.SetActive(false);
        }
    }

    /// <summary>
    /// Used to Quit the game
    /// </summary>
    public void QuitGame()
    {
        // Quits the game
        Application.Quit();
    }
}
