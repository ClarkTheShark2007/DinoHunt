using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum SoundType 
{
    SHOT,
    RELOAD,
    EMPTY,
    ROAR,
    MINIDIE,
    BOSS,
    FAIL,
    VICTORY

} 

[RequireComponent(typeof(AudioSource))]
public class SoundManger : MonoBehaviour
{
    [SerializeField] private AudioClip[] soundList;
    private static SoundManger instance;
    private AudioSource audioSource;

    private void Awake() 
    {
        instance = this;
    }

    private void Start() 
    {
        audioSource = GetComponent<AudioSource>();
    }

    public static void PlaySound(SoundType sound, float volume = 1) 
    {
        instance.audioSource.PlayOneShot(instance.soundList[(int)sound],volume);
    }
}
