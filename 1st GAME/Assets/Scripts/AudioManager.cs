using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    private AudioSource audioController;
    [SerializeField] private AudioClip[] sounds;

    private void Awake()
    {
        audioController = GetComponent<AudioSource>();
    }

    public void AudioSelector(int index, float volume){
        audioController.PlayOneShot(sounds[index], volume);
    }
}
