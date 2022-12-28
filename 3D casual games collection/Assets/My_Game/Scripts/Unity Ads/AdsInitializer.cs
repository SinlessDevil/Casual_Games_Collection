using UnityEngine;
using UnityEngine.Advertisements;

public class AdsInitializer : MonoBehaviour, IUnityAdsInitializationListener
{
    [Header("Game ID")]
    [SerializeField] private string _androidGameId;
    [SerializeField] private string _iOSGameId;
    [Space(20)]

    [Header("Test Mode")]
    [SerializeField] private bool _testMode;

    private string _gameId;

    private void Awake(){
        InitializeAds();
    }

    public void InitializeAds(){
        _gameId = (Application.platform == RuntimePlatform.IPhonePlayer)
            ? _iOSGameId
            : _androidGameId;

        Advertisement.Initialize(_gameId, _testMode, this);
    }

    public void OnInitializationComplete(){
        Debug.Log("Unity Ads Initialization complete. ");
    }

    public void OnInitializationFailed(UnityAdsInitializationError error, string message){
        Debug.Log($"Unity Ads Initialization Failed: {error.ToString()} - {message}");
    }
}
