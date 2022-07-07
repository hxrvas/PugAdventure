using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Goal : MonoBehaviour
{

    public LevelMenu menu;

    [SerializeField] private AudioSource winSound;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
           winSound.Play();
           menu.activateWinMenu();
           int currentLevel = SceneManager.GetActiveScene().buildIndex - 1;
           if (GameManager.highestLevel < currentLevel + 1) ++GameManager.highestLevel;
           collision.gameObject.GetComponent<Movement>().enabled = false;
           collision.gameObject.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
           collision.gameObject.GetComponent<Animator>().enabled = false;
           collision.gameObject.tag = tag;
        }
    }
}
