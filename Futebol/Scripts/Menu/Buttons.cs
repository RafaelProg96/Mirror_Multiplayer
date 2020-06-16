using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Buttons : MonoBehaviour
{
    //Reference to the menu panels
    public GameObject howToPlay;
    public GameObject menu;

   public void Play()
    {
        //Load "Lobby" scene
        SceneManager.LoadScene("Lobby");
    }

    public void Instructions()
    {
        //Deactivate menu panel
        menu.SetActive(false);
        //Activate instructions panel
        howToPlay.SetActive(true);
    }

    public void Menu()
    {
        //Deactivate instructions panel
        howToPlay.SetActive(false);
        //Activate menu panel
        menu.SetActive(true);
    }

    public void Quit()
    {
        Application.Quit();
    }
}
