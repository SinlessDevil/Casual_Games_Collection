using UnityEngine;
using UnityEngine.UI;


namespace MyGameCollection.Localization
{
    [RequireComponent(typeof(Image))]
    public class LocalizeImage : MonoBehaviour
    {
        #region Public Fiedls
        public string localizationKey;
        #endregion

        #region Private Fields
        private const string STR_LOCALIZATTION_PREFIX = "Localization/UI/";
        private Image image;
        #endregion

        #region Public Methods
        public static void SetCurrentLanguage()
        {
            LocalizeImage[] allTexts = GameObject.FindObjectsOfType<LocalizeImage>();
            for (int i = 0; i < allTexts.Length; i++)
            {
                allTexts[i].UpdateLocale();
            }
        }

        public void UpdateLocale()
        {
            if (!image) return;
            Invoke("_updateLocale", 0.1f);
        }
        #endregion

        #region Private Methods
        private void _updateLocale()
        {
            if (Locale.currentLanguageHasBeenSet)
            {
                Sprite tmp = Resources.Load(STR_LOCALIZATTION_PREFIX + Locale.PlayerLanguage.ToString() + "/" + localizationKey, typeof(Sprite)) as Sprite;
                if (tmp != null)
                    image.sprite = tmp;
                return;
            }
            UpdateLocale();
        }

        private void Start()
        {
            image = GetComponent<Image>();
            UpdateLocale();
        }
        #endregion
    }
}
