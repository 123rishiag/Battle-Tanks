using System;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    private static SoundManager instance;
    public static SoundManager Instance { get { return instance; } }

    [HideInInspector] public bool isMute = false;

    [SerializeField] private AudioSource soundEffect; // Audio source for sound effects
    [SerializeField] private AudioSource soundMusic; // Audio source for background music
    [SerializeField] private Sound[] sounds; // Array of sound clips

    private float currentEffectVolume;
    private float currentMusicVolume;
    private SoundType currentMusic;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject); // Persist SoundManager across scenes
        }
        else
        {
            Destroy(gameObject); // Ensure only one instance exists
        }
    }

    private void Start()
    {
        PlayMusic(SoundType.BackgroundMusic); // Play background music
        currentEffectVolume = soundEffect.volume;
        currentMusicVolume = soundMusic.volume;
    }

    public void MuteGame(bool _flag)
    {
        SetVolume(_flag ? 0.0f : currentEffectVolume, _flag ? 0.0f : currentMusicVolume);
    }

    public void SetVolume(float newEffectVolume, float newMusicVolume)
    {
        currentEffectVolume = newEffectVolume == 0.0f ? soundEffect.volume : newEffectVolume;
        currentMusicVolume = newMusicVolume == 0.0f ? soundMusic.volume : newMusicVolume;
        soundEffect.volume = newEffectVolume;
        soundMusic.volume = newMusicVolume;
    }

    public void PlayMusic(SoundType soundType, bool shouldLoop = true)
    {
        if (isMute) return;

        if(soundType == currentMusic) return;

        AudioClip soundClip = GetSoundClip(soundType);
        if (soundClip != null)
        {
            currentMusic = soundType;
            soundMusic.clip = soundClip;
            soundMusic.loop = shouldLoop;
            soundMusic.Play();
        }
        else
        {
            Debug.LogWarning("Did not find any Sound Clip for selected Sound Type");
        }
    }

    public void PlayEffect(SoundType soundType)
    {
        if (isMute) return;

        AudioClip soundClip = GetSoundClip(soundType);
        if (soundClip != null)
        {
            soundEffect.PlayOneShot(soundClip);
        }
        else
        {
            Debug.LogWarning("Did not find any Sound Clip for selected Sound Type");
        }
    }

    private AudioClip GetSoundClip(SoundType soundType)
    {
        Sound sound = Array.Find(sounds, item => item.soundType == soundType);
        return sound?.soundClip;
    }
}

[Serializable]
public class Sound
{
    public SoundType soundType;
    public AudioClip soundClip;
}

public enum SoundType
{
    ButtonClick,
    ButtonQuit,
    GameStart,
    GamePause,
    GameOver,
    BulletShoot,
    BulletExplosion,
    TankExplosion,
    BackgroundMusic,
    EngineIdle,
    EngineDrive,
}