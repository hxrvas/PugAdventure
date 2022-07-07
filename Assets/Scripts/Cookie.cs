using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cookie : MonoBehaviour
{
    bool pointsGiven = false;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && !pointsGiven)
        {
            pointsGiven = true;
            Movement player = collision.gameObject.GetComponent<Movement>();
            player.addCookie();
            player.displayPoints();
            Destroy(this.gameObject);
        }
    }
}
