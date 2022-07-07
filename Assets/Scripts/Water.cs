using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Water : MonoBehaviour
{
    // Properties
    // Fields
    [SerializeField] private bool _waterKills = true;
    [Tooltip("Respawn position if _waterKills is false")]
    [SerializeField] private Vector2 _respawnPosition;
    [SerializeField] private AudioSource splashSound;

    private LevelMenu _levelMenu;

    // Unity Methods
    private void Start()
    {
        _levelMenu = FindObjectOfType<LevelMenu>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player")) {
            if (_waterKills)
            {
                collision.GetComponent<Animator>().SetBool("Dead", true);
                splashSound.Play();
                collision.GetComponent<Player>().enabled = false;
                _levelMenu.ActivateLoseMenu();
            }
            else
            {
                splashSound.Play();
                Player player = collision.GetComponent<Player>();
                player.GetComponent<LineRenderer>().enabled = false;
                player.GetComponent<DistanceJoint2D>().enabled = false;
                player.Grappling = false;
                collision.gameObject.transform.position = new Vector3( _respawnPosition.x, _respawnPosition.y, 0);   
            }
        }
    }
    // Other Methods
}
