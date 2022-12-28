using UnityEngine;

public class Settings_GM_MegaCube : MonoBehaviour
{
    private Animator _anim;
    private bool _isActive = false;

    private void Awake()
    {
        _anim = GetComponent<Animator>();
    }

    private void OnEnable()
    {
        Button_GM_MegaCube.clickButtonSettingsAction += SettingsActivated;
        Button_GM_MegaCube.clickButtonCloseSettingsAction += SettingsDisActivated;

        Debug.Log("Подписка на событие");
    }

    private void OnDisable()
    {
        Button_GM_MegaCube.clickButtonSettingsAction -= SettingsActivated;
        Button_GM_MegaCube.clickButtonCloseSettingsAction -= SettingsDisActivated;

        Debug.Log("Отписка на событие");
    }

    private void SettingsActivated()
    {
        AudioManager.Instance.PlayClip(Dictionary.nameAudioClipClick);
        _isActive = true;
        Button_GM_MegaCube.instance.buttonSttings.interactable = false;
        Button_GM_MegaCube.instance.buttonCloseSettings.interactable = true;
        _anim.SetBool(Dictionary.nameAnimClipSettingsMegaCube, _isActive);
    }

    private void SettingsDisActivated()
    {
        AudioManager.Instance.PlayClip(Dictionary.nameAudioClipClick);

        _isActive = false;
        Button_GM_MegaCube.instance.buttonSttings.interactable = true;
        Button_GM_MegaCube.instance.buttonCloseSettings.interactable = false;
        _anim.SetBool(Dictionary.nameAnimClipSettingsMegaCube, _isActive);
    }

    public void AudioClipShow()
    {
        AudioManager.Instance.PlayClip(Dictionary.nameAudioClipMegaCubeShowPanel);
    }
}
