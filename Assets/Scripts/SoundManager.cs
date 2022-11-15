using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class SoundManager : MonoBehaviour
{
    [SerializeField] private AudioClip music;
    [SerializeField] private AudioClip gunSFX;
    [SerializeField] private AudioClip enemyRunSFX;
    [SerializeField] private AudioClip enemyAttackSFX;
    public AudioSource volumen;

    private AudioSource sound;

    public static SoundManager instance;

    private void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
        }
        else instance = this;

        DontDestroyOnLoad(gameObject);
    }

    private void Start()
    {
        sound = GetComponent<AudioSource>();
    }

    public void PlayGunSFX()
    {
        sound.PlayOneShot(gunSFX);
    }
}
