using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;




public class PauseMenu : MonoBehaviour
{
    [SerializeField]
    private GameObject pauseCanvas;

    /// <summary>
    /// Awake() assigns objects and buttons and adds listeners for presses.
    /// </summary>
    private void Awake()
    {
        // Find the container for the buttons and pause menu
        var buttons = pauseCanvas.transform.Find("ButtonMenu");

        // Find specific buttons in the buttons container
        var resumeButton = buttons.Find("ResumeButton").GetComponent<Button>();
        var settingsButton = buttons.Find("SettingsButton").GetComponent<Button>();
        var quitButton = buttons.Find("QuitButton").GetComponent<Button>();

        // Method calls on click for button functionality
        resumeButton.onClick.AddListener(TogglePauseMenu);
        settingsButton.onClick.AddListener(EditSettings);
        quitButton.onClick.AddListener(QuitGame);
    }




    /// <summary>
    /// Update() looks for an Escape key press and toggles the pause menu.  
    /// </summary>
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            TogglePauseMenu();
        }
    }

    /// <summary>
    /// TogglePauseMenu() pauses or resumes the game.  
    /// </summary>
    private void TogglePauseMenu()
    {
        // Toggles the visibility of the Pause Menu Canvas game object
        pauseCanvas.SetActive(!pauseCanvas.activeInHierarchy);

        // TODO add game pausing functionality
    }



    /// <summary>
    /// EditSettings() provides the settings menu for editing game properties.  
    /// </summary>
    private void EditSettings()
    {

        // TODO call the settings menu, write a seperate script for settings,
        // ensure changes are saved and the game state is cleanly resumed

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
