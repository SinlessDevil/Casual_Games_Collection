using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class SceneController : MonoBehaviour
{
    public enum TypeGame
    {
        Menu,
        Drop_The_Number,
        Color_Hole,
        Rollet_Splat,
        Helix_Jump,
        Voodoos_Stickly_Block
    }
    public TypeGame typeGame;

    private const float WAIT_TIME = 0.1f;

    private void OnEnable()
    {
        switch (typeGame)
        {
            case TypeGame.Menu:
                ButtonManager.clickButtonDropTheNumberAction += DropTheNumber;
                ButtonManager.clickButtonColorHolerAction += ColorHoler;
                ButtonManager.clickButtonRollerSplatAction += RollerSplat;
                ButtonManager.clickButtonHelixJumpAction += HelixJump;
                ButtonManager.clickButtoVoodoosSticklyBlockAction += VoodoosSticklyBlock;
                ButtonManager.clickButtonExitAction += ExitGame;
                break;
            case TypeGame.Drop_The_Number:
                Button_GM_MegaCube.clickButtonExitToMenuAction += BackToMenu;
                Button_GM_MegaCube.clickButtonRestartAction += RestartGame;
                Button_GM_MegaCube.clickButtonExitThePanelToMenuAction += BackToMenu;
                break;
            case TypeGame.Color_Hole:
                Button_GM_Color_Hole.clickButtonExitThePanelToMenuAction += BackToMenu;
                Button_GM_Color_Hole.clickButtonExitToMenuAction += BackToMenu;
                break;
            case TypeGame.Rollet_Splat:
                Button_GM_Roll.clickButtonExitThePanelToMenuAction += BackToMenu;
                Button_GM_Roll.clickButtonExitToMenuAction += BackToMenu;
                Button_GM_Roll.clickButtonRestartAction += RestartGame;
                break;
            case TypeGame.Helix_Jump:
                break;
            case TypeGame.Voodoos_Stickly_Block:
                break;
        }
    }

    private void OnDisable()
    {
        switch (typeGame)
        {
            case TypeGame.Menu:
                ButtonManager.clickButtonDropTheNumberAction -= DropTheNumber;
                ButtonManager.clickButtonColorHolerAction -= ColorHoler;
                ButtonManager.clickButtonRollerSplatAction -= RollerSplat;
                ButtonManager.clickButtonHelixJumpAction -= HelixJump;
                ButtonManager.clickButtoVoodoosSticklyBlockAction -= VoodoosSticklyBlock;
                ButtonManager.clickButtonExitAction -= ExitGame;
                break;
            case TypeGame.Drop_The_Number:
                Button_GM_MegaCube.clickButtonExitToMenuAction -= BackToMenu;
                Button_GM_MegaCube.clickButtonRestartAction -= RestartGame;
                Button_GM_MegaCube.clickButtonExitThePanelToMenuAction -= BackToMenu;
                break;
            case TypeGame.Color_Hole:
                Button_GM_Color_Hole.clickButtonExitThePanelToMenuAction -= BackToMenu;
                Button_GM_Color_Hole.clickButtonExitToMenuAction -= BackToMenu;
                break;
            case TypeGame.Rollet_Splat:
                Button_GM_Roll.clickButtonExitThePanelToMenuAction -= BackToMenu;
                Button_GM_Roll.clickButtonExitToMenuAction -= BackToMenu;
                Button_GM_Roll.clickButtonRestartAction -= RestartGame;
                break;
            case TypeGame.Helix_Jump:
                break;
            case TypeGame.Voodoos_Stickly_Block:
                break;
        }
    }

    #region Game Scene Methods
    private void DropTheNumber()
    {
        StartCoroutine(CoroutineDropTheNumber());
    }

    private void ColorHoler()
    {
        StartCoroutine(CoroutineColorHoler());
    }

    private void RollerSplat()
    {
        StartCoroutine(CoroutineRollerSplat());
    }

    private void HelixJump()
    {
        StartCoroutine(CoroutineHelixJump());
    }

    private void VoodoosSticklyBlock()
    {
        StartCoroutine(CoroutineVoodoosSticklyBlock());
    }

    //-------------------------------------------------------

    private IEnumerator CoroutineDropTheNumber()
    {
        AudioManager.Instance.PlayClip(Dictionary.nameAudioClipClick);
        yield return new WaitForSeconds(WAIT_TIME);
        SceneManager.LoadScene(Dictionary.nameSceneDroptheNumber);
    }

    private IEnumerator CoroutineColorHoler()
    {
        AudioManager.Instance.PlayClip(Dictionary.nameAudioClipClick);
        yield return new WaitForSeconds(WAIT_TIME);
        Time.timeScale = 1f;

        int numberScene = 0;
        numberScene = SavePlayerPrefs.Instance.LoadInt(Dictionary.nameSaveLevelColorHole, numberScene);
        string nameScene = Dictionary.nameSceneColorHole + numberScene.ToString();
        SceneManager.LoadScene(nameScene);
    }

    private IEnumerator CoroutineRollerSplat()
    {
        AudioManager.Instance.PlayClip(Dictionary.nameAudioClipClick);
        yield return new WaitForSeconds(WAIT_TIME);
        SceneManager.LoadScene(Dictionary.nameSceneRollerSplat);
    }

    private IEnumerator CoroutineHelixJump()
    {
        AudioManager.Instance.PlayClip(Dictionary.nameAudioClipClick);
        yield return new WaitForSeconds(WAIT_TIME);
        SceneManager.LoadScene(Dictionary.nameSceneHelixJump);
    }

    private IEnumerator CoroutineVoodoosSticklyBlock()
    {
        AudioManager.Instance.PlayClip(Dictionary.nameAudioClipClick);
        yield return new WaitForSeconds(WAIT_TIME);
        SceneManager.LoadScene(Dictionary.nameSceneVoodooStickly);
    }

    #endregion

    #region Other Methods

    private void ExitGame()
    {
        StartCoroutine(CoroutineExitGame());
    }

    private void RestartGame()
    {
        Time.timeScale = 1f;
        StartCoroutine(CoroutineRestartGame());
    }

    private void BackToMenu()
    {
        Time.timeScale = 1f;
        StartCoroutine(CoroutineBackToMenu());
    }

    //-------------------------------------------------------

    private IEnumerator CoroutineExitGame()
    {
        AudioManager.Instance.PlayClip(Dictionary.nameAudioClipClick);
        yield return new WaitForSecondsRealtime(WAIT_TIME);
        Application.Quit();
    }

    private IEnumerator CoroutineRestartGame()
    {
        AudioManager.Instance.PlayClip(Dictionary.nameAudioClipClick);
        yield return new WaitForSecondsRealtime(WAIT_TIME);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    private IEnumerator CoroutineBackToMenu()
    {
        AudioManager.Instance.PlayClip(Dictionary.nameAudioClipClick);
        yield return new WaitForSecondsRealtime(WAIT_TIME);
        SceneManager.LoadScene(Dictionary.nameSceneMenu);
    }
    #endregion
}
