using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Menu : MonoBehaviour
{
    public float waitSeconds = 1f;

    public GameObject levelsMenu;
    public Button[] levels;
    public void play()
    {
        FindObjectOfType<GameManager>().GetComponent<GameManager>().stopMusic();
        Invoke("loadGame", waitSeconds);
    }

    public void loadGame()
    {
        SceneManager.LoadScene(GameManager.highestLevel+1);
        FindObjectOfType<GameManager>().GetComponent<GameManager>().levelMusic();
    }

    public void openLevelsMenu()
    {
        levelsMenu.SetActive(true);
        int unlockedLevels = GameManager.highestLevel;
        for (int i = 0; i < unlockedLevels; i++)
        {
            levels[i].interactable = true;
        }
    }

    public void tutorial()
    {
        FindObjectOfType<GameManager>().GetComponent<GameManager>().stopMusic();
        Invoke("loadTutorial", waitSeconds);
    }
    public void b1()
    {
        FindObjectOfType<GameManager>().GetComponent<GameManager>().stopMusic();
        Invoke("load1", waitSeconds);
    }
    public void b2()
    {
        FindObjectOfType<GameManager>().GetComponent<GameManager>().stopMusic();
        Invoke("load2", waitSeconds);
    }
    public void b3()
    {
        FindObjectOfType<GameManager>().GetComponent<GameManager>().stopMusic();
        Invoke("load3", waitSeconds);
    }
    public void b4()
    {
        FindObjectOfType<GameManager>().GetComponent<GameManager>().stopMusic();
        Invoke("load4", waitSeconds);
    }
    public void b5()
    {
        FindObjectOfType<GameManager>().GetComponent<GameManager>().stopMusic();
        Invoke("load5", waitSeconds);
    }

    public void closeLevelsMenu()
    {
        levelsMenu.SetActive(false);
    }

    public void loadTutorial()
    {
        SceneManager.LoadScene(2);
        FindObjectOfType<GameManager>().GetComponent<GameManager>().levelMusic();
    }
    public void load1()
    {
        SceneManager.LoadScene(3);
        FindObjectOfType<GameManager>().GetComponent<GameManager>().levelMusic();
    }

    public void load2()
    {
        SceneManager.LoadScene(4);
        FindObjectOfType<GameManager>().GetComponent<GameManager>().levelMusic();
    }

    public void load3()
    {
        SceneManager.LoadScene(5);
        FindObjectOfType<GameManager>().GetComponent<GameManager>().levelMusic();
    }
    public void load4()
    {
        SceneManager.LoadScene(6);
        FindObjectOfType<GameManager>().GetComponent<GameManager>().levelMusic();
    }
    public void load5()
    {
        SceneManager.LoadScene(7);
        FindObjectOfType<GameManager>().GetComponent<GameManager>().levelMusic();
    }
}
