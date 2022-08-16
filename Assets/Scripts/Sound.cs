using UnityEngine;
using System.Collections;

public class Sound : MonoBehaviour {

    AudioSource[] music;
    AudioSource[] sounds;

    public AudioSource menuMusic;
    public AudioSource gameMusic;

    public AudioSource menuClick;
    public AudioSource popSound;
    public AudioSource coinSound;
    public AudioSource healthSound;

    public float musicVolume;

    Sound soundComponent;

    void Start()
    {
        music = new AudioSource[] { menuMusic, gameMusic };
        sounds = new AudioSource[] { popSound };
        soundComponent = GetComponent<Sound>();
    }

    public void AdjustMusicVolume(float volume)
    {
        foreach (AudioSource audio in music)
        {
            audio.volume = volume;
        }
    }

    public void AdjustSoundsVolume(float volume)
    {
        foreach (AudioSource audio in sounds)
        {
            audio.volume = volume;
        }
    }

    public void PlayMusic(AudioSource newMusic)
    {
        foreach (AudioSource audio in music)
        {
            if (audio.isPlaying) audio.Stop();
        }
        newMusic.Play();
    }

    public void PlayMenuMusic()
    {
        PlayMusic(menuMusic);
    }

    public void PlaySound(AudioSource sound, float pitchVar)
    {
        sound.pitch = 1 + Random.Range(-pitchVar, pitchVar);
        sound.Play();
    }

}
