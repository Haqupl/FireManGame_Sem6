﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameMenu : MonoBehaviour
{

    public Canvas menu;
    private GameObject popupExitQuest;

    // Use this for initialization
    void Start()
    {
        popupExitQuest = menu.transform.GetChild(2).gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        if (SceneManager.GetActiveScene().name != "MenuScene")
        {
            if (Input.GetKeyDown(KeyCode.Escape))
                menu.gameObject.SetActive(!menu.gameObject.activeSelf);
            
            if (!menu.gameObject.activeSelf)
                Time.timeScale = 1f;
            else
                Time.timeScale = 0f;
        }
    }

    public void StartGame(int indexScene)
    {
        menu.gameObject.SetActive(false);
        SceneManager.LoadScene(indexScene);
    }

    public void ExitGameQuest()
    {
        popupExitQuest.SetActive(true);
    }

    public void ExitGame()
    {
        Application.Quit();
    }

    public void ExitPopupMenuQuest()
    {
        popupExitQuest.SetActive(false);
    }



}
