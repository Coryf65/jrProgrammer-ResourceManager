using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
#if UNITY_EDITOR
using UnityEditor;
#endif

// Sets the script to be executed later than all default scripts
// This is helpful for UI, since other things may need to be initialized before setting the UI
[DefaultExecutionOrder(1000)]
public class MenuUIHandler : MonoBehaviour
{
    public ColorPicker ColorPicker;

    public void NewColorSelected(Color color)
    {
        MainManager.Instance.TeamColor = color;
    }
    
    private void Start()
    {
        ColorPicker.Init();
        //this will call the NewColorSelected function when the color picker have a color button clicked.
        ColorPicker.onColorChanged += NewColorSelected;

        ColorPicker.SelectedColor(MainManager.Instance.TeamColor);

        ColorPicker.SelectedColor = Color.black;
    }
    
    /// <summary>
    /// Test code for color picking
    /// </summary>
    public void SaveColorClicked()
    {
        MainManager.Instance.SaveColor();
    }

    /// <summary>
    /// Test code for color picking
    /// </summary>
    public void LoadColorClicked()
    {
        MainManager.Instance.LoadColor();
        ColorPicker.SelectColor(MainManager.Instance.TeamColor);
    }

    /// <summary>
    /// Start a new game loading the main scene
    /// </summary>
    public void StartNew()
    {
        SceneManager.LoadScene(1);
    }

    /// <summary>
    /// Quit/Exit the Game in the editor or not
    /// </summary>
    public void Quit()
    {
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit(); // original code to quit Unity player
#endif
        MainManager.Instance.SaveColor();
    }
}
