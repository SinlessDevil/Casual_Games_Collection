using UnityEngine;
using UnityEngine.UI;
using System;

public class Button_GM_MegaCube : MonoBehaviour
{
    #region Button Action Variabls
    // Action Buttons Panel Settings
    public static Action clickButtonSettingsAction;
    public static Action clickButtonSoundAction;
    public static Action clickButtonExitThePanelToMenuAction;
    public static Action clickButtonCloseSettingsAction;

    //Action Buttons Pabel Win & Lose
    public static Action clickButtonExitToMenuAction;
    public static Action clickButtonRestartAction;
    #endregion

    #region Singelton: Button_GM_MegaCube
    public static Button_GM_MegaCube instance;

    private void Awake()
    {
        instance = this;
    }

    #endregion

    [Header("Button Panel Settings")]
    public Button buttonSttings;
    [SerializeField] private Button _buttonSound;
    [SerializeField] public Button _buttonExitThePanelToMenu;
    public Button buttonCloseSettings;
    [Space(10)]

    [Header("Button Panel Win & Lose")]
    [SerializeField] private Button _buttonExitToMenu;
    [SerializeField] private Button _buttonRestart;

    private void Start()
    {
        AddAllListener();
    }

    #region Action Methods
    private void AddAllListener()
    {
        //Button Settings add Listener
        buttonSttings.onClick.RemoveAllListeners();
        buttonSttings.onClick.AddListener(OnSettingsButtonClick);

        _buttonSound.onClick.RemoveAllListeners();
        _buttonSound.onClick.AddListener(OnSoundButtonClick);

        _buttonExitThePanelToMenu.onClick.RemoveAllListeners();
        _buttonExitThePanelToMenu.onClick.AddListener(OnExitThePanelToMenuButtonClick);

        buttonCloseSettings.onClick.RemoveAllListeners();
        buttonCloseSettings.onClick.AddListener(OnCloseSettingsButtonClick);

        //Button Panel Win & Lose
        _buttonExitToMenu.onClick.RemoveAllListeners();
        _buttonExitToMenu.onClick.AddListener(OnExitToMenuButtonClick);

        _buttonRestart.onClick.RemoveAllListeners();
        _buttonRestart.onClick.AddListener(OnRestartButtonClick);
    }

    #endregion

    #region ButtonClick Setting Methods

    private void OnSettingsButtonClick()
    {
        clickButtonSettingsAction?.Invoke();
    }

    private void OnSoundButtonClick()
    {
        clickButtonSoundAction?.Invoke();
    }

    private void OnExitThePanelToMenuButtonClick()
    {
        clickButtonExitThePanelToMenuAction?.Invoke();
    }

    private void OnCloseSettingsButtonClick()
    {
        clickButtonCloseSettingsAction?.Invoke();
    }

    #endregion

    #region ButtonClick Panel Win & Lose
    private void OnExitToMenuButtonClick()
    {
        clickButtonExitToMenuAction?.Invoke();
    }

    private void OnRestartButtonClick()
    {
        clickButtonRestartAction?.Invoke();
    }

    #endregion
}
