using UnityEngine;
using MyGameCollection.Localization;

public class MenuManager : MonoBehaviour
{
    private void OnEnable()
    {
        ButtonManager.clickButtonRussianAction += SetRussian;
        ButtonManager.clickButtonUrkainianAction += SetUkrainian;
        ButtonManager.clickButtonEnglishAction += SetEnglish;
    }

    public void SetEnglish()
    {
        AudioManager.Instance.PlayClip(Dictionary.nameAudioClipClick);
        Localize.SetCurrentLanguage(SystemLanguage.English);
        LocalizeImage.SetCurrentLanguage();
    }

    public void SetRussian()
    {
        AudioManager.Instance.PlayClip(Dictionary.nameAudioClipClick);
        Localize.SetCurrentLanguage(SystemLanguage.Russian);
        LocalizeImage.SetCurrentLanguage();
    }

    public void SetUkrainian()
    {
        AudioManager.Instance.PlayClip(Dictionary.nameAudioClipClick);
        Localize.SetCurrentLanguage(SystemLanguage.Ukrainian);
        LocalizeImage.SetCurrentLanguage();
    }
}
