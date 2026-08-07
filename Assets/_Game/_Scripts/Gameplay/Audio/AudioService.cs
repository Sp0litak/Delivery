using UnityEngine;

public class AudioService : MonoBehaviour
{
    [Header("Sources")]
    [SerializeField] private AudioSource _musicSource;
    [SerializeField] private AudioSource _sfxSource;

    [Header("Default Music")]
    [SerializeField] private AudioClip _backgroundMusic;

    [Header("SFX")]
    [SerializeField] private AudioClip _failSound;
    [SerializeField] private AudioClip _moneySound;
    [SerializeField] private AudioClip _spawnSound;
    [SerializeField] private AudioClip _cancelSound;

    public void Initialize()
    {
        DontDestroyOnLoad(gameObject);
        PlayMusic(_backgroundMusic);
    }

    public void PlayMusic(AudioClip clip, bool loop = true)
    {
        if (clip == null)
            return;

        _musicSource.clip = clip;
        _musicSource.loop = loop;
        _musicSource.Play();
    }

    public void StopMusic()
    {
        _musicSource.Stop();
    }

    public void PlayMoneySound()
    {
        _sfxSource.PlayOneShot(_moneySound);
    }

    public void PlayFailSound()
    {
        _sfxSource.PlayOneShot(_failSound);
    }
    public void PlaySpawnSound()
    {
        _sfxSource.PlayOneShot(_spawnSound);
    }
    public void PlayCancelSound()
    {
        _sfxSource.PlayOneShot(_cancelSound);
    }
}