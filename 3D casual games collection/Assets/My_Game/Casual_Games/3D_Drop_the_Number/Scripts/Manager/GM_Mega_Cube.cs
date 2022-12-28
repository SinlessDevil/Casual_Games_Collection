using UnityEngine;
using TMPro;
using UnityEngine.UI;
using DG.Tweening;
using System.Collections;
using UnityEngine.SceneManagement;

public class GM_Mega_Cube : MonoBehaviour
{
    [Header("Progress Bar Variabls")]
    [SerializeField] private TMP_Text[] _numberText;
    [SerializeField] private string[] _text;
    [SerializeField] private Image[] _progressFillImage;
    [Space(10)]

    [Header("Number Game Variabls")]
    public int lastNumber = 262144; // 2^18
    public int currenMaxNumber = 2;
    //--------------------------------------
    private int _secondNumber = 64; // 2^6
    private int _thirdNumber = 4096; // 2^12
    [Space(10)]

    [Header("Game Over Variabls")]
    [SerializeField] private GameObject _textGameOver;
    [SerializeField] private GameObject _textWinGame;
    [SerializeField] private GameObject _panelWinLose;
    [Space(10)]

    [Header("Record Varialds")]
    [SerializeField] private int _record;
    [SerializeField] private TMP_Text _textRecord;
    [Space(10)]

    [Header("Partical FX")]
    [SerializeField] private ParticleSystem _winFX;
    [SerializeField] private GameObject[] _pointFX;
    [SerializeField] private bool[] _checkPointFx;

    #region Singleton class: UIManager
    public static GM_Mega_Cube Instance;
    private void Awake(){
        if (Instance == null)
            Instance = this;
    }
    #endregion

    private void Start()
    {
        //Load record-----------------------
        _record = SavePlayerPrefs.Instance.LoadInt(Dictionary.nameSaveRecordMegaCube, _record);
        _textRecord.text = _record.ToString();

        CheckNumber();

        CheckFiller();
    }

    #region Game Over Methods
    public void GameOver(bool isActiveGame)
    {
        StartCoroutine(CoroutineGameOver(isActiveGame));

        if(currenMaxNumber > _record)
        {
            _record = currenMaxNumber;
            SavePlayerPrefs.Instance.SaveInt(Dictionary.nameSaveRecordMegaCube, _record);
        }
    }
    private IEnumerator CoroutineGameOver(bool isActive)
    {
        AudioManager.Instance.PlayClip(Dictionary.nameAudioClipMegaCubeGameOver);
        yield return new WaitForSeconds(0.5f);

        if (isActive == false)
            _textGameOver.SetActive(!isActive);
        else
            _textWinGame.SetActive(isActive);

        _panelWinLose.SetActive(true);

        Time.timeScale = 0f;
    }
    #endregion

    #region Start Game Methods
    private void CheckFiller()
    {
        for (int i = 0; i < _progressFillImage.Length; i++)
            _progressFillImage[i].fillAmount = 0f;
    }
    private void CheckNumber()
    {
        for (int i = 0; i < _numberText.Length; i++)
            _numberText[i].text = _text[i];
    }
    #endregion

    public void UpdateProgressMegaCube()
    {  
        if(_progressFillImage[0].fillAmount < 1f){
             float val = ((float)currenMaxNumber / _secondNumber);
            _progressFillImage[0].DOFillAmount(val, 0.4f);
        }else if(_progressFillImage[1].fillAmount < 1f){
            float val = ((float)currenMaxNumber / _thirdNumber);
            _progressFillImage[1].DOFillAmount(val, 0.4f);
        }else if (_progressFillImage[2].fillAmount < 1f){
            float val = ((float)currenMaxNumber / lastNumber);
            _progressFillImage[2].DOFillAmount(val, 0.4f);
        }

        for (int i = 0; i < _pointFX.Length; i++){
            if (_progressFillImage[i].fillAmount >= 1f && _checkPointFx[i] == false){
                _checkPointFx[i] = true;
                _winFX.transform.position = _pointFX[i].transform.position;
                _winFX.Play();
                AudioManager.Instance.PlayClip(Dictionary.nameAudioClipMegaCubeWinbProgressBar);
                Debug.Log("WinPlay = " + i);
            }
        }

        if (currenMaxNumber > _record){
            _record = currenMaxNumber;   
            _textRecord.text = _record.ToString();
            SavePlayerPrefs.Instance.SaveInt(Dictionary.nameSaveRecordMegaCube, _record);
        }
    }
}
