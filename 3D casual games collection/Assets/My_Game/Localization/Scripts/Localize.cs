using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace MyGameCollection.Localization
{
    [RequireComponent(typeof(TMP_Text))]
    public class Localize : LocalizBase
    {
        #region Private Fields
        private TMP_Text text;
        #endregion

        #region Public Methods
        public override void UpdateLocale()
        {
            if (!text) return;
            if (!System.String.IsNullOrEmpty(localizationKey) && Locale.CurrentLanguageStrings.ContainsKey(localizationKey))
                text.text = Locale.CurrentLanguageStrings[localizationKey].Replace(@"\n", "" + '\n'); ;
        }
        #endregion

        #region Private Methods
        protected override void Start()
        {
            text = GetComponent<TMP_Text>();
            base.Start();
        }
        #endregion

    }
}
