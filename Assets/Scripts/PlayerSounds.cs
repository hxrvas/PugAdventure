using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSounds : MonoBehaviour
{
    [SerializeField]
    private AudioClip[] steps;
    [SerializeField]
    private AudioSource stepSource;
    [SerializeField]
    private AudioSource cookieSource;
    [SerializeField]
    private AudioSource jumpSource;

    AudioClip selectRandomStep()
    {
        int i = Random.Range(0, steps.Length);
        return steps[i];
    }

    public void playStep()
    {
        stepSource.clip = selectRandomStep();
        stepSource.Play();
    }

    public void playCookie()
    {
        cookieSource.Play();
    }

    public void playJump()
    {
        jumpSource.Play();
    }
}
