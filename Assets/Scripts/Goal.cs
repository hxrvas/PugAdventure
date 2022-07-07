using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Goal : MonoBehaviour
{
    //Properties
    //Fields
    private AudioSource _winSound;
    private LevelMenu _levelMenu;

    // Unity Methods
    private void Awake()
    {
        _winSound = GetComponent<AudioSource>();
        _levelMenu = FindObjectOfType<LevelMenu>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
           _winSound.Play();
           _levelMenu.ActivateWinMenu();
           int currentLevel = SceneManager.GetActiveScene().buildIndex - 1;
           if (GameManager.s_highestLevel < currentLevel + 1) ++GameManager.s_highestLevel;
           collision.gameObject.GetComponent<Player>().enabled = false;
           collision.gameObject.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
           collision.gameObject.GetComponent<Animator>().enabled = false;
           collision.gameObject.tag = tag;
        }
    }
    // Other Methods
}
