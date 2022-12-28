using UnityEngine.Audio;
using UnityEngine;
using System;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;

    #region TypeScene
    public TypeScene typescene;
    public enum TypeScene
    {
        Menu,
        Drop_the_Number,
        Color_Hole,
        Voodoos_Sticky_Block,
        Roller_Splat,
        Helix_Jump
    }
    #endregion

    public Sound[] sounds;
    private void Awake()
    {
        Instance = this;

        foreach (Sound s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;

            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
            s.source.loop = s.loop;
            s.source.playOnAwake = s.playOnAwake;
        }
    }

    private void Start()
    {
        switch (typescene)
        {
            case TypeScene.Menu:
                PlayClip(Dictionary.nameAudioClipMenu);
                break;
            case TypeScene.Drop_the_Number:
                PlayClip(Dictionary.nameAudioClipSoundMegaCube);
                break;
            case TypeScene.Color_Hole:
                PlayClip(Dictionary.nameAudioClipSoundColorHole);
                break;
            case TypeScene.Voodoos_Sticky_Block:
                break;
            case TypeScene.Roller_Splat:
                PlayClip(Dictionary.nameAudioClipSoundRollerSplat);
                break;
            case TypeScene.Helix_Jump:
                break;
        }
    }

    #region Clip Methods

    public void PlayClip(string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        if (s == null)
        {
            Debug.LogWarning("Sound:" + name + "not found!");
            return;
        }
        s.source.Play();
    }
    public void StopClip(string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        if (s == null)
        {
            Debug.LogWarning("Sound:" + name + "not found!");
            return;
        }
        s.source.Stop();
    }

    #endregion

    #region Volume Methods

    public void VolumeController(string name, bool typeMode)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        if (typeMode == true)
        {
            s.source.volume = s.source.volume / 2.5f;
        }
        else
        {
            s.source.volume = s.source.volume * 2.5f;
        }
    }

    #endregion
}
