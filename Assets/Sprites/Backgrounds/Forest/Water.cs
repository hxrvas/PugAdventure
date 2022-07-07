using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Water : MonoBehaviour
{
    public bool kill = true;
    public Movement player;
    public LevelMenu menu;
    public float x = 0;
    public float y = 0;

    [SerializeField] private AudioSource splashSound;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player")) {
            if (kill)
            {
                splashSound.Play();
                player.animator.SetBool("Dead", true);
                player.enabled = false;
                menu.activateLoseMenu();
            }
            else
            {
                splashSound.Play();
                Movement player = collision.GetComponent<Movement>();
                player.GetComponent<LineRenderer>().enabled = false;
                player.GetComponent<DistanceJoint2D>().enabled = false;
                player.isHanging = false;
                collision.gameObject.transform.position = new Vector3( x, y, 0);   
            }
        }
    }
}
