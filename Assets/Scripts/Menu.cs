using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Menu : MonoBehaviour
{
    // Properties
    // Fields
    [SerializeField] private float _waitSeconds = 1f;
    [SerializeField] private GameObject _levelsMenu;
    [SerializeField] private Button[] _levels;

    // Unity Methods
    public void Play()
    {
        FindObjectOfType<GameManager>().GetComponent<GameManager>().StopMusic();
        Invoke("LoadGame", _waitSeconds);
    }
    // Other Methods
    public void LoadGame()
    {
        SceneManager.LoadScene(GameManager.s_highestLevel+1);
        FindObjectOfType<GameManager>().GetComponent<GameManager>().LevelMusic();
    }

    public void OpenLevelsMenu()
    {
        _levelsMenu.SetActive(true);
        int unlockedLevels = GameManager.s_highestLevel;
        for (int i = 0; i < unlockedLevels; i++)
        {
            _levels[i].interactable = true;
        }
    }

    public void Tutorial()
    {
        FindObjectOfType<GameManager>().GetComponent<GameManager>().StopMusic();
        Invoke("LoadTutorial", _waitSeconds);
    }
    public void Level1()
    {
        FindObjectOfType<GameManager>().GetComponent<GameManager>().StopMusic();
        Invoke("Load1", _waitSeconds);
    }
    public void Level2()
    {
        FindObjectOfType<GameManager>().GetComponent<GameManager>().StopMusic();
        Invoke("Load2", _waitSeconds);
    }
    public void Level3()
    {
        FindObjectOfType<GameManager>().GetComponent<GameManager>().StopMusic();
        Invoke("Load3", _waitSeconds);
    }
    public void Level4()
    {
        FindObjectOfType<GameManager>().GetComponent<GameManager>().StopMusic();
        Invoke("Load4", _waitSeconds);
    }
    public void Level5()
    {
        FindObjectOfType<GameManager>().GetComponent<GameManager>().StopMusic();
        Invoke("Load5", _waitSeconds);
    }

    public void CloseLevelsMenu()
    {
        _levelsMenu.SetActive(false);
    }

    private void LoadTutorial()
    {
        SceneManager.LoadScene(2);
        FindObjectOfType<GameManager>().GetComponent<GameManager>().LevelMusic();
    }
    private void Load1()
    {
        SceneManager.LoadScene(3);
        FindObjectOfType<GameManager>().GetComponent<GameManager>().LevelMusic();
    }

    private void Load2()
    {
        SceneManager.LoadScene(4);
        FindObjectOfType<GameManager>().GetComponent<GameManager>().LevelMusic();
    }

    private void Load3()
    {
        SceneManager.LoadScene(5);
        FindObjectOfType<GameManager>().GetComponent<GameManager>().LevelMusic();
    }
    private void Load4()
    {
        SceneManager.LoadScene(6);
        FindObjectOfType<GameManager>().GetComponent<GameManager>().LevelMusic();
    }
    private void Load5()
    {
        SceneManager.LoadScene(7);
        FindObjectOfType<GameManager>().GetComponent<GameManager>().LevelMusic();
    }
}
