using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grappler : MonoBehaviour
{
    public LineRenderer lineRenderer;
    public DistanceJoint2D distanceJoint;
    public Movement player;
    public Transform tonguePoint;
    bool mouseOver = false;
    bool active = false;

    public AudioSource grappleSound;
    public AudioSource retractSound;
    // Start is called before the first frame update
    void Start()
    {
        distanceJoint.enabled = false;
    }

    // Update is called once per frame
    void OnMouseOver()
    {
        mouseOver = true;
    }

    private void OnMouseExit()
    {
        mouseOver = false;
    }

    private void Update()
    {

        if (Input.GetKeyDown(KeyCode.Mouse0) && mouseOver)
        {
            grappleSound.Play();
            lineRenderer.SetPosition(0, transform.position);
            lineRenderer.SetPosition(1, tonguePoint.position);
            distanceJoint.connectedAnchor = transform.position;
            distanceJoint.enabled = true;
            lineRenderer.enabled = true;
            player.isHanging = true;
            distanceJoint.distance = Vector2.Distance(tonguePoint.position, transform.position);
            active = true;
        }
        else if (Input.GetKeyUp(KeyCode.Mouse0))
        {
            retractSound.Stop();
            distanceJoint.enabled = false;
            lineRenderer.enabled = false;
            player.isHanging = false;
            active = false;
        }

        if (active)
        {
            if ((Input.GetKeyDown (KeyCode.Mouse1))) retractSound.Play();
            if (Input.GetKey(KeyCode.Mouse1))
            {
                
                distanceJoint.distance = 1f;
            }

            else if (Input.GetKeyUp(KeyCode.Mouse1))
            {
                retractSound.Stop();
                distanceJoint.distance = Vector2.Distance(tonguePoint.position, transform.position);
            }

            lineRenderer.SetPosition(1, tonguePoint.position);
        }
    }
}
