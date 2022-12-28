using UnityEngine;
using System;
using UnityEngine.UI;

public class Button_GM_Color_Hole : MonoBehaviour
{
    #region Button Action Variabls
    // Action Buttons Panel Settings
    public static Action clickButtonSettingsAction;
    public static Action clickButtonSoundAction;
    public static Action clickButtonExitThePanelToMenuAction;
    public static Action clickButtonCloseSettingsAction;

    public static Action clickButtonExitToMenuAction;
    public static Action clickButtonRestartAndDeleteSaveAction;
    #endregion

    #region Singelton: Button_GM_MegaCube
    public static Button_GM_Color_Hole instance;

    private void Awake()
    {
        instance = this;
    }

    #endregion

    [Header("Button Panel Settings")]
    public Button buttonSettings;
    [SerializeField] private Button _buttonSound;
    [SerializeField] public Button _buttonExitThePanelToMenu;
    public Button buttonCloseSettings;
    [Space(10)]

    [Header("Panel and Game")]
    [SerializeField] private Button _buttonRestartAndDeleteSave;
    [SerializeField] private Button _buttonExitToMenu;

    private void Start()
    {
        AddAllListener();
    }

    #region Action Methods
    private void AddAllListener()
    {
        //Button Settings
        buttonSettings.onClick.RemoveAllListeners();
        buttonSettings.onClick.AddListener(OnSettingsButtonClick);

        _buttonSound.onClick.RemoveAllListeners();
        _buttonSound.onClick.AddListener(OnSoundButtonClick);

        _buttonExitThePanelToMenu.onClick.RemoveAllListeners();
        _buttonExitThePanelToMenu.onClick.AddListener(OnExitThePanelToMenuButtonClick);

        buttonCloseSettings.onClick.RemoveAllListeners();
        buttonCloseSettings.onClick.AddListener(OnCloseSettingsButtonClick);

        //Button End Panel 
        _buttonExitToMenu.onClick.RemoveAllListeners();
        _buttonExitToMenu.onClick.AddListener(OnExitToMenuButtonClick);

        _buttonRestartAndDeleteSave.onClick.RemoveAllListeners();
        _buttonRestartAndDeleteSave.onClick.AddListener(OnRestartAndDeleteSaveClick);
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

    private void OnExitToMenuButtonClick()
    {
        clickButtonExitToMenuAction?.Invoke();
    }

    private void OnRestartAndDeleteSaveClick()
    {
        clickButtonRestartAndDeleteSaveAction?.Invoke();
    }

    #endregion
}
