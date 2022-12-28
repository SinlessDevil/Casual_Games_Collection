using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameItem : MonoBehaviour
{
    [Header("Image & Text - GameItem")]
    [SerializeField] private TMP_Text _nameGameItemText;
    [SerializeField] private Image _bgGameItemColor;
    [SerializeField] private Image _buttonGameItemColor;
    [SerializeField] private Image _imageGame;
    [Space(10)]

    [Header("Color & string - Change GameItem")]
    [SerializeField] private string _nameText;
    [SerializeField] private Color _bgColor;
    [SerializeField] private Color _buttonColor;
    [SerializeField] private Sprite _iconGmae;
    [Space(10)]

    [Header("Ready Game")]
    [SerializeField] private bool _isReady = true;
    [SerializeField] private Button _buttonPlay;
    [SerializeField] private GameObject _panelIsNotReady;


    private void Awake()
    {
        _nameGameItemText.text = _nameText;
        _bgGameItemColor.color = _bgColor;
        _buttonGameItemColor.color = _buttonColor;
        _imageGame.sprite = _iconGmae;

        CheckIsReady();
    }


    private void CheckIsReady()
    {
        if (!_isReady)
        {
            _buttonPlay.interactable = true;
            _panelIsNotReady.SetActive(true);
        }
    }
}
