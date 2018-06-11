using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathMenu : MonoBehaviour {

    private GameControl health;

    public GameObject DeathUI;
    private bool gameover = false;

    void Awake()
    {
        DeathUI.SetActive(false);
    }

    void Update()
    {
        if (GameControl.health <= 0)
        {
            DeathUI.SetActive(true);
            Time.timeScale = 0f;
            //gameover = !gameover;
        }

        if (!gameover)
        {
            DeathUI.SetActive(false);
            Time.timeScale = 1f;
        }
    }

    public void Restart()
    {
        SceneManager.LoadScene("Game");
    }

    public void Menu()
    {
        SceneManager.LoadScene("Menu");
    }
}
