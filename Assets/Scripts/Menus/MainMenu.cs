using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


/// <summary>
/// Main menu functionality for buttons. 
/// </summary>
/// 
public class MainMenu : MonoBehaviour
{
    /// <summary>
    /// Awake() assigns objects and buttons and adds listeners for presses.
    /// </summary>
    private void Awake()
    {
        // Find the container for the buttons
        var buttons = transform.Find("ButtonMenu");

        // Find specific buttons in the buttons container
        var startButton = buttons.Find("PlayButton").GetComponent<Button>();
        var settingsButton = buttons.Find("SettingsButton").GetComponent<Button>();
        var quitButton = buttons.Find("QuitButton").GetComponent<Button>();

        // Method calls on click for button functionality
        startButton.onClick.AddListener(StartGame);
        startButton.onClick.AddListener(EditSettings);
        quitButton.onClick.AddListener(QuitGame);
    }



    /// <summary>
    /// StartGame() loads the scene to start the game.  
    /// </summary>
    private void StartGame()
    {
        SceneManager.LoadScene(1);
    }


    /// <summary>
    /// EditSettings() provides the settings menu for editing game properties.  
    /// </summary>
    private void EditSettings()
    {
        Debug.Log("TODO: Add a settings menu.");
    }


    /// <summary>
    /// QuitGame() either stops the editor or quits the build application
    /// using conditional compilation.
    /// The #if section is determined before compiling for respective builds.
    /// </summary>
    private void QuitGame()
    {
        // Check if running in editor or as a standalone build
#if UNITY_EDITOR
        {
            // Editor is running, stop the editor
            EditorApplication.isPlaying = false;
        }
#else
        {
            // Quit the standalone build
            Application.Quit();
        }
#endif
    }

}