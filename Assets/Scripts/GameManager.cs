using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class GameManager : MonoBehaviour
{
    [SerializeField] private AudioSource m_MenuMusic;
    [SerializeField] private AudioSource m_LevelMusic;

    void Start()
    {
        DontDestroyOnLoad(gameObject);
        SceneManager.LoadScene(1);
    }

    public static int highestLevel = 1;

    public void setLowLevel()
    {
        m_LevelMusic.volume = 0.05f;
        m_MenuMusic.volume = 0.05f;
    }
    public void setHighLevel()
    {
        m_LevelMusic.volume = 0.1f;
        m_MenuMusic.volume = 0.1f;
    }

    public void levelMusic() 
    {
        m_LevelMusic.Play();
        m_MenuMusic.Stop();
    }

    public void stopMusic()
    {
        m_LevelMusic.Stop();
        m_MenuMusic.Stop();
    }

    public void menuMusic() 
    {
        m_LevelMusic.Stop();
        m_MenuMusic.Play();
    }
}
