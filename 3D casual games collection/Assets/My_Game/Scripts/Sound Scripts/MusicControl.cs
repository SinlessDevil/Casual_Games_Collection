using UnityEngine;
using UnityEngine.UI;
using System;
using System.Collections;

public class MusicControl : MonoBehaviour
{
    public enum TypeGame
    {
        Menu,
        Drop_The_Number,
        Color_Hole,
        Rollet_Splat,
        Helix_Jump,
        Voodoos_Stickly_Block
    }
    public TypeGame typeGame;

    [Header("Image Variabls")]
    [SerializeField] private Image _iconSound;
    [SerializeField] private Sprite _soundActiveIsTrue;
    [SerializeField] private Sprite _soundActiveIsFalse;
    [Space]
    [SerializeField] private AudioListener _audioListener;

    private bool _isActive = true;

    private void Start()
    {
        CheckSound();
    }

    private void OnEnable()
    {
        switch (typeGame)
        {
            case TypeGame.Menu:
                ButtonManager.clickButtonSoundAction += AudioControl;
                break;
            case TypeGame.Drop_The_Number:
                Button_GM_MegaCube.clickButtonSoundAction += AudioControl;
                break;
            case TypeGame.Color_Hole:
                Button_GM_Color_Hole.clickButtonSoundAction += AudioControl;
                break;
            case TypeGame.Rollet_Splat:
                Button_GM_Roll.clickButtonSoundAction += AudioControl;
                break;
            case TypeGame.Helix_Jump:
                break;
            case TypeGame.Voodoos_Stickly_Block:
                break;
        }
    }

    private void OnDisable()
    {
        switch (typeGame)
        {
            case TypeGame.Menu:
                ButtonManager.clickButtonSoundAction -= AudioControl;
                break;
            case TypeGame.Drop_The_Number:
                Button_GM_MegaCube.clickButtonSoundAction -= AudioControl;
                break;
            case TypeGame.Color_Hole:
                break;
            case TypeGame.Rollet_Splat:
                Button_GM_Roll.clickButtonSoundAction -= AudioControl;
                break;
            case TypeGame.Helix_Jump:
                break;
            case TypeGame.Voodoos_Stickly_Block:
                break;
        }
    }

    private void CheckSound()
    {
        int newIsActive = 1;
        newIsActive = SavePlayerPrefs.Instance.LoadInt(Dictionary.nameSaveAudio, newIsActive);
        _isActive = Convert.ToBoolean(newIsActive);

        if (_isActive){
            _iconSound.sprite = _soundActiveIsTrue;
            AudioListener.pause = false;
        }else{
            _iconSound.sprite = _soundActiveIsFalse;
            AudioListener.pause = true;
        }
    }

    private void AudioControl(){
        StartCoroutine(CoroutineBackToMenu());
    }

    private IEnumerator CoroutineBackToMenu()
    {
        AudioManager.Instance.PlayClip(Dictionary.nameAudioClipClick);
        yield return new WaitForSeconds(0.1f);
        if (_isActive)
        {
            _isActive = false;
            _iconSound.sprite = _soundActiveIsFalse;
            AudioListener.pause = true;
        }
        else
        {
            _isActive = true;
            _iconSound.sprite = _soundActiveIsTrue;
            AudioListener.pause = false;
        }
        SavePlayerPrefs.Instance.SaveInt(Dictionary.nameSaveAudio, Convert.ToInt32(_isActive));
    }
}
