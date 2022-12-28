using UnityEngine;
using UnityEngine.UI;
using TMPro;
using DG.Tweening;
using UnityEngine.SceneManagement;
using System.Collections;

public class GM_Roller_Splat : MonoBehaviour
{
    [Header("ProgressBar Variabls")]
    [SerializeField] private TMP_Text _textCurrentLevel;
    [SerializeField] private TMP_Text _textNextLevel;
    [SerializeField] private TMP_Text _textPanelLevel;
    [SerializeField] private Image _progressFillImage;
    [HideInInspector] public int _currentLevel = 0;
    public int _maxLevel = 4;
    [Space(10)]

    [Header("Level Completed Variabls")]
    [SerializeField] private TMP_Text _levelCompletedText;
    [SerializeField] private Image _fadePanel;
    [SerializeField] private ParticleSystem _winFX;
    [Space]
    [SerializeField] private GameObject _panelEndThisGame;

    [Space(10)]
    [Header("Access to Scripts Variabls")]
    [SerializeField] private LevelManager _levelManager;
    [SerializeField] private BallRoadPainet _player;

    #region Singleton class: UIManager
    public static GM_Roller_Splat Instance;
    private void Awake()
    {
        if (Instance == null)
            Instance = this;
    }
    #endregion

    private void Start(){

        FadeAtStart();

        LoadLevelText();

        _progressFillImage.fillAmount = 0f;
    }

    //---------------------------------------------------------
    private void OnEnable()
    {
        Button_GM_Roll.clickButtonRestartAndDeleteSaveAction += RestartGame;
    }

    private void OnDisable()
    {
        Button_GM_Roll.clickButtonRestartAndDeleteSaveAction -= RestartGame;
    }

    private void RestartGame()
    {
        SavePlayerPrefs.Instance.DeleteASpecificSave(Dictionary.nameSaveLevelRollerSplat);
        StartCoroutine(RestartScene(1f));
    }

    //---------------------------------------------------------
    public void LoadLevel()
    {
        _currentLevel = SavePlayerPrefs.Instance.LoadInt(Dictionary.nameSaveLevelRollerSplat, _currentLevel);
    }

    private void LoadLevelText(){     
        _textCurrentLevel.text = _currentLevel.ToString();
        _textNextLevel.text = (_currentLevel + 1).ToString();

        string panelText = _currentLevel.ToString() + " / " + _maxLevel.ToString();

        _textPanelLevel.text = panelText;
    }

    //---------------------------------------------------------
    public void UpdateProgressRollerSplat(){
        float val = ((float)_player.paintedRoadTiles / _levelManager.roadTilesList.Count);
        _progressFillImage.DOFillAmount(val, 0.4f);
    }

    public void CheckLevelComplited(){
        if (_player.paintedRoadTiles == _levelManager.roadTilesList.Count){
            AudioManager.Instance.PlayClip(Dictionary.nameAudioClipRollerSplatWin);
            _winFX.Play();
            ShowLevelCompletedUI();
            //Load new Level...
            Debug.Log("CheckLevelComplited " + _currentLevel);
            if(_currentLevel >= _maxLevel){
                StartCoroutine(ActivePanelEnd(1.5f));
            }else{
                _currentLevel++;
                SavePlayerPrefs.Instance.SaveInt(Dictionary.nameSaveLevelRollerSplat, _currentLevel);
                Debug.Log("Level Completed");
                StartCoroutine(RestartScene(2.5f));
            }
        }
    }
    
    private IEnumerator RestartScene(float waitTime)
    {
        AudioManager.Instance.PlayClip(Dictionary.nameAudioClipClick);
        yield return new WaitForSeconds(waitTime);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    private IEnumerator ActivePanelEnd(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        AudioManager.Instance.PlayClip(Dictionary.nameAudioClipRollerSplatGameOver);
        _panelEndThisGame.SetActive(true);
    }

    //---------------------------------------------------------
    public void ShowLevelCompletedUI()
    {
        _levelCompletedText.gameObject.SetActive(true);
        _levelCompletedText.DOFade(1f, 0.6f).From(0f);
    }

    public void FadeAtStart()
    {
        _fadePanel.DOFade(0f, 1.3f).From(1f);
    }
}
