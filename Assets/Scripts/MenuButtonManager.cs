﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuButtonManager : MonoBehaviour
{
    [SerializeField] GameObject mainMenu;
    [SerializeField] GameObject credits;
    [SerializeField] GameObject creditsTwo;
    [SerializeField] GameObject creditsThree;
    [SerializeField] GameObject instructions;
    public void StartGame() => SceneManager.LoadScene(1);

    public void QuitGame()
    {
        #if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
        #else
        Application.Quit();
        #endif
        //Note to self: Got this exit code from this website: https://answers.unity.com/questions/161858/startstop-playmode-from-editor-script.html
        //Must double-check if it actually works
    }

    public void MainMenu()
    {
        credits.SetActive(false);
        creditsTwo.SetActive(false);
        creditsThree.SetActive(false);
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

    public void Credits1()
    {
        credits.SetActive(true);
        creditsTwo.SetActive(false);
        creditsThree.SetActive(false);

    }

    public void Credits2()
    {
        credits.SetActive(false);
        creditsTwo.SetActive(true);
        creditsThree.SetActive(false);
    }

    public void Credits3()
    {
        credits.SetActive(false);
        creditsTwo.SetActive(false);
        creditsThree.SetActive(true);
    }

}
