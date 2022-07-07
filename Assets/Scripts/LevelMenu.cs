using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelMenu : MonoBehaviour
{
    public GameObject pauseMenu;
    public GameObject winMenu;
    public GameObject loseMenu;
    public Image[] stars;
    public Sprite fullStar;
    public Movement player;
    public int StarPoints1;
    public int StarPoints2;
    public int StarPoints3;
    bool gamePaused;

    GameManager gameManager;

    void Start()
    {
        gameManager = FindObjectOfType<GameManager>().GetComponent<GameManager>();
        gamePaused = false;
    }

    public void togglePauseMenu()
    {
        gamePaused = !gamePaused;

        if (gamePaused)
        {
            gameManager.setLowLevel();
            player.enabled = false;
            pauseMenu.SetActive(true);
            Time.timeScale = 0;
        }
        else
        {
            gameManager.setHighLevel();
            player.enabled = true;
            pauseMenu.SetActive(false);
            Time.timeScale = 1;
        }
    }

    public void activateWinMenu()
    {
        gameManager.setLowLevel();
        Time.timeScale = 0;
        player.enabled = false;
        winMenu.SetActive(true);

        if (player.cookies >= StarPoints1)
        {
            stars[2].sprite = fullStar;
        }

        if (player.cookies >= StarPoints2)
        {
            stars[1].sprite = fullStar;
        }

        if (player.cookies >= StarPoints3)
        {
            stars[0].sprite = fullStar;
        }
    }

    public void activateLoseMenu()
    {
        gameManager.setLowLevel();
        loseMenu.SetActive(true);
    }


    public void nextLevel()
    {
        gameManager.stopMusic();
        gameManager.setHighLevel();
        Time.timeScale = 1;
        Invoke("loadNextLevel", 1f);
    }

    public void restart()
    {
        gameManager.stopMusic();
        gameManager.setHighLevel();
        loadCurrentLevel();
    }

    public void mainMenu()
    {
        gameManager.stopMusic();
        gameManager.setHighLevel();
        loadMainMenu();
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab) && !winMenu.activeSelf)
        {
            togglePauseMenu();
        }
    }

    public void loadMainMenu() 
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(1);
        gameManager.menuMusic();
    }
    public void loadNextLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        gameManager.levelMusic();
    }

    public void loadCurrentLevel()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        gameManager.levelMusic();
    }

}
