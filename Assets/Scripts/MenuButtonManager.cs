using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuButtonManager : MonoBehaviour
{
    [SerializeField] GameObject mainMenu;
    [SerializeField] GameObject credits;
    [SerializeField] GameObject instructions;
    public void StartGame() => SceneManager.LoadScene(1);

    public void QuitGame()
    {
        #if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
        #else
        Application.Quit()
        #endif
        //Note to self: Got this exit code from this website: https://answers.unity.com/questions/161858/startstop-playmode-from-editor-script.html
        //Must double-check if it actually works
    }

    public void MainMenu()
    {
        credits.SetActive(false);
        instructions.SetActive(false);
        mainMenu.SetActive(true);
    }

    public void Credits()
    {
        mainMenu.SetActive(false);
        credits.SetActive(true);
    }

    public void Instructions()
    {
        mainMenu.SetActive(false);
        instructions.SetActive(true);
    }

}
