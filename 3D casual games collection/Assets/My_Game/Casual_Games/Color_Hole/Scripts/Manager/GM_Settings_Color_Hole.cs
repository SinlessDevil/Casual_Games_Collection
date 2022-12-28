using UnityEngine;

public class GM_Settings_Color_Hole : MonoBehaviour
{
    private Animator _anim;
    private bool _isActive = false;

    private void Awake()
    {
        _anim = GetComponent<Animator>();
    }

    private void OnEnable()
    {
        Button_GM_Color_Hole.clickButtonSettingsAction += SettingsActivated;
        Button_GM_Color_Hole.clickButtonCloseSettingsAction += SettingsDisActivated;

        Debug.Log("Подписка на событие");
    }

    private void OnDisable()
    {
        Button_GM_Color_Hole.clickButtonSettingsAction -= SettingsActivated;
        Button_GM_Color_Hole.clickButtonCloseSettingsAction -= SettingsDisActivated;

        Debug.Log("Отписка на событие");
    }

    private void SettingsActivated()
    {
        AudioManager.Instance.PlayClip(Dictionary.nameAudioClipClick);

        _isActive = true;
        Button_GM_Color_Hole.instance.buttonSettings.interactable = false;
        Button_GM_Color_Hole.instance.buttonCloseSettings.interactable = true;
        _anim.SetBool(Dictionary.nameAnimClipSettingsColorHole, _isActive);
    }

    private void SettingsDisActivated()
    {
        AudioManager.Instance.PlayClip(Dictionary.nameAudioClipClick);

        _isActive = false;
        Button_GM_Color_Hole.instance.buttonSettings.interactable = true;
        Button_GM_Color_Hole.instance.buttonCloseSettings.interactable = false;
        _anim.SetBool(Dictionary.nameAnimClipSettingsColorHole, _isActive);
    }

    public void AudioClipShow()
    {
        AudioManager.Instance.PlayClip(Dictionary.nameAudioClipMegaCubeShowPanel);
    }
}
