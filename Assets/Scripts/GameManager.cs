using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class GameManager : MonoBehaviour
{
    // Properties
    public int HighestLevel 
    {
        get { return s_highestLevel; }
        set { s_highestLevel = value; }
    }
    // Fields
    [SerializeField] private AudioSource m_MenuMusic;
    [SerializeField] private AudioSource m_LevelMusic;
    public static int s_highestLevel = 1;
    // Unity Methods
    void Start()
    {
        DontDestroyOnLoad(gameObject);
        SceneManager.LoadScene(1);
    }
    
    //Other Methods
    public void SetLowLevel()
    {
        m_LevelMusic.volume = 0.05f;
        m_MenuMusic.volume = 0.05f;
    }
    public void SetHighLevel()
    {
        m_LevelMusic.volume = 0.1f;
        m_MenuMusic.volume = 0.1f;
    }

    public void LevelMusic() 
    {
        m_LevelMusic.Play();
        m_MenuMusic.Stop();
    }
    public void MenuMusic()
    {
        m_LevelMusic.Stop();
        m_MenuMusic.Play();
    }

    public void StopMusic()
    {
        m_LevelMusic.Stop();
        m_MenuMusic.Stop();
    }
}
