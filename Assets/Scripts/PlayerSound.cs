using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSound : MonoBehaviour
{
    // Properties
    // Fields
    [SerializeField] private AudioClip[] _steps;
    [SerializeField] private AudioSource _stepSource;
    [SerializeField] private AudioSource _cookieSource;
    [SerializeField] private AudioSource _jumpSource;
    // Unity Methods
    // Other Methods
    AudioClip SelectRandomStep()
    {
        int i = Random.Range(0, _steps.Length);
        return _steps[i];
    }

    public void PlayStep()
    {
        _stepSource.clip = SelectRandomStep();
        _stepSource.Play();
    }

    public void PlayCookie()
    {
        _cookieSource.Play();
    }

    public void PlayJump()
    {
        _jumpSource.Play();
    }
}
