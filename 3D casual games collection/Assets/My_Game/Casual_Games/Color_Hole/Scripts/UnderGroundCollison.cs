using UnityEngine;
using DG.Tweening;

public class UnderGroundCollison : MonoBehaviour
{
    [SerializeField] private GameObject _soundCube;

    private void OnTriggerEnter(Collider other){
        if (!GameManagerHoleVsColor.isGameover){
            string tag = other.tag;

            if (tag.Equals(Dictionary.nameTagObject)){
                Instantiate(_soundCube, transform.position, Quaternion.identity);

                Level.Instance.objectsInScene--;
                UIManager.Instance.UpdateLevelProgress();

                Magnet.Instance.RemoveFromMagnetField(other.attachedRigidbody);

                Destroy(other.gameObject);
            
                //check if win
                if(Level.Instance.objectsInScene == 0){
                    //no more objects to collect
                    UIManager.Instance.ShowLevelCompletedUI();

                    Level.Instance.PlayWinFx();
                    if(UIManager.Instance.currentLevel >= UIManager.Instance.maxLevel){
                        UIManager.Instance.panelNotMoreLevels.SetActive(true);
                    }else{
                        UIManager.Instance.currentLevel++;
                        SavePlayerPrefs.Instance.SaveInt(Dictionary.nameSaveLevelColorHole, UIManager.Instance.currentLevel);

                        Invoke("NextLevel", 2f);
                    }
                }
            }
            else if (tag.Equals(Dictionary.nameTagObstacle) || tag.Equals(Dictionary.nameTagPartoll)){
                GameManagerHoleVsColor.isGameover = true;
                AudioManager.Instance.PlayClip(Dictionary.nameAudioClipColorHoleGameOver);
                Camera.main.transform
                    .DOShakePosition(1f, 0.2f, 20, 90f)
                    .OnComplete(() =>{
                        Level.Instance.RestartLevel();
                    });
            }
        }
    }

    private void NextLevel()
    {
        Level.Instance.LoadNextLevel();
    }
}
