﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseSc : MonoBehaviour
{

    private bool isActive;
    private GameObject pauseScreen;
    // Start is called before the first frame update
    void Start()
    {
        pauseScreen = GameObject.Find("PauseScreen");
        pauseScreen.SetActive(false);
        isActive = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Escape))
        {
            if (isActive)
            {
                pauseScreen.SetActive(false);
                isActive = false;
            }
            else
            {
                pauseScreen.SetActive(true);
                isActive = true;
            }
        }
    }

    public void ContinueGame()
    {
        pauseScreen.SetActive(false);
        isActive = false;
    }

}
