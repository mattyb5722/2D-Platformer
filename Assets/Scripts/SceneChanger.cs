using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
    /// <summary>
    /// Changes scenes
    /// </summary>
    public static SceneChanger instance = null; // Instance of class

    private void Awake()
    {
        // Creates instance of class
        if (instance == null){ instance = this; }
        else{ Destroy(gameObject); }
    }
    // Changes Scenes
    public void ChangeScene(string sceneName)
    {
        if (sceneName == "" || sceneName == null)
        {
            Debug.LogWarning("Empty Scene Name");
        }
        else if (sceneName == "Quit")              // Exits Game
        {
            //UnityEditor.EditorApplication.isPlaying = false;
            Application.Quit();
        } 
        else { SceneManager.LoadScene(sceneName); } // Loads new Scene
    }
}
