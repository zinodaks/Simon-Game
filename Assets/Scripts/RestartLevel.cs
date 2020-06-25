﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RestartLevel : MonoBehaviour
{
    //Restarting a level or quiting the game 
    private Scene scene ;
   
    void Start()
    {
        scene = SceneManager.GetActiveScene();
    }
    public void Restart() {
        Application.LoadLevel(scene.name);
    }
    public void QuitGame(){
        Application.Quit();
    }
}