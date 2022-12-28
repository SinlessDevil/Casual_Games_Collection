using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class Level : MonoBehaviour
{
    #region Singleton class: UIManager

    public static Level Instance;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
    }

    #endregion
    [SerializeField] private ParticleSystem _winFx;
    [Space]
    [SerializeField] private Transform objectsParent;

    [HideInInspector] public int objectsInScene;
    [HideInInspector] public int totalObjects;


    [Space(10)]
    [Header("Level Objects & Obstacles")]
    [SerializeField] private Material _groundMaterial;
    [SerializeField] private Material _objectMatial;
    [SerializeField] private Material _obstacleMaterial;
    [SerializeField] private Material _groundBordeMaterial;
    [SerializeField] private SpriteRenderer _bgFadeSprite;

    [Space(10)]
    [Header("Level  Colors ----------------")]
    [Header("Ground")]
    [SerializeField] private Color _groundColor;
    [SerializeField] private Color _bordersColor;
    [Space]
    [Header("Objects & Obstacles")]
    [SerializeField] private Color _objectColor;
    [SerializeField] private Color _obstacleColor;
    [Space]
    [Space]
    [Header("Backgound")]
    [SerializeField] private Color _cameraColor;
    [SerializeField] private Color _fadeColor;


    private void Start()
    {
        CountObjects();

        UpdateLevelColors();
    }

    // Update is called once per frame
    private void CountObjects()
    {
        totalObjects = objectsParent.childCount;
        objectsInScene = totalObjects;
    }

    public void PlayWinFx()
    {
        StartCoroutine(CoroutineFirework());
        _winFx.Play();
    }

    private IEnumerator CoroutineFirework()
    {
        AudioManager.Instance.PlayClip(Dictionary.nameAudioClipColorHoleShootFirework);
        yield return new WaitForSeconds(0.5f);
        AudioManager.Instance.PlayClip(Dictionary.nameAudioClipColorHoleExplosionFirework);
    }

    public void LoadNextLevel()
    {
        string nameScene = Dictionary.nameSceneColorHole + (UIManager.Instance.currentLevel).ToString();
        SceneManager.LoadScene(nameScene);
    }

    public void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    private void UpdateLevelColors()
    {
        _groundMaterial.color = _groundColor;
        _groundBordeMaterial.color = _bordersColor;

        _obstacleMaterial.color = _obstacleColor;
        _objectMatial.color = _objectColor;

        Camera.main.backgroundColor = _cameraColor;
        _bgFadeSprite.color = _fadeColor;
    }

    private void OnValidate()
    {
        UpdateLevelColors();
    }
}
