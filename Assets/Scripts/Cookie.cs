using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cookie : MonoBehaviour
{
    // Properties 
    // Fields
    bool _pointsGiven = false;
    // Unity Methods 
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && !_pointsGiven)
        {
            _pointsGiven = true;
            Player player = collision.gameObject.GetComponent<Player>();
            player.AddCookie();
            Destroy(this.gameObject);
        }
    }
}
