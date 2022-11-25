using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Navigation : MonoBehaviour
{
    public void ChangeScene(string sceneName)       //Used to navigate between scenes
    {
        SceneManager.LoadScene(sceneName);
    }
    private void Update() {                         //Escape can quit the game
        if (Input.GetKeyDown(KeyCode.Escape)) {
            Application.Quit();
        }
    }
}
