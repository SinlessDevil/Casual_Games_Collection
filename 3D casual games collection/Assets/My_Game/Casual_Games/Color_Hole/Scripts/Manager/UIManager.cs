using UnityEngine;
using UnityEngine.UI;
using TMPro;
using DG.Tweening;
using UnityEngine.SceneManagement;
using System.Collections;

public class UIManager : MonoBehaviour
{
    #region Singleton class: UIManager

    public static UIManager Instance;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
    }

    #endregion

    [Header("Level Progress UI")]
    [SerializeField] private int _sceneOffset;
    [SerializeField] private TMP_Text _nextLevelText;
    [SerializeField] private TMP_Text _currentLevelText;
    [SerializeField] private Image _progressFillImage;
    [Space(10)]

    public int currentLevel;
    public int maxLevel;
    [Space(10)]

    [Header("Next Level UI")]
    [SerializeField] private TMP_Text _levelCompletedText;
    [SerializeField] private Image _fadePanel;
    [Space(10)]

    public GameObject panelNotMoreLevels;
    [Space(10)]

    [SerializeField] private TMP_Text _textPanelSettings;

    private void Start()
    {
        FadeAtStart();

        _progressFillImage.fillAmount = 0f;
        SetLevelProgressText();
    }

    private void OnEnable()
    {
        Button_GM_Color_Hole.clickButtonRestartAndDeleteSaveAction += DeleteAllLevels;
    }

    private void OnDisable()
    {
        Button_GM_Color_Hole.clickButtonRestartAndDeleteSaveAction -= DeleteAllLevels;
    }

    private void DeleteAllLevels()
    {
        StartCoroutine(CoroutineDeleteAllLevel());
    }

    private IEnumerator CoroutineDeleteAllLevel()
    {
        AudioManager.Instance.PlayClip(Dictionary.nameAudioClipClick);
        yield return new WaitForSeconds(0.1f);
        SavePlayerPrefs.Instance.DeleteASpecificSave(Dictionary.nameSaveLevelColorHole);
        string nameScene = Dictionary.nameSceneColorHole + (0).ToString();
        SceneManager.LoadScene(nameScene);
    }

    private void SetLevelProgressText()
    {
        currentLevel = SavePlayerPrefs.Instance.LoadInt(Dictionary.nameSaveLevelColorHole, currentLevel);

        _currentLevelText.text = currentLevel.ToString();
        _nextLevelText.text = (currentLevel + 1).ToString();

        string text = currentLevel.ToString() + "/" + maxLevel.ToString();
        _textPanelSettings.text = text;
    }

    public void UpdateLevelProgress()
    {
        AudioManager.Instance.PlayClip(Dictionary.nameAudioClipColorHoleTightening);
        Debug.Log(1f - ((float)Level.Instance.objectsInScene / Level.Instance.totalObjects));
        float val = 1f - ((float)Level.Instance.objectsInScene / Level.Instance.totalObjects);
        //_progressFillImage.fillAmount = val;
        _progressFillImage.DOFillAmount(val, 0.4f);
    }

    //-------------------------------------------------------------------------------

    public void ShowLevelCompletedUI()
    {
        AudioManager.Instance.PlayClip(Dictionary.nameAudioClipColorHoleWinGame);
        _levelCompletedText.gameObject.SetActive(true);
        _levelCompletedText.DOFade(1f, 0.6f).From(0f);
    }

    public void FadeAtStart()
    {
        _fadePanel.DOFade(0f, 1.3f).From(1f);
    }
}
