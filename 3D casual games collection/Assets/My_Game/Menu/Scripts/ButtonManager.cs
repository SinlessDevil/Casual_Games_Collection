using UnityEngine.UI; 
using UnityEngine;
using System;

public class ButtonManager : MonoBehaviour
{
    #region Button Action Variabls
    // Action Game Buttons
    public static Action clickButtonDropTheNumberAction;
    public static Action clickButtonColorHolerAction;
    public static Action clickButtoVoodoosSticklyBlockAction;
    public static Action clickButtonRollerSplatAction;
    public static Action clickButtonHelixJumpAction;
    // Menu Buttons
    public static Action clickButtonExitAction;
    public static Action clickButtonLanguageAction;
    public static Action clickButtonSoundAction;
    //Language Buttons
    public static Action clickButtonUrkainianAction;
    public static Action clickButtonRussianAction;
    public static Action clickButtonEnglishAction;
    #endregion

    [Header("Game Buttons")]
    [SerializeField] private Button _buttonGameDropTheNumber;
    [SerializeField] private Button _buttonGameColorHole;
    [SerializeField] private Button _buttonGameDVoodoosStiklyBlock;
    [SerializeField] private Button _buttonGameRollerSplat;
    [SerializeField] private Button _buttonGameHelixJump;
    [Space(20)]

    [Header("Menu Buttons")]
    [SerializeField] private Button _buttonExit;
    [SerializeField] private Button _buttonLanguage;
    [SerializeField] private Button _buttonSound;
    [Space(20)]

    [Header("Language Buttons")]
    [SerializeField] private Button _buttonUkrainian;
    [SerializeField] private Button _buttonRussian;
    [SerializeField] private Button _buttonEnglish;

    private void Start()
    {
        RemoveAllListener();

        AddAllListener();
    }

    #region Action Methods
    private void AddAllListener()
    {
        //Game Button Add Listener
        _buttonGameDropTheNumber.onClick.AddListener(OnGameDropTheNumberButtonClick);
        _buttonGameColorHole.onClick.AddListener(OnGameColorHoleButtonClick);
        _buttonGameDVoodoosStiklyBlock.onClick.AddListener(OnGameDVoodoosStiklyBlockButtonClick);
        _buttonGameRollerSplat.onClick.AddListener(OnGameRollerSplatButtonClick);
        _buttonGameHelixJump.onClick.AddListener(OnGameHelixJumpButtonClick);

        //Menu Button Add Listener
        _buttonExit.onClick.AddListener(OnExitButtonClick);
        _buttonLanguage.onClick.AddListener(OnLanguagButtonClick);
        _buttonSound.onClick.AddListener(OnSoundButtonClick);

        //Language Button Add Listener
        _buttonUkrainian.onClick.AddListener(OnUkrainianButtonClick);
        _buttonRussian.onClick.AddListener(OnRussianButtonClick);
        _buttonEnglish.onClick.AddListener(OnEnglishButtonClick);
    }
    private void RemoveAllListener()
    {
        //Game Button Remove Listener
        _buttonGameDropTheNumber.onClick.RemoveAllListeners();
        _buttonGameColorHole.onClick.RemoveAllListeners();
        _buttonGameDVoodoosStiklyBlock.onClick.RemoveAllListeners();
        _buttonGameRollerSplat.onClick.RemoveAllListeners();
        _buttonGameHelixJump.onClick.RemoveAllListeners();

        //Menu Button Remove Listener
        _buttonExit.onClick.RemoveAllListeners();
        _buttonLanguage.onClick.RemoveAllListeners();
        _buttonSound.onClick.RemoveAllListeners();

        //Language Button Remove Listener
        _buttonUkrainian.onClick.RemoveAllListeners();
        _buttonRussian.onClick.RemoveAllListeners();
        _buttonEnglish.onClick.RemoveAllListeners();
    }
    #endregion

    #region Game ButtonClick Methods
    private void OnGameDropTheNumberButtonClick()
    {
        clickButtonDropTheNumberAction?.Invoke();
    }

    private void OnGameColorHoleButtonClick()
    {
        clickButtonColorHolerAction?.Invoke();
    }

    private void OnGameDVoodoosStiklyBlockButtonClick()
    {
        clickButtoVoodoosSticklyBlockAction?.Invoke();
    }

    private void OnGameRollerSplatButtonClick()
    {
        clickButtonRollerSplatAction?.Invoke();
    }

    private void OnGameHelixJumpButtonClick()
    {
        clickButtonHelixJumpAction?.Invoke();
    }
    #endregion

    #region Menu ButtonClick Methods
    private void OnExitButtonClick()
    {
        clickButtonExitAction?.Invoke();
    }

    private void OnLanguagButtonClick()
    {
        clickButtonLanguageAction?.Invoke();
    }

    private void OnSoundButtonClick()
    {
        clickButtonSoundAction?.Invoke();
    }
    #endregion

    #region Language ButtonClick Methods
    private void OnUkrainianButtonClick()
    {
        clickButtonUrkainianAction?.Invoke();
    }

    private void OnRussianButtonClick()
    {
        clickButtonRussianAction?.Invoke();
    }

    private void OnEnglishButtonClick()
    {
        clickButtonEnglishAction?.Invoke();
    }
    #endregion
}
