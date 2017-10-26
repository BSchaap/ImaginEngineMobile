using System.Collections;
using System.Collections.Generic;
using UnityStandardAssets.CrossPlatformInput;
using UnityEngine;

public class PauseGame : MonoBehaviour {

    public Transform canvas;
    public Transform pauseMenu;
    public Transform optionsMenu;
	
	// Update is called once per frame
	void Update () {
        if (CrossPlatformInputManager.GetButtonDown("Menu"))
        {
            Pause();
        }
	}

    public void Pause()
    {
        //This checks if the pause menu is already open
        if (canvas.gameObject.activeInHierarchy == false)
        {
            if(pauseMenu.gameObject.activeInHierarchy == false)
            {
                //Wa activate just the pause menu, we close all the other menus
                pauseMenu.gameObject.SetActive(true);
                optionsMenu.gameObject.SetActive(false);
            }
            //If it isnt open, open it
            canvas.gameObject.SetActive(true);
            //Sets the timescale to 0 so that nothing moves when you are in the pause menu
            Time.timeScale = 0;
            optionsMenu.gameObject.SetActive(false);
        }
        else
        {
            canvas.gameObject.SetActive(false);
            Time.timeScale = 1;
        }
    }
    public void Options(bool open)
    {
        if (open)
        {
            optionsMenu.gameObject.SetActive(true);
            
        } else
        {
            optionsMenu.gameObject.SetActive(false);
        }


    }
}
