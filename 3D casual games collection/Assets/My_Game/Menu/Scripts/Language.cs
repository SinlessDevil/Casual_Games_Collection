using UnityEngine;

public class Language : MonoBehaviour
{
    private Animator _anim;
    private bool _isActive = false;

    private void Start(){
        _anim = GetComponent<Animator>();
    }

    private void OnEnable(){
        ButtonManager.clickButtonLanguageAction += LanguageActivated;
    }

    private void OnDisable(){
        ButtonManager.clickButtonLanguageAction -= LanguageActivated;
    }

    private void LanguageActivated(){

        if (!_isActive){
            _isActive = true;
        }else{
            _isActive = false;
        }

        AudioManager.Instance.PlayClip(Dictionary.nameAudioClipClick);
        _anim.SetBool(Dictionary.nameAnimClipLanguage, _isActive);
    }

    public void AudioclipShow()
    {
        AudioManager.Instance.PlayClip(Dictionary.nameAudioClipShopLanguagePanel);
    }

}
